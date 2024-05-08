using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParts : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Attacked()
    {
        StartCoroutine(AttackedEffect());
    }
    private IEnumerator AttackedEffect()
    {
        int count = 0;
        while (count++ < 4)
        {
            if (count % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);
    }
}
