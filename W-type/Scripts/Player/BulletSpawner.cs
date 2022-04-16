using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
   
    public GameObject bulletPrefab;
    
   public void shot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
