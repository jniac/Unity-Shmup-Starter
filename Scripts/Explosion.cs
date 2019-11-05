using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // expose l'instance unique de [Explosion]
    // à travers une propriété statique (singleton)
    public static Explosion instance;




    public List<GameObject> sources = new List<GameObject>();

    public int numberOfShards = 10;
    public float shardVelocity = 5;
    public float shardAngularVelocity = 180f;
    public float shardDrag = 1f;

    private void Awake()
    {
        instance = this;
    }

    public GameObject RandomPick()
    {
        int index = Random.Range(0, sources.Count);
        return sources[index];
    }

    public Vector3 RandomAngularVelocity()
    {
        float vz = Random.Range(-shardAngularVelocity, shardAngularVelocity);
        return new Vector3(0, 0, vz);
    }

    public void Fire()
    {
        for (int i = 0; i < numberOfShards; i++)
        {
            GameObject shard = Instantiate(RandomPick(), 
                transform.position, transform.rotation);

            shard.hideFlags = HideFlags.HideInHierarchy;

            Rigidbody shardBody = shard.AddComponent<Rigidbody>();
            shardBody.velocity = Random.insideUnitCircle * shardVelocity;
            shardBody.angularVelocity = RandomAngularVelocity();
            shardBody.useGravity = false;
            shardBody.drag = shardDrag;

            Bullet shardBullet = shard.AddComponent<Bullet>();
            shardBullet.duration = .3f;
            shardBullet.scaleOverTime = true;
        }
    }

    public bool triggerFire = false;
    private void Update()
    {
        if (triggerFire == true)
        {
            triggerFire = false;
            Fire();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, .1f);
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
