using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawnerType3 : MonoBehaviour
{

    public GameObject bulletPrefab;

    public void shot()
    { 
        StartCoroutine(attack());
    }
   private IEnumerator attack()
    {
        
        transform.Rotate(0, 0, 90.0f);
        for (int i = 0; i < 20; i++)
        {
            transform.Rotate(0, 0, 9.0f);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }

        transform.Rotate(0, 0, 90.0f);
        yield return new WaitForSeconds(0.5f);
        transform.Rotate(0, 0, 90.0f);
        for (int i = 0; i < 20; i++)
        {
            transform.Rotate(0, 0, 9.0f);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }

        transform.Rotate(0, 0, 90.0f);

    }
}
