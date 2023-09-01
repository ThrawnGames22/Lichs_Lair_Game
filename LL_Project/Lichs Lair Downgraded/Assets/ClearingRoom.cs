using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearingRoom : MonoBehaviour
{
    public bool PlayerIsInTrigger;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other) 
    {
       if(other.gameObject.tag == "Player")
       {
         
         PlayerIsInTrigger = true;
       } 

       
    }

    private void OnTriggerExit(Collider other) 
    {
       if(other.gameObject.tag == "Player")
       {
         
         PlayerIsInTrigger = false;
       }  
    }
}
