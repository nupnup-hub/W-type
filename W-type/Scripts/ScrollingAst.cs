using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingAst : MonoBehaviour
{
    public float speed = -10f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            if(transform.position.y< -100)
            {
                transform.position = new Vector2(transform.position.x  ,350);
            }
            // 초당 speed의 속도로 왼쪽으로 평행 이동
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        }
    }
}
