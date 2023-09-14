using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEditor.UIElements;
using UnityEngine.AI;

public class TornadoManager : MonoBehaviour
{
    public GameObject PullOBJ;
    public int DamageToApplyToEnemies = 5;

    public float PullSpeed;

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            PullOBJ = other.gameObject;

            PullOBJ.transform.position = Vector3.MoveTowards(PullOBJ.transform.position, this.transform.position, PullSpeed * Time.deltaTime);

            
            PullOBJ.GetComponent<EnemyHealth>().StartCoroutine(PullOBJ.GetComponent<EnemyHealth>().DecreaseHealth(DamageToApplyToEnemies));
            PullOBJ.GetComponent<FireParticles>().TurnFireOn();
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            PullOBJ.GetComponent<EnemyHealth>().StopCoroutine(PullOBJ.GetComponent<EnemyHealth>().DecreaseHealth(DamageToApplyToEnemies));
            PullOBJ.GetComponent<FireParticles>().TurnFireOff();
        }
              
    }
        
    
}
