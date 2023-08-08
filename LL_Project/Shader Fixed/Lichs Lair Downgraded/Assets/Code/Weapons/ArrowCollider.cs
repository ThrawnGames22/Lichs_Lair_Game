using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    public int DamageApplied;
    // Start is called before the first frame update
    void Start()
    {
        
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
          PlayerHealth.Instance.currentHealth += 30f;
          PlayerMagic.Instance.currentMana += 100;
        }
        Destroy(this.gameObject);
       
         
      }
    }
}
