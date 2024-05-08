using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EBulletEntity : MonoBehaviour, Damageable
{
    public int damage { get; protected set; }
    public float speed { get; protected set; }
    public float health { get; protected set; }
    public bool dead { get; protected set; }
    public int nomalBulletHp = 5;
    
    protected virtual void OnEnable()
    {
        damage = 0;
        speed =0;
        dead = false;
        health = nomalBulletHp;
    }

    public virtual void OnDamage(float damage)
    {
        health -= damage;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
