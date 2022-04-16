using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyType3 : PlaneEntity
{

    public float speed = -4.5f;
    private float timeBetAttack = 3.0f;
    public EnemyBulletSpawnerType3[] eBulletSpawnerType3;

    private Rigidbody2D EnemyRigidBody;
    private float lastAttackTime;
    private SpriteRenderer spriteRenderer;
    private int score = 700;
    // Start is called before the first frame update
    public ParticleSystem bomb;
    private bool moveUp;
    private void Awake()
    {
        EnemyRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 무브조건문
    }
    private void Start()
    {
        // 무브조건문
        health = 4000;
        moveUp = false;
       // stop = false;
        Destroy(gameObject, 40f);
        StartCoroutine(Movement());
    }
    private void Update()
    {
        if (!dead)
        {
            EnemyRigidBody.transform.Translate(new Vector2(0, speed * Time.deltaTime * 0.05f) );

            if (Time.time >= lastAttackTime + timeBetAttack)
            {
                eBulletSpawnerType3[0].shot();
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
        StartCoroutine(DieEffect());
        base.Die();

        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }
        
        //UIManager.instance.UpdateScoreText(100);
    }

    // 플레이어 추적
    private IEnumerator Movement()
    { 
        while (!dead)
        {
            yield return new WaitForSeconds(4f);
            int count = 0;
            while (count++ < 32)
            {
                EnemyRigidBody.transform.Translate(new Vector3(Time.deltaTime * speed,0));
                yield return new WaitForSeconds(0.05f);
            }
            count = 0;
            while (count++ < 64)
            {
                EnemyRigidBody.transform.Translate(new Vector3(-Time.deltaTime * speed, 0));
                yield return new WaitForSeconds(0.05f);
            }
            count = 0;
            while (count++ < 32)
            {
                EnemyRigidBody.transform.Translate(new Vector3(Time.deltaTime * speed, 0));
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    private IEnumerator AttackedEffect()
    {
        if (!moveUp)
        {
            speed *= -3.5f;
            moveUp = true;
        }
        int count = 0;
        //Debug.Log("피격!");
        while (count++ < 10)
        {
            if (count % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 120);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.1f);
        }
          spriteRenderer.color = new Color32(255, 255, 255, 255);
       
    }

    private IEnumerator DieEffect()
    {
        bomb.Play();
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.AddScore(score);
        GameManager.instance.AddScore(score);
        StopCoroutine(AttackedEffect());
        StopCoroutine(Movement());
        Destroy(gameObject);
    }
}