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
    public float WithinRange;
    public float speed;
    public NavMeshAgent navMeshAgent; 
    public float DamageToApply =5f;

    //public EnemyType enemyType;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      navMeshAgent.SetDestination(target.transform.position);
      
    }

    private void OnCollisionEnter(Collision col)
    {
      if(col.gameObject.tag == "Player")
      {
        Debug.Log("EnemyHasHit");
        col.gameObject.GetComponent<PlayerHealth>().currentHealth -= DamageToApply;
      }
    }
}

[CustomEditor(typeof(EnemyController))]
public class EnemyControllerEditor : Editor
{
    
    EnemyController EC;

    void OnEnable()
    {
        EC =(EnemyController)target;
        
    }

    public override void OnInspectorGUI()
    {
        EC.enemyType = (EnemyType)EditorGUILayout.EnumPopup("EnemyType", EC.enemyType);

        switch(EC.enemyType)
        {
          case EnemyType.Zombie:
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.WithinRange = EditorGUILayout.FloatField("Within Range", EC.WithinRange);
          EC.speed = EditorGUILayout.FloatField("Speed", EC.speed);
          EC.DamageToApply = EditorGUILayout.FloatField("Damage To Apply", EC.DamageToApply);
          EC.DamageToApply = 5f;
          
          EC.navMeshAgent.speed = EC.speed;

          break;

          case EnemyType.DeathKnight:
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.WithinRange = EditorGUILayout.FloatField("Within Range", EC.WithinRange);
          EC.speed = EditorGUILayout.FloatField("Speed", EC.speed);
          EC.DamageToApply = EditorGUILayout.FloatField("Damage To Apply", EC.DamageToApply);

          
          EC.navMeshAgent.speed = EC.speed;

          break;

          case EnemyType.Imp:
          EC.target = (GameObject)EditorGUILayout.ObjectField("Target", EC.target, typeof(GameObject), true);
          EC.WithinRange = EditorGUILayout.FloatField("Within Range", EC.WithinRange);
          EC.speed = EditorGUILayout.FloatField("Speed", EC.speed);
          EC.DamageToApply = EditorGUILayout.FloatField("Damage To Apply", EC.DamageToApply);

          
          EC.navMeshAgent.speed = EC.speed;

          break;
        }
    }






}
