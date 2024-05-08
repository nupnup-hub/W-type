using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    // Start is called before the first frame update
    private void Start()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.y;
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.y <= -width)
        {
            Reposition();
        }
    }
    private void Reposition()
    {
        Vector2 offset = new Vector2(0, width * 2);
        transform.position = (Vector2)transform.position + offset;
    }
}
