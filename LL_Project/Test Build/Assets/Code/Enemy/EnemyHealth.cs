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
        if(enemyCurrentHealth < 0)
        {
            enemyCurrentHealth = 0;
        }

        if(enemyCurrentHealth == 0)
        {
            Die();
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "FireSpell")
        {
          enemyCurrentHealth -= other.gameObject.GetComponent<FireSpell>().fireDamage;
          print("Ememy Just Took Damage");
        }

        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            if(other.gameObject.GetComponent<SwordController>().CanApplyDamage == true)
            {
             enemyCurrentHealth -= other.gameObject.GetComponent<SwordController>().CurrentDamage;
             print("HasCollided");
            }
            else
            {
                return;
            }
            
        }
        if(other.gameObject.tag == "DarkSpell")
        {
          TakeDamage(other.gameObject.GetComponent<DarkSlash>().DarkDamage);
          print("Ememy Just Took Damage");
        }
        
    }

    public void TakeDamage(int damageValue)
    {
        enemyCurrentHealth -=damageValue;
    }

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

    public IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(5);
        
            Destroy(this.gameObject);
        
    }
}
