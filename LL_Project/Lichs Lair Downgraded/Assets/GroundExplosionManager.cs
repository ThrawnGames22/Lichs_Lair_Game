using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplosionManager : MonoBehaviour
{
    public int DamageToApply;
    public float KnockBackSpeed;

    public List<GameObject> EnemiesInRange;
    // Star is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemies()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
       if(other.gameObject.tag == "Enemy")
       {
        EnemiesInRange.Add(other.gameObject);
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(DamageToApply);
        other.gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.transform.forward * KnockBackSpeed * Time.deltaTime);
       } 
    }
}
