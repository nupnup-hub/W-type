using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletType2 : EBulletEntity
{
    private int type2damage = 30;
    private float type2speed = -5.0f;
    private GameObject player;
    private Rigidbody2D bulletRigidbody;
   

    // Start is called before the first frame update
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
      
    }
    private void Start()
    {
        Vector3 dir = bulletRigidbody.transform.position - player.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bulletRigidbody.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        
        health = 1;
        damage = type2damage;
        speed = type2speed;
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
