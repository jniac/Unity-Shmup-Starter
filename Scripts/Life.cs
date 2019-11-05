using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int hpMax = 200;
    public int hp = 200;

    public void SetDamage(int damage)
    {
        hp += -damage;

        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }

    public void SetHeal(int heal)
    {
        hp += heal;

        if (hp >= hpMax)
        {
            hp = hpMax;
        }
    }

    private void OnValidate()
    {
        hp = hpMax;
    }
}
