using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Stage-1");
    }

    void OnMouseOver()
    {
        transform.localScale = Vector3.one * 1.1f;
    }

    void OnMouseExit()
    {
        transform.localScale = Vector3.one;
    }
}
