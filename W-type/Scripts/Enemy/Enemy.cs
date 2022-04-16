using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : PlaneEntity
{
    public GameObject player;
    public float speed = -1.0f;
    public int movePattern;
    public float timeBetAttack = 3.0f;
    public EnemyBulletSpawnerType1[] eBulletSpawnerType1;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D EnemyRigidBody;
    private float lastAttackTime;
    private bool stop;
    private int explosionDamage = 40;
    private int score = 100;
    public ParticleSystem bomb;

    // Start is called before the first frame update

    private void Awake()
    {
        EnemyRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //onDeath += GameManager.instance.AddScore(score);
        // 무브조건문
    }
    private void Start()
    {
        // 무브조건문
        health = 300;
        stop = false;
        StartCoroutine(Movement());
        Destroy(gameObject, 40f);
    }
    private void Update()
    {
        if(!dead)
        {
            if (movePattern == 3)
            {
                EnemyRigidBody.transform.Translate(new Vector3( speed * Time.deltaTime, 0.6f * Time.deltaTime, 0));
                if (EnemyRigidBody.transform.position.x < -12)
                {
                    EnemyRigidBody.transform.position = new Vector2(12, transform.position.y);
                }
            }
            else if (movePattern == 2)
            { 
                  EnemyRigidBody.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            if (Time.time >= lastAttackTime + timeBetAttack)
            {
                eBulletSpawnerType1[0].shot();
                eBulletSpawnerType1[1].shot();
                lastAttackTime = Time.time;
            }
        }
    }
    public override void OnDamage(float damage)
    {
       //  Debug.Log("onDamage");
        base.OnDamage(damage);
        StartCoroutine(AttackedEffect());
    }

    public override void Die()
    {
        StartCoroutine(DieEffect(0.5f));
        base.Die();       
        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }
        //UIManager.instance.UpdateScoreText(100);
    }

    private IEnumerator AttackedEffect()
    {
        int count = 0;

        while (count++ < 4)
        {
            if (count % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);
    }
    // 플레이어 추적
    private IEnumerator Movement()
    {
        while (!dead && movePattern == 1)
        {
            
            Vector3 dir = EnemyRigidBody.transform.position - player.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            EnemyRigidBody.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            int count = 0;
            while (count != 60)
            {
                count++;
                EnemyRigidBody.transform.Translate(new Vector3(0, speed * 0.01f, 0));
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(1.0f);
        }
        while (!dead && movePattern == 2)
        {
            yield return new WaitForSeconds(0.6f);
        }
        while(!dead && movePattern == 3)
        {
            yield return new WaitForSeconds(0.6f);
        }
    }
    private IEnumerator DieEffect(float dieTime)
    {
        bomb.Play();
        yield return new WaitForSeconds(dieTime);
        StopCoroutine(AttackedEffect());
        StopCoroutine(Movement());
        Destroy(gameObject);
        GameManager.instance.AddScore(score);
        GameManager.instance.AddScore(score);
    }
    // 아래로 이동
    /* public void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.tag == "Player")
         {
             Damageable target = other.gameObject.GetComponent<Damageable>();
             if (other != null)
             {
                 target.OnDamage(explosionDamage);
             }
             Destroy(gameObject);
         }

     }
     */
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall" && movePattern == 2)
        {
            speed = -0.25f;
        }
        if (other.tag == "Player")
        {       
            Damageable target = other.GetComponent<Damageable>();
            StartCoroutine(DieEffect(0.25f));
            if (other != null)
            {
                target.OnDamage(explosionDamage);
            }         
        }
    }
}