using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // durée de vie en secondes (float)
    public float duration = 4f;
    public float elapsed = 0;

    public bool scaleOverTime = false;

    public int damage = 10;

    void Update()
    {
        if (scaleOverTime)
        {
            float scale = 1f - Mathf.Pow(elapsed / duration, 5f);
            transform.localScale = Vector3.one * scale;
        }

        elapsed += Time.deltaTime;

        // si le temps écoulé dépasse la durée autorisée
        // la "bullet" s'autodétruit
        if (elapsed > duration)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        Explosion.instance.transform.position = transform.position;
        Explosion.instance.Fire();

        Life life = other.GetComponentInParent<Life>();
        if (life != null)
        {
            life.SetDamage(damage);
        }
    }
}
