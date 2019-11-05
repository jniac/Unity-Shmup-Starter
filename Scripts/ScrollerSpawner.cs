using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class ScrollerSpawner : MonoBehaviour
{
    public GameObject source;
    public Vector3 velocity = new Vector3(-2, 0, 0);

    public bool staged = false;
    public bool stagedOld = false;

    void Update()
    {
        stagedOld = staged;
        staged = Stage.stage.SpawnContains(transform.position);

        if (Application.isPlaying)
            if (staged && !stagedOld)
                Spawn();
    }

    void Spawn()
    {
        GameObject spawned = 
            Instantiate(source, transform.position, transform.rotation);

        Rigidbody body = spawned.GetComponent<Rigidbody>();
        body.velocity = velocity;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = staged ? Color.red : Color.yellow;

        Gizmos.DrawSphere(transform.position, .1f);
        Gizmos.DrawRay(transform.position, velocity);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        GUIStyle style = new GUIStyle
        {
            alignment = TextAnchor.UpperCenter,
            fixedWidth = 200,
        };

        style.normal.textColor = Color.yellow;
        var label = source?.name ?? "null";
        Handles.Label(transform.position, label, style);
    }
#endif
}
