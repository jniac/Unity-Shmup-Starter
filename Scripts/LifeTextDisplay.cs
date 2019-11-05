using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LifeTextDisplay : MonoBehaviour
{
    void Update()
    {
        TMPro.TextMeshPro textMesh =
             GetComponent<TMPro.TextMeshPro>();

        Life life =
            GetComponentInParent<Life>();

        if (life == null)
        {
            textMesh.text = "Il n'y a pas de composant [Life] accessible.";
        }
        else
        {
            textMesh.text = $"{life.hp}/{life.hpMax}";
        }
    }
}
