using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Kit
{
    public static class DictionaryExt
    {
        public static void Deconstruct<T1, T2>(this KeyValuePair<T1, T2> tuple, out T1 key, out T2 value)
        {
            key = tuple.Key;
            value = tuple.Value;
        }
    }

    public static class RequireExt
    {
        public static T Require<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }
    }

    [ExecuteAlways]
    public class Cloner : MonoBehaviour
    {
        //public bool hideClones = true;

        void Run()
        {
            foreach (var clone in transform.parent.GetComponentsInChildren<Cloned>())
            {
                if (clone && (!clone.cloner || clone.cloner == this))
                    DestroyImmediate(clone.gameObject);
            }

            IEnumerable<GameObject> sources = new List<GameObject> { gameObject };

            foreach (var op in GetComponents<Op>())
            {
                op.Process(sources);

                sources = op.objects;
            }
        }

        //void Yolo()
        //{
        //    Debug.Log($"Yolo {hideClones}");
        //    foreach (var clone in transform.parent.GetComponentsInChildren<Cloned>())
        //    {
        //        clone.gameObject.hideFlags = hideClones ?
        //            HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild | HideFlags.HideInHierarchy :
        //            HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
        //    }
        //}

#if UNITY_EDITOR
        private void OnEnable()
        {
            // Make Unity crash...
            //Run();   
        }

        void Update()
        {
            //if (transform.hasChanged)
            //{
            //    foreach (var op in GetComponents<Op>())
            //    {
            //        op.UpdateTransform();
            //    }
            //}
        }

        [CustomEditor(typeof(Cloner))]
        class MyEditor : Editor
        {
            Cloner Target => target as Cloner;

            override public void OnInspectorGUI()
            {
                //EditorGUI.BeginChangeCheck();
                //Target.hideClones = EditorGUILayout.Toggle("Hide Clones", Target.hideClones);
                //if (EditorGUI.EndChangeCheck())
                    //Target.Yolo();

                if (GUILayout.Button("Add Linear Op"))
                {
                    Target.gameObject.AddComponent<Linear>();
                    Target.Run();
                }

                if (GUILayout.Button("Update"))
                    Target.Run();
            }
        }
#endif
    }

    [ExecuteAlways]
    class Cloned : MonoBehaviour
    {
        [HideInInspector, System.NonSerialized] public Cloner cloner;
    }

    [ExecuteAlways]
    abstract class Op : MonoBehaviour
    {
        [HideInInspector, System.NonSerialized] public Cloner cloner;
        [HideInInspector, System.NonSerialized] public List<GameObject> objects = new List<GameObject>();

        void Awake()
        {
            cloner = GetComponent<Cloner>();
        }

        public abstract void Process(GameObject source);
        public abstract void Process(IEnumerable<GameObject> source);

        public abstract void UpdateTransform();
    }

    [ExecuteAlways]
    class Linear : Op
    {
        Dictionary<GameObject, List<GameObject>> dictionary = new Dictionary<GameObject, List<GameObject>>();

        public float count = 3f;

        public Vector3 movement = Vector3.right;

        public override void UpdateTransform()
        {
            foreach (var (source, clones) in dictionary)
            {
                float max = Mathf.Min(Mathf.Floor(count), clones.Count + 1);

                for (float i = 1; i < max; i++)
                {
                    var clone = clones[(int)i - 1];

                    if (!clone)
                        continue;

                    clone.transform.localPosition = source.transform.position + movement * i;
                    clone.transform.localRotation = source.transform.localRotation;
                }
            }
        }

        public override void Process(GameObject source)
        {
            objects.Add(source);
            dictionary.Add(source, new List<GameObject>());

            for (float i = 1; i < (int)count; i++)
            {
                var clone = Instantiate(source, source.transform.parent);

                DestroyImmediate(clone.GetComponent<Cloner>());
                foreach (var op in clone.GetComponents<Op>())
                    DestroyImmediate(op);

                clone.Require<Cloned>().cloner = cloner;
                clone.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;

                dictionary[source].Add(clone);
                objects.Add(clone);
            }
        }

        public override void Process(IEnumerable<GameObject> sources)
        {
            objects.Clear();
            dictionary.Clear();

            foreach (var source in sources)
            {
                Process(source);
            }

            UpdateTransform();
        }
    }
}

