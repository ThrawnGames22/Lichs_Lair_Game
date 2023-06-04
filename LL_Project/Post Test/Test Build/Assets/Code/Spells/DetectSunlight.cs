using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectSunlight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If enemy detects the sunlight spell, slow this objects speed
         if(GameObject.Find("Sunlight") == null)
        {
            
                this.GetComponent<NavMeshAgent>().speed = this.GetComponent<EnemyController>().OriginalSpeed;
            
        }
    }
}
