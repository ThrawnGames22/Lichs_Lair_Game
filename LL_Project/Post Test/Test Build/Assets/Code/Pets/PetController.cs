using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PetController : MonoBehaviour
{
    public Transform Owner;

    public float WithinRange;
    public float speed;
    public float OriginalSpeed;
    public NavMeshAgent navMeshAgent; 
    // Start is called before the first frame update
    void Start()
    {
        // Find player and assign it as owner 
        Owner = GameObject.FindGameObjectWithTag("Player").transform;

        // Find navmesh component on pet object and set its values
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = OriginalSpeed;
        this.transform.position = Owner.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // If there is an owner set their position as the pets destination
        if(Owner != null)
        {
          navMeshAgent.SetDestination(Owner.transform.position);
        }
        
    }
}
