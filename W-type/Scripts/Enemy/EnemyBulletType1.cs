using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletType1 : EBulletEntity
{

    private int type1damage = 10;
    private float type1speed = -4.0f;
    private GameObject player;
    private Rigidbody2D bulletRigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        damage = type1damage;
        speed = type1speed;
         
        Destroy(gameObject, 4f);

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
;
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
