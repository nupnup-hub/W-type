using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnerType2left : MonoBehaviour
{

    public GameObject bulletPrefab;

    public void shot()
    {
        Vector2 secondAttack = new Vector2(transform.position.x, transform.position.y);
        secondAttack.x -= 0.2f;
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, secondAttack, transform.rotation);
       // yield return new WaitForSeconds(2.5f);
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        Instantiate(bulletPrefab, secondAttack, transform.rotation);
        // bullet.onDeath += () => Destroy(bullet.gameObject);
    }
}
