using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty
    }

    public State state { get; private set; }
    public ParticleSystem shotEffect;

    //public float damage = 40;
    public int level = 1;
    public BulletSpawner[] bulletSpawner;
    public float timeBetFire = 0.25f;
    private float lastFireTime;
    private void Awake()
    {
        //오디오는 시간있으면 추가
    }

    private void OnEnable()
    {
        state = State.Ready;
        lastFireTime = 0;
        level = 1;
    }

    public void Fire()
    {
        if (state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
    }

    private void Shot()
    {
        StartCoroutine(ShotEffect());
        if(level >=1 )
        {
            bulletSpawner[0].shot();
            bulletSpawner[1].shot();
            bulletSpawner[2].shot();
            bulletSpawner[3].shot();
            if (level == 2)
            {
                bulletSpawner[4].shot();
                bulletSpawner[5].shot();
                bulletSpawner[6].shot();
                bulletSpawner[7].shot();
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        shotEffect.Play();
        yield return new WaitForSeconds(0.03f);
    }
}
