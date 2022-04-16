using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 1f;
    public bool stop;
    // Update is called once per frame
    void Enable()
    {
        stop = false;
    }
    void Update()
    {
        if (!GameManager.instance.isGameover && !stop)
        {
            // 초당 speed의 속도로 왼쪽으로 평행 이동
            transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (transform.position.y <= -144f)
                stop = true;
        }
    }
}
