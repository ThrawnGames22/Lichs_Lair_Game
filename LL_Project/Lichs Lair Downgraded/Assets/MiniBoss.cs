using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniBoss : MonoBehaviour
{
    public float TimeBetweenAttackPhases = 2;
    public float AttackPhase1Time = 5f;
    public float AttackPhase2Time = 9f;
    public float AttackPhase3Time = 10f;



    public float SpinSpeed = 10;
    public float MoveSpeed = 3;

    public NavMeshAgent EnemyAgent;

    public bool IsPhase1;
    public bool IsPhase1isActive;
    public bool IsPhase2isActive;
    public bool IsPhase3isActive;



    public bool IsPhase2;
    public bool IsPhase3;


    public Transform Player;

    public SpinAttackBoss spinAttackBoss;

    public FireBallAttack fireBallAttack;

    public TornadoAttack tornadoAttack;

    public Transform CenterPoint;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpinAttack());
    }

    // Update is called once per frame
    void Update()
    {
        //PHASE 1
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
        
        //PHASE 2

        if(IsPhase2isActive == true)
        {
            fireBallAttack.enabled = true;
           
        }
        if(IsPhase2isActive == false)
        {
            fireBallAttack.StopAllCoroutines();
            StopFireBallCourotine();
            
        }

        if(fireBallAttack.enabled == true)
        {
            EnemyAgent.enabled = false; 
        }

         if(fireBallAttack.enabled == false)
        {
            EnemyAgent.enabled = true; 
        }

        //PHASE 3

        if(IsPhase3isActive == true)
        {
            tornadoAttack.enabled = true;
           
        }
        if(IsPhase3isActive == false)
        {
            tornadoAttack.HasSpawnedTornados = false;
            tornadoAttack.enabled = false;
            
        }

        if(tornadoAttack.enabled == true)
        {
            EnemyAgent.enabled = false; 
        }

         if(tornadoAttack.enabled == false)
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
        
        yield return new WaitForSeconds(AttackPhase1Time);
        StartCoroutine(BreakPhase1());
        

    }

    public IEnumerator BreakPhase1()
    {
        IsPhase1isActive = false;
        IsPhase1 = false;
        StopCoroutine(Phase1());
        StopCoroutine(SpinAttack());
        
        yield return new WaitForSeconds(TimeBetweenAttackPhases);
        StartCoroutine(FireBallAttack());
        

    }

    public IEnumerator FireBallAttack()
    {
    
    yield return new WaitForSeconds(1);
    IsPhase2 = true;
    
    StartCoroutine(Phase2());
    //StopCoroutine(SpinAttack());
    
    }

    public IEnumerator Phase2()
    {
        IsPhase2isActive = true;
        
        yield return new WaitForSeconds(AttackPhase2Time);
        StartCoroutine(BreakPhase2());
        

    }

    public IEnumerator BreakPhase2()
    {
        IsPhase2isActive = false;
        IsPhase2 = false;
        StopCoroutine(Phase2());
        StopCoroutine(FireBallAttack());
        
        yield return new WaitForSeconds(TimeBetweenAttackPhases);
        
        StartCoroutine(TornadoAttack());

    }

    public IEnumerator TornadoAttack()
    {
    
    yield return new WaitForSeconds(1);
    IsPhase3 = true;
    
    StartCoroutine(Phase3());
    //StopCoroutine(SpinAttack());
    
    }

    public IEnumerator Phase3()
    {
        IsPhase3isActive = true;
        
        yield return new WaitForSeconds(AttackPhase3Time);
        StartCoroutine(BreakPhase3());
        

    }

    public IEnumerator BreakPhase3()
    {
        IsPhase3isActive = false;
        IsPhase3 = false;
        StopCoroutine(Phase2());
        StopCoroutine(TornadoAttack());
        
        yield return new WaitForSeconds(TimeBetweenAttackPhases);
        StartAgain();
        

    }

    public void StopFireBallCourotine()
    {
        fireBallAttack.enabled = false;
    }

    public void StartAgain()
    {
        StopAllCoroutines();
        StartCoroutine(SpinAttack());
    }
}
