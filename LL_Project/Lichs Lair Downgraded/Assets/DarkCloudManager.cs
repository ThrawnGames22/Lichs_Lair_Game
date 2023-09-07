using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCloudManager : MonoBehaviour
{
    public GameObject PullOBJ;
    

    public float PullSpeed;

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            PullOBJ = other.gameObject;

            PullOBJ.transform.position = Vector3.MoveTowards(PullOBJ.transform.position, this.transform.position, PullSpeed * Time.deltaTime);

            
            
            //PullOBJ.GetComponent<FireParticles>().TurnFireOn();
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            
            //PullOBJ.GetComponent<FireParticles>().TurnFireOff();
        }
              
    }
}
