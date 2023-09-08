using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniBoss : MonoBehaviour
{
    public float TimeBetweenAttackPhases = 2;
    public float AttackPhaseTime = 5f;

    public float SpinSpeed = 10;
    public float MoveSpeed = 3;

    public NavMeshAgent EnemyAgent;

    public bool IsPhase1;
    public bool IsPhase1isActive;

    public bool IsPhase2;
    public bool IsPhase3;


    public Transform Player;

    public SpinAttackBoss spinAttackBoss;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpinAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Rotate(0,0,20 * SpinSpeed * Time.deltaTime);
        if(IsPhase1isActive == true)
        {
            spinAttackBoss.enabled = true;
           
        }
        if(IsPhase1isActive == false)
        {
            spinAttackBoss.enabled = false;
        }

        if(spinAttackBoss.enabled == true)
        {
            EnemyAgent.enabled = false; 
        }

         if(spinAttackBoss.enabled == false)
        {
            EnemyAgent.enabled = true; 
        }

        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    //PHASEROTATION1
    public IEnumerator SpinAttack()
    {
    
    yield return new WaitForSeconds(TimeBetweenAttackPhases);
    IsPhase1 = true;
    
    StartCoroutine(Phase1());
    //StopCoroutine(SpinAttack());
    
    }

    public IEnumerator Phase1()
    {
        IsPhase1isActive = true;
        
        yield return new WaitForSeconds(TimeBetweenAttackPhases);
        StartCoroutine(BreakPhase1());
        

    }

    public IEnumerator BreakPhase1()
    {
        IsPhase1isActive = false;
        IsPhase1 = false;
        StopCoroutine(Phase1());
        StopCoroutine(SpinAttack());
        
        yield return new WaitForSeconds(AttackPhaseTime);
        

    }
}
