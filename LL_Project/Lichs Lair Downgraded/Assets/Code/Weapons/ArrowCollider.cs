using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    public int DamageApplied;

    public PlayerHealth playerHealth;
    public PlayerMagic playerMagic;
    // Start is called before the first frame update
    void Start()
    {
        playerMagic = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMagic>();

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "EnemyCollider")
      {
        other.gameObject.GetComponent<DamageManager>().enemyHealth.TakeDamage(DamageApplied);
        
        if(other.gameObject.GetComponent<DamageManager>().enemyHealth.IsDead)
        {
          playerHealth.currentHealth += 30;
          playerMagic.currentMana += 100;
          Destroy(this.gameObject);
          
        }

        
        
       
         
      }
    }
}
