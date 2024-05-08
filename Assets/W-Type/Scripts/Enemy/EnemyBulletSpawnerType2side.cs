using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnerType2side : MonoBehaviour
{

    public GameObject bulletPrefab;

    public void shot()
    {
        Vector2 secondAttack = new Vector2(transform.position.x , transform.position.y);
        secondAttack.y -= 0.2f;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, secondAttack, transform.rotation);
        // bullet.onDeath += () => Destroy(bullet.gameObject);
    }
}
