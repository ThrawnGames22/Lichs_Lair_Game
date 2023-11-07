using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxDefender : MonoBehaviour
{
    public SpiritDefenders spiritDefenders;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag == "Enemy")
      {
        other.GetComponent<EnemyHealth>().TakeDamage(spiritDefenders.Damage);
      }
    }
}
