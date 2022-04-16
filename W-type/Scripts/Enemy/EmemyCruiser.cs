using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyCruiser : PlaneEntity
{ 
    private Rigidbody2D EnemyRigidBody;
    public float speed = 1.2f;
    public float timeBetAttack = 1.5f;
    private float lastAttackTime;
    private float lifeTime;
    private float limitTime = 40f;
    // 1. left 2. right
    public GameObject[] wall;
     private SpriteRenderer spriteRenderer;
    public EnemyBulletSpawnerType2left[] eBulletSpawnerType2left;
    public EnemyBulletSpawnerType2right[] eBulletSpawnerType2right;
    public EnemyBulletSpawnerType2side[] eBulletSpawnerType2side;
    public GameObject hpPack;
    private int score = 500;
    public ParticleSystem bomb;

    // Start is called before the first frame update

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EnemyRigidBody = GetComponent<Rigidbody2D>();    
    }
    private void Start()
    {
        lifeTime = Time.time;
        startHealth = 2500;
    }

    private void Update()
    {
        if (!dead )
        {
            if (Time.time >= lastAttackTime + timeBetAttack)
            {
                eBulletSpawnerType2left[0].shot();
                eBulletSpawnerType2right[0].shot();
                for (int i = 0; i < eBulletSpawnerType2side.Length; i++)
                    eBulletSpawnerType2side[i].shot();
                lastAttackTime = Time.time;
            }
        }

        if(Time.time > lifeTime + limitTime)
        {
            dead = true;
            StartCoroutine(MoveToWall());
            // 벽에서 5만큼 떨어지면 삭제
            if (transform.position.x < wall[0].transform.position.x - 5  || transform.position.x  > wall[1].transform.position.x + 5) 
            {
                Die();
            }
        }
    }
    public override void OnDamage(float damage)
    {
        // Debug.Log("onDamage");
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

    public IEnumerator MoveToWall()
    {
        if (transform.position.x - wall[0].transform.position.x > wall[1].transform.position.x - transform.position.x)
        {
            EnemyRigidBody.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }                                           
        else
        { 
           EnemyRigidBody.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }
        yield return new WaitForSeconds(1f);
        
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
    private IEnumerator DieEffect()
    {
        bomb.Play();
        yield return new WaitForSeconds(0.5f);
        float dropItem = Random.Range(0.0f, 0.9f);
        if (dropItem > 0.5)
            Instantiate(hpPack, transform.position, transform.rotation);
        GameManager.instance.AddScore(score);
        StopCoroutine(AttackedEffect());
        StopCoroutine(MoveToWall());
        Destroy(gameObject);
    }
}
