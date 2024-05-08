using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 300f;
    private int damage = 40;
   
    private Rigidbody2D bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(new Vector2(0, speed));
        //bulletRigidbody.velocity *= transform.forward;

        Destroy(gameObject, 4f);
    }

   void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Wall")
            Destroy(gameObject);
        if (other.tag != "Enemy" && other.tag != "EnemyBullet")
            return;
       
        Damageable target = other.GetComponent<Damageable>();
        if (other != null)
        {
            target.OnDamage(damage);
        }
        Destroy(gameObject);
    }
  
}
