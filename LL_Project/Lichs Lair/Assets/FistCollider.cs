using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistCollider : MonoBehaviour
{
    public EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
       {
        other.GetComponent<PlayerHealth>().currentHealth -= enemyController.DamageToApply;
       } 
    }

    public void ApplyDamageToPlayer()
    {
      this.GetComponent<SphereCollider>().enabled = true;
      
    }

     public void StopApplyingDamageToPlayer()
    {
      this.GetComponent<SphereCollider>().enabled = false;
    }
}
