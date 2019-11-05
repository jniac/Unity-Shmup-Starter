using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public Vector3 movement = Vector3.left;
    public float speed = 1;

    void Update()
    {
        transform.position += movement * Time.deltaTime * speed;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawLine(transform.position + Vector3.up * 3, transform.position + Vector3.down * 3);
        Gizmos.DrawLine(transform.position + Vector3.left * 3, transform.position + Vector3.right * 3);
    }
}
