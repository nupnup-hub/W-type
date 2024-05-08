using System;
using UnityEngine;

public class PlaneEntity : MonoBehaviour, Damageable
{
    public float startHealth = 100f;
    public float health { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath;


    // Start is called before the first frame update
    protected virtual void OnEnable()
    {
        dead = false;
        health = startHealth;
    }

    // Update is called once per frame
    public virtual void OnDamage(float damage)
    {
        health -= damage;
       // Debug.Log("남은 체력: " + health);
        if (health < 1)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if (onDeath != null)
        {
           onDeath();
        }
        dead = true;
    }

    public virtual void RestoreHealth(float newHealth)
    {
        if (dead)
        {
            return;
        }
        health += newHealth;
    }
}
