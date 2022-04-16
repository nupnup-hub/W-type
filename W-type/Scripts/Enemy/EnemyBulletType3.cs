using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletType3 : EBulletEntity
{
    private int type3damage = 40;
    private float type3speed = -3.0f;

    private Rigidbody2D bulletRigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
       
        damage = type3damage;
        speed = type3speed;      
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        bulletRigidbody.transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet" || other.tag == "Wall")
        {
            Destroy(gameObject);
            return;
        }

        if (other.tag != "Player")
            return;
        
        Damageable target = other.GetComponent<Damageable>();
        if (other != null)
        {
            target.OnDamage(damage);
        }
        Destroy(gameObject);
    }

    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
    }
}
