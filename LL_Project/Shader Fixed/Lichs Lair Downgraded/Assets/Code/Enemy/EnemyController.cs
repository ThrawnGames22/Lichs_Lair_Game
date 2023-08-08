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
        Imp,
        Tank
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


    public bool IsAgitated;
    public Transform ReturnPosition;

    public int OriginalDamageToApply;
    public bool CanApplyDamageToPlayer;
    public float AttackDelay = 0.3f;
    public float rotationDamping = 2f;
        
    public bool AttackBlocked = false;
    public GameObject FistObject;
    public bool IsPatrolling;

    public float minDistance;
    public float DistanceToStartAnimation;
    public float maxDistance;
    public bool IsHitFirst;

    //Animation
    public Animator EnemyAnimator;

    //Patrol Pathfinding
    
    public GameObject[] patrolPoints;
    private int currentPoint;

    //public EnemyType enemyType;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        navMeshAgent.speed = OriginalSpeed;
        
        
        if(IsPatrolling == false)
        {
          navMeshAgent.destination = ReturnPosition.position;
          navMeshAgent.stoppingDistance = 2;
        }

        if(IsPatrolling == true)
        {
          navMeshAgent.destination = patrolPoints[currentPoint].transform.position;
          currentPoint = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
      //currentDistance = Vector3.Distance(target.transform.position, transform.position);

      if(target.GetComponent<PlayerController>().DamageNegationActive == false)
      {
        ResetDamage();
      }
      //var lookPos = target.transform.position - transform.position;
      //lookPos.y = 0;
      //var Rotation = Quaternion.LookRotation(lookPos);
      //transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * rotationDamping);
     if(target != null)
     {
       currentDistance = Vector3.Distance(target.transform.position, transform.position);
       //navMeshAgent.SetDestination(target.transform.position);
     }
      

      //If Enemy's current distance is less than distance to attack, then chase player
      if(currentDistance < DistanceToStartAnimation)
      {
        FindPlayer();
      }

      // If Enemy isn't hit by a spell before player aproaching and less than the range of Agitation, then Agro the Enemy and make the enemy constantly chase the player.
      if(IsHitFirst == false)
      {
      if(currentDistance < minDistance )
      {
        IsAgitated = true;
        minDistance = 100f;
        
        
      }
      }

      // If Enemy isn't hit by a spell before player aproaching and is Greater than Agro Range, Do not agitate Enemy
      if(IsHitFirst == false)
      {
      if(currentDistance > minDistance)
      {
        
        IsAgitated = false;
      }
      }

      // If Enemy is hit by a spell before player aproaching, Agro the Enemy and make the enemy constantly chase the player.

      if(IsHitFirst == true)
      {
        IsAgitated = true;
        minDistance = 100f;
      }
      
      // Animation Events 
      if(currentDistance > DistanceToStartAnimation)
      {
        StopAttack();
      }

      
      if(currentDistance < DistanceToStartAnimation)
      {
        AttackPlayer();
      }

      // If Enemy is Agro and Has Patrol Path
      if(IsAgitated == true)
      {
        
        StopIteration();
        navMeshAgent.stoppingDistance = 2;
      }
      
      
      // If Enemy Range is Less than player, cancel Agro

      if(currentDistance > maxDistance)
      {
        
        IsAgitated = false;
       
        if(IsPatrolling == false)
        {
          if(ReturnPosition != null)
          {
          navMeshAgent.destination = ReturnPosition.position;
          }
          navMeshAgent.stoppingDistance = 2;
        }
       
      }

       
      // If Enemy Has a patrol path and is not agitated, resume pathing

      if(IsPatrolling == true)
      {
       if(IsAgitated == false)
       {
        navMeshAgent.stoppingDistance = 0;
       if(Vector3.Distance(this.transform.position, patrolPoints[currentPoint].transform.position) <= 2f)
       {
        Iterate();
       }
     
       }
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
    


    // Reset Speed after Utility spell or is completed
    public void ResetSpeed()
    {
      navMeshAgent.speed = OriginalSpeed;
    }

    //Animation Event functions

    public void ApplyDamageToPlayer()
    {
      FistObject.GetComponent<SphereCollider>().enabled = true;
      
    }

     public void StopApplyingDamageToPlayer()
    {
      FistObject.GetComponent<SphereCollider>().enabled = false;
    }

    //Damage Window for Animation Events

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

    //Stop Attack Function

    public void StopAttack()
    {
      StopCoroutine(DelayAttack());
      
    }

    //Attack Delay

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(AttackDelay);
        AttackBlocked = false;
    }

    //Reset Damage Apllied after Potion expires

    public void ResetDamage()
    {
      DamageToApply = OriginalDamageToApply;
    }

    // If enemy has a starting position and no patrol path, move to start position

    public void ReturnToNormalPosition()
    {
      navMeshAgent.destination = ReturnPosition.position;
    }

    // Chase The Player

    public void FindPlayer()
    {
      navMeshAgent.destination = target.transform.position;
    }

    // Patrol Pathing
    public void Iterate()
    {
      // Move between each path point in list, then repeat
      if(currentPoint < patrolPoints.Length-1)
      {
        currentPoint++;
      }
      else
      {
        currentPoint = 0;
      }
      
       navMeshAgent.destination = patrolPoints[currentPoint].transform.position;
      

      
      
        
      
      
      
      
      //PatrolTarget = patrolPoints[PatrolPointIndex].position;
      //navMeshAgent.destination = patrolPoints[PatrolPointIndex].position;

      //PatrolPointIndex = (PatrolPointIndex + 1) % patrolPoints.Length;
    }

    // Cancel patrol pathing

    public void StopIteration()
    {
      
       navMeshAgent.destination = target.transform.position;
      
    }

   

    
    

   


}

// CUSTOM EDITOR PROPERTIES

// The custom Editor allows certain attributes to be shown or hidden based on Enemy type selected in the inspector. 

#if UNITY_EDITOR
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

        SerializedProperty m_PatrolPoints;

        void OnEnable()
        {
          
        }

        switch(EC.enemyType)
        {
          case EnemyType.Zombie:
          m_PatrolPoints = serializedObject.FindProperty("patrolPoints");
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.EnemyAnimator = (Animator)EditorGUILayout.ObjectField("Enemy Animator", EC.EnemyAnimator, typeof(Animator), true);
          EC.FistObject = (GameObject)EditorGUILayout.ObjectField("Fist Object", EC.FistObject, typeof(GameObject), true);
          EC.IsAgitated = EditorGUILayout.Toggle("IsAgitated", EC.IsAgitated);
          EC.IsPatrolling = EditorGUILayout.Toggle("IsPatrolling", EC.IsPatrolling);
          EC.ReturnPosition = (Transform)EditorGUILayout.ObjectField("Return Position", EC.ReturnPosition, typeof(Transform), true);
          EditorGUILayout.PropertyField(serializedObject.FindProperty("patrolPoints"), includeChildren: true);
          if(m_PatrolPoints.hasChildren)
          {
            serializedObject.ApplyModifiedProperties();
          }



          EC.RangeToPlayer = EditorGUILayout.FloatField("Range To Player", EC.RangeToPlayer);
          

          EC.currentDistance = EditorGUILayout.FloatField("Current Distance", EC.currentDistance);

          EC.speed = EditorGUILayout.FloatField("Speed", EC.RangeToPlayer);
          EC.OriginalSpeed = EditorGUILayout.FloatField("Original Speed", EC.OriginalSpeed);

          EC.DamageToApply = EditorGUILayout.IntField("Damage To Apply", EC.DamageToApply);
          //EC.PatrolPointIndex = EditorGUILayout.IntField("Patrol Point Index", EC.PatrolPointIndex);

          EC.OriginalDamageToApply = EditorGUILayout.IntField("Original Damage To Apply", EC.OriginalDamageToApply);

          EC.DamageToApply = 5;
          EC.minDistance = EditorGUILayout.FloatField("Min Distance To Chase", EC.minDistance);
          EC.DistanceToStartAnimation = EditorGUILayout.FloatField("Min Distance To Attack", EC.DistanceToStartAnimation);
          EC.maxDistance = EditorGUILayout.FloatField("Max Distance to Stop Chasing", EC.maxDistance);
          
          //EC.navMeshAgent.speed = EC.speed;

          break;

          case EnemyType.DeathKnight:
          m_PatrolPoints = serializedObject.FindProperty("patrolPoints");
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.EnemyAnimator = (Animator)EditorGUILayout.ObjectField("Enemy Animator", EC.EnemyAnimator, typeof(Animator), true);
          EC.RangeToPlayer = EditorGUILayout.FloatField("Range To Player", EC.RangeToPlayer);
          EC.currentDistance = EditorGUILayout.FloatField("Current Distance", EC.currentDistance);
          EC.speed = EditorGUILayout.FloatField("Speed", EC.speed);
          EC.DamageToApply = EditorGUILayout.IntField("Damage To Apply", EC.DamageToApply);
          EC.IsAgitated = EditorGUILayout.Toggle("IsAgitated", EC.IsAgitated);
          EC.IsPatrolling = EditorGUILayout.Toggle("IsPatrolling", EC.IsPatrolling);
          EC.ReturnPosition = (Transform)EditorGUILayout.ObjectField("Return Position", EC.ReturnPosition, typeof(Transform), true);
          EC.OriginalDamageToApply = EditorGUILayout.IntField("Original Damage To Apply", EC.OriginalDamageToApply);
          EC.FistObject = (GameObject)EditorGUILayout.ObjectField("Fist Object", EC.FistObject, typeof(GameObject), true);
          EC.OriginalSpeed = EditorGUILayout.FloatField("Original Speed", EC.OriginalSpeed);
          EditorGUILayout.PropertyField(serializedObject.FindProperty("patrolPoints"), includeChildren: true);
          EC.minDistance = EditorGUILayout.FloatField("Min Distance To Chase", EC.minDistance);
          if(m_PatrolPoints.hasChildren)
          {
            serializedObject.ApplyModifiedProperties();
          }
          EC.DamageToApply = 15;
          EC.DistanceToStartAnimation = EditorGUILayout.FloatField("Min Distance To Attack", EC.DistanceToStartAnimation);
          EC.maxDistance = EditorGUILayout.FloatField("Max Distance to Stop Chasing", EC.maxDistance);

          
          //EC.navMeshAgent.speed = EC.speed;

          break;

          case EnemyType.Imp:
          m_PatrolPoints = serializedObject.FindProperty("patrolPoints");
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.EnemyAnimator = (Animator)EditorGUILayout.ObjectField("Enemy Animator", EC.EnemyAnimator, typeof(Animator), true);
          EC.RangeToPlayer = EditorGUILayout.FloatField("Range To Player", EC.RangeToPlayer);
          EC.currentDistance = EditorGUILayout.FloatField("Current Distance", EC.currentDistance);
          EC.speed = EditorGUILayout.FloatField("Speed", EC.speed);
          EC.DamageToApply = EditorGUILayout.IntField("Damage To Apply", EC.DamageToApply);
          EC.IsAgitated = EditorGUILayout.Toggle("IsAgitated", EC.IsAgitated);
          EC.IsPatrolling = EditorGUILayout.Toggle("IsPatrolling", EC.IsPatrolling);
          EC.ReturnPosition = (Transform)EditorGUILayout.ObjectField("Return Position", EC.ReturnPosition, typeof(Transform), true);
          EC.OriginalDamageToApply = EditorGUILayout.IntField("Original Damage To Apply", EC.OriginalDamageToApply);
          EC.FistObject = (GameObject)EditorGUILayout.ObjectField("Fist Object", EC.FistObject, typeof(GameObject), true);
          EC.OriginalSpeed = EditorGUILayout.FloatField("Original Speed", EC.OriginalSpeed);
          EditorGUILayout.PropertyField(serializedObject.FindProperty("patrolPoints"), includeChildren: true);
          EC.minDistance = EditorGUILayout.FloatField("Min Distance To Chase", EC.minDistance);
          if(m_PatrolPoints.hasChildren)
          {
            serializedObject.ApplyModifiedProperties();
          }
          EC.DamageToApply = 10;
          EC.DistanceToStartAnimation = EditorGUILayout.FloatField("Min Distance To Attack", EC.DistanceToStartAnimation);
          EC.maxDistance = EditorGUILayout.FloatField("Max Distance to Stop Chasing", EC.maxDistance);

          
          //EC.navMeshAgent.speed = EC.speed;

          break;

          case EnemyType.Tank:
          m_PatrolPoints = serializedObject.FindProperty("patrolPoints");
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.EnemyAnimator = (Animator)EditorGUILayout.ObjectField("Enemy Animator", EC.EnemyAnimator, typeof(Animator), true);
          EC.RangeToPlayer = EditorGUILayout.FloatField("Range To Player", EC.RangeToPlayer);
          EC.currentDistance = EditorGUILayout.FloatField("Current Distance", EC.currentDistance);
          EC.speed = EditorGUILayout.FloatField("Speed", EC.speed);
          EC.DamageToApply = EditorGUILayout.IntField("Damage To Apply", EC.DamageToApply);
          EC.IsAgitated = EditorGUILayout.Toggle("IsAgitated", EC.IsAgitated);
          EC.IsPatrolling = EditorGUILayout.Toggle("IsPatrolling", EC.IsPatrolling);
          EC.ReturnPosition = (Transform)EditorGUILayout.ObjectField("Return Position", EC.ReturnPosition, typeof(Transform), true);
          EC.OriginalDamageToApply = EditorGUILayout.IntField("Original Damage To Apply", EC.OriginalDamageToApply);
          EC.FistObject = (GameObject)EditorGUILayout.ObjectField("Fist Object", EC.FistObject, typeof(GameObject), true);
          EC.OriginalSpeed = EditorGUILayout.FloatField("Original Speed", EC.OriginalSpeed);
          EditorGUILayout.PropertyField(serializedObject.FindProperty("patrolPoints"), includeChildren: true);
          EC.minDistance = EditorGUILayout.FloatField("Min Distance To Chase", EC.minDistance);
          if(m_PatrolPoints.hasChildren)
          {
            serializedObject.ApplyModifiedProperties();
          }
          EC.DamageToApply = 20;
          EC.DistanceToStartAnimation = EditorGUILayout.FloatField("Min Distance To Attack", EC.DistanceToStartAnimation);
          EC.maxDistance = EditorGUILayout.FloatField("Max Distance to Stop Chasing", EC.maxDistance);

          break;
        }
    }






}
#endif
