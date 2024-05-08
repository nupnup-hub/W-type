using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingStars : MonoBehaviour
{
    private float speed = -50.0f;

    
    private void Update()
    {
        if (transform.position.y < -30f)
            transform.position = new Vector2(transform.position.x , 200);

        transform.Translate(new Vector2(0, speed) * Time.deltaTime);
    }
}
