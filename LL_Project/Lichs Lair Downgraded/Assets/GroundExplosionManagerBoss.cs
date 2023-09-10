using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundExplosionManagerBoss : MonoBehaviour
{
    public int DamageToApply;
    public float KnockBackSpeed;

    public GameObject Player;
    // Star is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void DamageEnemies()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
       if(other.gameObject.tag == "Player")
       {
        
        other.gameObject.GetComponent<PlayerHealth>().TakeDamage(DamageToApply);
        //other.gameObject.GetComponent<Rigidbody>().AddForce(-gameObject.transform.forward * KnockBackSpeed * Time.deltaTime);
       } 
    }
}
