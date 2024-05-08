using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject[] wall;
    public GameObject wave;
    private bool setOn;
    // Start is called before the first frame update
    //1 . roof  2. bottom 3. left 4 right
    private void Start()
    {
        setOn = false;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall" && setOn==false)
        {
            wave.SetActive(true);
            setOn = true;
            Destroy(gameObject, 40f);
        }
    }
}
