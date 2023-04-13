using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using UnityEngine.UI;

public enum EnemyType
{
        Zombie,
        DeathKnight,
        Imp
}
[System.Serializable]
public class EnemyController : MonoBehaviour
{
    
    public EnemyType enemyType;
    public GameObject target;
    public float RangeToPlayer;
    public float currentDistance;
    public float speed;
    public float OriginalSpeed;
    public NavMeshAgent navMeshAgent; 
    public int DamageToApply;
    public bool CanApplyDamageToPlayer;
    public float AttackDelay = 0.3f;
    public float rotationDamping = 2f;
        
    public bool AttackBlocked = false;
    public GameObject FistObject;

    //Animation
    public Animator EnemyAnimator;

    //public EnemyType enemyType;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = OriginalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
      //var lookPos = target.transform.position - transform.position;
      //lookPos.y = 0;
      //var Rotation = Quaternion.LookRotation(lookPos);
      //transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * rotationDamping);

      currentDistance = Vector3.Distance(target.transform.position, transform.position);
      navMeshAgent.SetDestination(target.transform.position);

      if(currentDistance < 2 )
      {
        AttackPlayer();
      }
      else
      {
        StopAttack();
      }
      
    }
   /*
    private void OnCollisionEnter(Collision col)
    {
      if(col.gameObject.tag == "Player")
      {
        Debug.Log("EnemyHasHit");
        col.gameObject.GetComponent<PlayerHealth>().TakeDamage(DamageToApply);
      }
    }
    */

    public void ResetSpeed()
    {
      navMeshAgent.speed = OriginalSpeed;
    }

    

    public void AttackPlayer()
    {
      if(AttackBlocked)
        {
            return;
        }
      EnemyAnimator.SetTrigger("Attack");
      AttackBlocked = true;
      StartCoroutine(DelayAttack());
      

    }

    public void StopAttack()
    {
      StopCoroutine(DelayAttack());
    }

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(AttackDelay);
        AttackBlocked = false;
    }


}

[CustomEditor(typeof(EnemyController))]
public class EnemyControllerEditor : Editor
{
    
    EnemyController EC;

    void ForceSerialization()
    {
      #if UNITY_EDITOR
          UnityEditor.EditorUtility.SetDirty(this);
      #endif
    }

    void OnEnable()
    {
        EC =(EnemyController)target;
        
    }


    public override void OnInspectorGUI()
    {
        ForceSerialization();
        EditorUtility.SetDirty(target);
        EC.enemyType = (EnemyType)EditorGUILayout.EnumPopup("EnemyType", EC.enemyType);

        switch(EC.enemyType)
        {
          case EnemyType.Zombie:
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.EnemyAnimator = (Animator)EditorGUILayout.ObjectField("Enemy Animator", EC.EnemyAnimator, typeof(Animator), true);
          EC.FistObject = (GameObject)EditorGUILayout.ObjectField("Fist Object", EC.FistObject, typeof(GameObject), true);


          EC.RangeToPlayer = EditorGUILayout.FloatField("Range To Player", EC.RangeToPlayer);
          EC.currentDistance = EditorGUILayout.FloatField("Current Distance", EC.currentDistance);

          EC.speed = EditorGUILayout.FloatField("Speed", EC.RangeToPlayer);
          EC.OriginalSpeed = EditorGUILayout.FloatField("Original Speed", EC.OriginalSpeed);

          EC.DamageToApply = EditorGUILayout.IntField("Damage To Apply", EC.DamageToApply);
          EC.DamageToApply = 5;
          
          //EC.navMeshAgent.speed = EC.speed;

          break;

          case EnemyType.DeathKnight:
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.EnemyAnimator = (Animator)EditorGUILayout.ObjectField("Enemy Animator", EC.EnemyAnimator, typeof(Animator), true);
          EC.RangeToPlayer = EditorGUILayout.FloatField("Range To Player", EC.RangeToPlayer);
          EC.currentDistance = EditorGUILayout.FloatField("Current Distance", EC.currentDistance);
          EC.speed = EditorGUILayout.FloatField("Speed", EC.speed);
          EC.DamageToApply = EditorGUILayout.IntField("Damage To Apply", EC.DamageToApply);

          
          //EC.navMeshAgent.speed = EC.speed;

          break;

          case EnemyType.Imp:
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.EnemyAnimator = (Animator)EditorGUILayout.ObjectField("Enemy Animator", EC.EnemyAnimator, typeof(Animator), true);
          EC.RangeToPlayer = EditorGUILayout.FloatField("Range To Player", EC.RangeToPlayer);
          EC.currentDistance = EditorGUILayout.FloatField("Current Distance", EC.currentDistance);
          EC.speed = EditorGUILayout.FloatField("Speed", EC.speed);
          EC.DamageToApply = EditorGUILayout.IntField("Damage To Apply", EC.DamageToApply);

          
          //EC.navMeshAgent.speed = EC.speed;

          break;
        }
    }






}
