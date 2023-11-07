using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathColldier : MonoBehaviour
{
    public DragonsBreath dragonsBreath;

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
            other.gameObject.GetComponent<EnemyHealth>().enemyCurrentHealth -= dragonsBreath.Damage;
          }

          if(SetDamageFlag == false)
          {
            other.gameObject.GetComponent<EnemyHealth>().enemyCurrentHealth -= 0;
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
