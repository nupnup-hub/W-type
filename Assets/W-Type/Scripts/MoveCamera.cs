using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 50f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 3600)
           {
            speed = -50f;
          }
        if(transform.position.x < 500)
        {
            speed = 50f;
        }
            // 초당 speed의 속도로 왼쪽으로 평행 이동
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        
    }
}
