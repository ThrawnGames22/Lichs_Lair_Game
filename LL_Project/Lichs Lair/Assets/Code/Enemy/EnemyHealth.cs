using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyCurrentHealth;
    public float enemyMaxHealth;
    
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
            Destroy(gameObject);
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
    }
}
