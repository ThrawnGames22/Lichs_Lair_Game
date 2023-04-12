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
        Owner = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = OriginalSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(Owner.transform.position);
    }
}
