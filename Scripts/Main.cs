using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance => GetMain();

    static Main instance;
    public static Main GetMain()
    {
        if (!instance)
        {
            var go = new GameObject("Main");
            go.AddComponent<Main>();
        }

        return instance;
    }

    void OnEnable()
    {
        instance = this;
    }

    public void ScrollCall(ScrollerTrigger scrollTriggerType)
    {
        var go = Resources.Load<Scroller>("Scroller-Sequence1");
        Instantiate(go);
    }
}
