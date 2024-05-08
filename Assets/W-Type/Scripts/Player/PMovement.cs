using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    private float moveSpeed = 20f;
    private PInput playerInput;
    private Rigidbody2D playerRigidbody;
    //1.bottom  2.roof 3.left 4.Rigth
    public GameObject[] wall;
                                                                                                                                                                                                                                                                                        
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PInput>();                                                                                                                                  
        playerRigidbody = GetComponent<Rigidbody2D>();
        Debug.Log("스피드: " + moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        
        float moveDistanceY = playerInput.moveX * moveSpeed * Time.deltaTime;
        float moveDistanceX = playerInput.moveY * (moveSpeed * 1.4f) * Time.deltaTime;
        Vector2 moveDistance = new Vector2(moveDistanceX, moveDistanceY);


        moveDistanceX += playerRigidbody.position.x;
        moveDistanceY += playerRigidbody.position.y;
      
        if (moveDistanceX <= wall[3].transform.position.x && moveDistanceX >= wall[2].transform.position.x
            && moveDistanceY <= wall[1].transform.position.y && moveDistanceY >= wall[0].transform.position.y)
           {
     
            playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
           }
    }
    /*
         private void Move()
    {
            float moveDistanceY = playerInput.moveX * moveSpeed * Time.deltaTime;
            float moveDistanceX = playerInput.moveY * (moveSpeed*1.4f) * Time.deltaTime;
            
          Vector2 moveDistance = new Vector2(moveDistanceX, moveDistanceY);
             moveDistanceX += playerRigidbody.position.x;
             moveDistanceY += playerRigidbody.position.y;

        if (moveDistanceX <= wall[3].transform.position.x && moveDistanceX >= wall[2].transform.position.x 
            && moveDistanceY <= wall[1].transform.position.y && moveDistanceY >= wall[0].transform.position.y)
            {
            Debug.Log("무브 성공!");
                playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
            }
    }*/
}
