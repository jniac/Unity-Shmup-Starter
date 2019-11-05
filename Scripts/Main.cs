using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main main;

    void OnEnable()
    {
        main = this;
    }

    public void ScrollCall(ScrollerTrigger scrollTriggerType)
    {
        var go = Resources.Load<Scroller>("Scroller-Sequence1");
        Instantiate(go);
    }
}
