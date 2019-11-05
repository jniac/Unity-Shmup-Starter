using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static int GetBulletMask(int shipMask)
    {
        if (shipMask == LayerMask.NameToLayer("EnemyShip"))
            return LayerMask.NameToLayer("EnemyBullet");

        if (shipMask == LayerMask.NameToLayer("PlayerShip"))
            return LayerMask.NameToLayer("PlayerBullet");

        return 0;
    }

    public Rigidbody bulletSource;

    public float bulletDamageOverload = 1f;

    public float bulletSpeed = 10f;

    public float frequence = 2f;
    public string sequence = "1";
    public float fireLoad = 0;
    public int fireIndex = 0;

    public bool triggerFire = false;

    private void OnEnable()
    {
        fireIndex = 0;
    }

    void Update()
    {
        fireLoad += Time.deltaTime;

        float period = 1f / frequence;
        if (fireLoad > period)
        {
            fireLoad += -period;
            Fire();
        }

        if (triggerFire == true)
        {
            triggerFire = false;
            Fire();
        }
    }

    public void Fire()
    {
        char sequenceChar = sequence[fireIndex];

        fireIndex++;

        if (fireIndex >= sequence.Length)
            fireIndex = 0;

        if (sequenceChar == '1')
        {
            Rigidbody body = Instantiate(bulletSource,
                transform.position, transform.rotation);

            body.gameObject.hideFlags = HideFlags.HideInHierarchy;

            body.velocity = transform.right
                * bulletSpeed;

            Bullet bullet = body.GetComponent<Bullet>();
            bullet.damage = (int)(bullet.damage * bulletDamageOverload);

            foreach (Collider collider in body.GetComponentsInChildren<Collider>())
            {
                collider.gameObject.layer =
                    Gun.GetBulletMask(gameObject.layer);
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, .1f);
        Gizmos.DrawRay(transform.position, transform.right);
    }
}
