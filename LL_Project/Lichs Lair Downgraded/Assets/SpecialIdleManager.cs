using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpecialIdleManager : MonoBehaviour
{
    public bool IsMoving;
    public Animator animator;

    public NavMeshAgent navMeshAgent;
    public float currentVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       animator.SetBool("IsMoving", IsMoving);
       currentVelocity = navMeshAgent.velocity.magnitude;
       if(currentVelocity < 0.1)
       {
        IsMoving = false;
       }

       if(currentVelocity > 0.1)
       {
        IsMoving = true;
       }
    }
}
