using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HFGun : MonoBehaviour
{
	public float frequency = 120;

    (Vector3 position, Quaternion rotation) old;

    void Start()
    {
        old = (transform.position, transform.rotation);
    }

    void Update()
    {
        old = (transform.position, transform.rotation);
    }
}
