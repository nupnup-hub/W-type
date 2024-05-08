using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSpawnerType2 : MonoBehaviour
{
    public GameObject bulletPrefab;

    public void shot()
    {
        // y 초기값 -1.2
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        transform.position = new Vector2(transform.position.x, transform.position.y -0.5f);

        Instantiate(bulletPrefab, transform.position, transform.rotation);
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);

        Instantiate(bulletPrefab, transform.position, transform.rotation);
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f );

        Instantiate(bulletPrefab, transform.position, transform.rotation);
        transform.position = new Vector2(transform.position.x, transform.position.y + 1.5f);

        // bullet.onDeath += () => Destroy(bullet.gameObject);
    }
}
