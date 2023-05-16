using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealStone : MonoBehaviour
{
    public int health = 100;
    public int Damage = 50;
    public bool SealIsBroken;
    //public DestroyOverTime DS;
    // Start is called before the first frame update
    void Start()
    {
        //DS.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            SealIsBroken = true;
            //DS.enabled = true;
        }

        if(health < 0)
        {
            health = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DarkSpell")
        {
            health -= Damage;
            print("Stone Has Taken A Hit!");
        }
    }
}
