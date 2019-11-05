using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScrollTriggerType
{
    RANDOM_WAVES,
    BOSS_1,
}

public class ScrollerTrigger : MonoBehaviour
{
    public ScrollTriggerType type;

    bool staged = false;
    bool stagedOld = false;

    void Update()
    {
        stagedOld = staged;
        staged = Stage.stage.SpawnContains(transform.position);

        if (Application.isPlaying)
            if (staged && !stagedOld)
                Fire();
    }

    void Fire()
    {
        Main.main.ScrollCall(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = staged ? Color.red : Color.yellow;

        Gizmos.DrawSphere(transform.position, .1f);
        Gizmos.DrawLine(transform.position + Vector3.up * 3, transform.position + Vector3.down * 3);
        Gizmos.DrawLine(transform.position + Vector3.left * 3, transform.position + Vector3.right * 3);
    }
}
