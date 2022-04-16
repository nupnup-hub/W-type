using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : PlaneEntity
{
  //  public GameObject player;
    private float speed = -1.0f;
    private int atkPattern;
    private float timeBetAttack = 3.0f;
    private float lastAttackTime;
    private float bossHp = 20000;
    private int score = 10000;
    public BossBulletSpawnerType1[] BBulletSpawnerType1;
    public BossBulletSpawnerType2[] BBulletSpawnerType2;
    public BossBulletSpawnerType3[] BBulletSpawnerType3;
    public GameObject wave;

    private Rigidbody2D EnemyRigidBody;
    public BossParts[] parts;
    public ParticleSystem bomb;
    private SpriteRenderer spriteRenderer;
    public ScrollingObject scrollingObject;
    private bool setOn = false;
    private void Awake()
    {
        EnemyRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        // 무브조건문
        health = bossHp;
        atkPattern = 0;
    }
  

    private void Update()
    {
        if (Time.time >= lastAttackTime + timeBetAttack && setOn)
        {
            StartCoroutine(Attack());
            lastAttackTime = Time.time;
        }
        if (scrollingObject.stop )
            setOn = true;
    }
    public override void OnDamage(float damage)
    {
        if (!setOn)
            return;
        base.OnDamage(damage);
        for (int i = 0; i < 3; i++)
            parts[i].Attacked();
        StartCoroutine(AttackedEffect());
    }

    public override void Die()
    {
        StartCoroutine(DieEffect());
        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }
    }

    private IEnumerator AttackedEffect()
    {
        int count = 0;
        while (count++ < 4)
        {
            if (count % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);
    }

    // 플레이어 추적
    private IEnumerator Attack()
    {
       
            atkPattern=Random.Range(0, 3);
            
            if (atkPattern == 0)
            {
                BBulletSpawnerType1[0].shot();
                yield return new WaitForSeconds(0.5f);
                BBulletSpawnerType1[1].shot();
                yield return new WaitForSeconds(2.0f);
                BBulletSpawnerType1[0].shot();
                yield return new WaitForSeconds(0.5f);
                BBulletSpawnerType1[1].shot();
                yield return new WaitForSeconds(5.0f);
            }
              if (atkPattern == 1)
              {
            
                while (transform.position.x > -8f)
                {
                    EnemyRigidBody.transform.Translate(new Vector2(5f * 0.01f, 0));
                    if(transform.position.x > -6f)
                       EnemyRigidBody.AddForce(new Vector2(100f, 0));
                    yield return new WaitForSeconds(0.01f);
                }
                BBulletSpawnerType2[0].shot();
                BBulletSpawnerType2[1].shot();
               

                while (transform.position.x < 0)
                {
                    EnemyRigidBody.transform.Translate(new Vector2(-5f * 0.01f, 0));
                    yield return new WaitForSeconds(0.01f);
                }
                BBulletSpawnerType2[0].shot();
                BBulletSpawnerType2[1].shot();
             
                while (transform.position.x < 8f)
                {
                    EnemyRigidBody.transform.Translate(new Vector2(-5f * 0.01f, 0));
                   yield return new WaitForSeconds(0.01f);
                 }
                 BBulletSpawnerType2[0].shot();
                 BBulletSpawnerType2[1].shot();
                 

                while (transform.position.x > 0)
                {
                    EnemyRigidBody.transform.Translate(new Vector2(5f * 0.01f, 0));
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(1.0f);
            }

            if (atkPattern == 2)
            {
                BBulletSpawnerType2[0].shot();
                BBulletSpawnerType2[1].shot();
                yield return new WaitForSeconds(2.5f);
                BBulletSpawnerType2[0].shot();
                BBulletSpawnerType2[1].shot();
                yield return new WaitForSeconds(2.5f); 
                BBulletSpawnerType2[0].shot();
                BBulletSpawnerType2[1].shot();
               yield return new WaitForSeconds(3f);  
            }

            // 구현x
            if (atkPattern == 3)
            {
                BBulletSpawnerType3[0].shot();
                BBulletSpawnerType3[1].shot();
                yield return new WaitForSeconds(8f);
            }
        
    }

    private IEnumerator DieEffect()
    {
        bomb.Play();
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.AddScore(score);
        GameManager.instance.AddScore(score);
        StopCoroutine(Attack());
        StopCoroutine(AttackedEffect());
        base.Die();
        Destroy(gameObject);
     }
}