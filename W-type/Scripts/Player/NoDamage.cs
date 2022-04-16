using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDamage : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void NoDamageTime(int count)
    {
        if (count < 10)
        {
            if (count % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);
        }
        else
        {
            spriteRenderer.color = new Color32(255, 255, 255, 255);
        }
      
    }
}
