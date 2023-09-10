using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoBossManager : MonoBehaviour
{
    public GameObject PullOBJ;
    public int DamageToApplyToPlayer = 5;

    public float PullSpeed;

    

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            PullOBJ = other.gameObject;

            PullOBJ.transform.position = Vector3.MoveTowards(PullOBJ.transform.position, this.transform.position, PullSpeed * Time.deltaTime);

            
            other.GetComponent<PlayerHealth>().StartCoroutine(other.GetComponent<EnemyHealth>().DecreaseHealth(DamageToApplyToPlayer));
            //PullOBJ.GetComponent<FireParticles>().TurnFireOn();
        }
        
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            //PullOBJ.GetComponent<EnemyHealth>().StopCoroutine(PullOBJ.GetComponent<EnemyHealth>().DecreaseHealth(DamageToApplyToEnemies));
            //PullOBJ.GetComponent<FireParticles>().TurnFireOff();

            other.GetComponent<PlayerHealth>().StopCoroutine(other.GetComponent<EnemyHealth>().DecreaseHealth(DamageToApplyToPlayer));
        }
              
    }
}
      
