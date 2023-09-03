using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSlow : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
       if(other.gameObject.tag == "Player")
       {
        Player.GetComponent<PlayerController>().speed = 2;
       } 
    }

    private void OnTriggerExit(Collider other) 
    {
       if(other.gameObject.tag == "Player")
       {
        Player.GetComponent<PlayerController>().speed = 5;
       } 
    }
}
