using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHpPack : MonoBehaviour, Item
{
    private float health = 50;
    private float speedX = 2.5f;
    private float speedY = -1.5f;
    private Rigidbody2D hpPaceRigidbody;
    private int turn = 0;   
    // Start is called before the first frame update
    private void Start()
    {
        hpPaceRigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 20f);
    }
    private void Update()
    {  
        hpPaceRigidbody.transform.Translate(new Vector3(speedX, speedY, 0) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
           
            if(turn%2 == 0)
            {
                speedX *= -1f;
                speedY *= 1f;
            } 
            else
            {
                speedX *= 1f;
                speedY *= -1f;
            }
                turn++;
        }

        if (other.tag != "Player")
        {
            return;
        }   
    }



    public void Use(GameObject target)
    {
        PlaneEntity life = target.GetComponent<PlaneEntity>();
        if (life != null)
        {
            life.RestoreHealth(health);
        }
        Destroy(gameObject);
    }
}
