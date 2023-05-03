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
        Destroy(this.gameObject);
      }
    }
}
