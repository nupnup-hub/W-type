using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{
    public ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("particle start");
        dust.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
