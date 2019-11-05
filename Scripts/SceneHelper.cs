using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHelper : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;

        Vector3 A = new Vector3(-.5f, -.5f, 0);
        Vector3 B = new Vector3(-.5f, +.5f, 0);
        Vector3 C = new Vector3(+.5f, +.5f, 0);
        Vector3 D = new Vector3(+.5f, -.5f, 0);

        Gizmos.DrawLine(A, B);
        Gizmos.DrawLine(B, C);
        Gizmos.DrawLine(C, D);
        Gizmos.DrawLine(D, A);
    }
}
