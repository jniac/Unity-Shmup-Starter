using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class Stage : MonoBehaviour
{
    public static Stage instance;

    public float width = 16;
    public float height = 9;
    public float spawnPadding = 4;
    public float killPadding = 20;

    void OnEnable()
    {
        instance = this;
    }

    public bool Contains(float x, float y, float padding = 0)
    {
        float left =    -width / 2 - padding;
        float right =   +width / 2 + padding;
        float top =     +height / 2 + padding;
        float bottom =  -height / 2 - padding;

        return
            x >= left && x <= right &&
            y >= bottom && y <= top;
    }

    public bool Contains(Vector3 position, float padding = 0) =>
        Contains(position.x, position.y, padding);

    public bool KillContains(float x, float y) =>
        Contains(x, y, killPadding);

    public bool KillContains(Vector3 position) =>
        KillContains(position.x, position.y);

    public bool SpawnContains(float x, float y) =>
        Contains(x, y, spawnPadding);

    public bool SpawnContains(Vector3 position) =>
        SpawnContains(position.x, position.y);

    void DrawRect(float w, float h)
    {
        Vector3 TL, TR, BR, BL;

        TL = new Vector3(-w / 2, +h / 2, 0);
        TR = new Vector3(+w / 2, +h / 2, 0);
        BR = new Vector3(+w / 2, -h / 2, 0);
        BL = new Vector3(-w / 2, -h / 2, 0);

        Gizmos.DrawLine(TL, TR);
        Gizmos.DrawLine(TR, BR);
        Gizmos.DrawLine(BR, BL);
        Gizmos.DrawLine(BL, TL);
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        DrawRect(width, height);

        Gizmos.color = Color.yellow;
        DrawRect(width + spawnPadding * 2, height + spawnPadding * 2);

        Gizmos.color = Color.white;
        DrawRect(width + killPadding * 2, height + killPadding * 2);

        GUIStyle style = new GUIStyle
        {
            alignment = TextAnchor.UpperCenter,
            fixedWidth = 200,
        };

        style.normal.textColor = Color.white;
        Handles.Label(Vector3.up * height / 2, "Stage - Scene", style);

        style.normal.textColor = Color.yellow;
        Handles.Label(Vector3.up * (height / 2 + spawnPadding), "Stage - Spawn", style);

        style.normal.textColor = Color.white;
        Handles.Label(Vector3.up * (height / 2 + killPadding), "Stage - Kill", style);
    }

    //[CustomEditor(typeof(Stage))]
    //class MyEditor : Editor
    //{
    //    public override void OnInspectorGUI()
    //    {
    //        base.OnInspectorGUI();

    //        EditorGUILayout.Space(20);
    //        EditorGUILayout.LabelField("[DEBUG]");
    //        if (GUILayout.Button("Remove HideInHierarchy GameObjects"))
    //        {
    //            var array = FindObjectsOfType<GameObject>();

    //            foreach(var go in array)
    //            {
    //                Debug.Log($"{go}: {go.hideFlags}");
    //                if (go.hideFlags.HasFlag(HideFlags.HideInHierarchy))
    //                    DestroyImmediate(go);
    //            }
    //        }
    //    }
    //}
#endif
}
