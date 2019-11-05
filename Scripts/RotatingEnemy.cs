using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour
{
    public float rotateSpeed = 720;

    void Update()
    {
        transform.rotation *= 
            Quaternion.Euler(0, 0, rotateSpeed * Time.deltaTime);
    }
}
