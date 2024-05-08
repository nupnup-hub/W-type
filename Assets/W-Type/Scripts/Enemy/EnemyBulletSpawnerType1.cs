
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnerType1 : MonoBehaviour
{

    public GameObject bulletPrefab;

    public void shot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
       // bullet.onDeath += () => Destroy(bullet.gameObject);
    }
}

