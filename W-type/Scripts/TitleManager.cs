using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class TitleManager : MonoBehaviour
{
    private float time = 0.5f;
    public bool exit { get; private set; }
    // Update is called once per frame
    private void Start()
    {
         
     
    }
    private void Update()
    {
        if(Time.time > time)
            if (Input.anyKey)
                SceneManager.LoadScene("Play");

        exit = Input.GetKeyDown(KeyCode.Escape);
        if (exit)
        {
            Application.Quit();
        }
    }
}
