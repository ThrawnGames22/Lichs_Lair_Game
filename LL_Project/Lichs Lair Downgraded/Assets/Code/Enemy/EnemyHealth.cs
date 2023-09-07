using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{
    public float enemyCurrentHealth;
    public float enemyMaxHealth;
    
    [Header("Components To Destroy On Death")]
    public CapsuleCollider col;
    public NavMeshAgent agent;
    public EnemyHealth EH;
    public DetectSunlight DS;
    public EnemyController EC;
    public Rigidbody RB;

    public bool IsDead;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        // If enemy health number is lower than 0, keep it at 0
        if(enemyCurrentHealth < 0)
        {
            enemyCurrentHealth = 0;
        }
        
        // If Enemy Health is 0, Enemy Dies

        if(enemyCurrentHealth == 0)
        {
            Die();
        }
    }

    // Collsion with Spells take damage
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FireSpell")
        {
          enemyCurrentHealth -= collision.gameObject.GetComponent<FireSpell>().fireDamage;
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }

        if(collision.gameObject.name == "FireGrenade")
        {
          //enemyCurrentHealth -= collision.gameObject.GetComponent<FireSpell>().fireDamage;
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }

        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "DarkSpell")
        {
          TakeDamage(other.gameObject.GetComponent<DarkSlash>().DarkDamage);
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }

        if(other.gameObject.tag == "FireSpell")
        {
          //TakeDamage(other.gameObject.GetComponent<DarkSlash>().DarkDamage);
          print("Ememy Just Took Damage");
          EC.IsHitFirst = true;
        }
        
    }

    //Take damage from Player or objects

    public void TakeDamage(int damageValue)
    {
        enemyCurrentHealth -=damageValue;
    }

    //Enemy Dies

    public void Die()
    {
      IsDead = true;
      Destroy(col);
      Destroy(agent);
      //Destroy(EH);
      Destroy(DS);
      Destroy(EC);
      Destroy(RB);
      StartCoroutine(DestroyAfterTime());
    }

    //Destroy Object to prevent clutter in scene

    public IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        
            Destroy(this.gameObject);
        
    }

    public IEnumerator DecreaseHealth(int damageValue)
    {
       yield return new WaitForSeconds(0);
       enemyCurrentHealth -= damageValue * Time.deltaTime;
    }
}
