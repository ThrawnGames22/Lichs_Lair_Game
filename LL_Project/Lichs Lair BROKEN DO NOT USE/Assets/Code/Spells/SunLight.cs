using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SunLight : MonoBehaviour
{
    public GameObject SunParticlesToAttach;
    public GameObject[] Enemies;
    public int SlowedSpeed;
    public bool HasSpawned;
    // Start is called before the first frame update
    void Start()
    {
      Enemies = GameObject.FindGameObjectsWithTag("Enemy");
      HasSpawned = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach(GameObject Enemy in Enemies)
            {
                
                if(!HasSpawned)
                {
                    
                    AttachParticles();
                    HasSpawned = true;
                    
                }

                
            }
        if(this.gameObject.active)
        {
            
            foreach(GameObject Enemy in Enemies)
            {
                Enemy.GetComponent<NavMeshAgent>().speed = SlowedSpeed;
                
            }
        }
        else
        {
            foreach(GameObject Enemy in Enemies)
            {
                Enemy.GetComponent<EnemyController>().speed = Enemy.GetComponent<EnemyController>().OriginalSpeed;
            }
        }
        
       
    }

    public void AttachParticles()
    {
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = -90;
            foreach(GameObject Enemy in Enemies)
            {
                GameObject clone;
                clone = Instantiate(SunParticlesToAttach, Enemy.transform.position, Enemy.transform.rotation);
                clone.transform.parent = Enemy.transform;
                clone.transform.rotation = Quaternion.Euler(rotationVector);
                
            }
    }

    

    
}
