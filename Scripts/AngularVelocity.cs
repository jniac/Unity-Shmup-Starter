using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshCollider))]
public class AngularVelocity : MonoBehaviour
{
    public Vector3 angularVelocity;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();

        body.angularVelocity = angularVelocity;
    }
}
