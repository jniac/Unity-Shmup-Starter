﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObject : MonoBehaviour
{
    void Update()
    {
        if (Stage.instance.KillContains(transform.position) == false)
            Destroy(gameObject);
    }
}
