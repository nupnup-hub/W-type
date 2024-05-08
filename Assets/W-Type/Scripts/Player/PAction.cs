using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAction : MonoBehaviour
{
    public Missile missile;
    private PInput playerInput;
        
    
    // Start is called before the first frame update
    private void Start()
    {
       playerInput = GetComponent<PInput>();
    }

    private void OnEnable()
    {
        missile.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        missile.gameObject.SetActive(false);
    }

    // Update is called once per frame
   private  void Update()
    {
        if(playerInput.fire1)
        {
            missile.Fire();
        }
    }
}
