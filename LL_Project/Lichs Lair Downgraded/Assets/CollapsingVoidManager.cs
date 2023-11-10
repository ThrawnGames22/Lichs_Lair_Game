using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingVoidManager : MonoBehaviour
{

    public CollapsingDarkness collapsingDarkness;
    public bool SetDamageFlag;

    

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DamageEnemies()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy")
        {
          if(SetDamageFlag == true)
          {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(collapsingDarkness.Damage);
          }

          if(SetDamageFlag == false)
          {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(0);
            
          }
         
        }
    }

    public IEnumerator DamageEnemies()
    {
        SetDamageFlag = true;
        yield return new WaitForSeconds(1);
        SetDamageFlag = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(DamageEnemies());



        

    }
}
