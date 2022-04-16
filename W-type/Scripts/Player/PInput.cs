using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PInput : MonoBehaviour
{
    public string moveAxisName = "Horizontal";  
    public string moveAyisName = "Vertical";
    public string NomalFire = "Fire1";
    public string SkilFire = "Fire2";

    public float moveX { get; private set; }
    public float moveY { get; private set; }
    public bool fire1 { get; private set; }
    public bool fire2 { get; private set; }
    public bool exit { get; private set; }

    void Start()
    {
        moveX = 0;
        moveY = 0;
        fire1 = false;
        fire2 = false;
        exit = false;
        return;
    }
    // Update is called once per frame
    void Update()
    {
        /*if(GameManager.instance != null && GameManager.instance.isGameover)
        {
            moveX = 0;
            moveY = 0;
            fire1 = false;
            fire2 = false;
            return;
        }
        */
        moveX = Input.GetAxis(moveAxisName);
        moveY = Input.GetAxis(moveAyisName);
        fire1 = Input.GetButton(NomalFire);
        fire2 = Input.GetButton(SkilFire);
        exit = Input.GetKeyDown(KeyCode.Escape);

        if(exit)
        {
            Application.Quit();
        }
    }
}
