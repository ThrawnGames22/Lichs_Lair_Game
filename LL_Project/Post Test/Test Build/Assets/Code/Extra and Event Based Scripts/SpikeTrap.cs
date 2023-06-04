using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    //public int Damage;
    //public GameObject Player;
    public GameObject SpikeObject;
    // Start is called before the first frame update
    void Start()
    {
        SpikeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
          SpikeObject.SetActive(true);
        }
    }
    public void DamagePlayer()
    {
    
    }

    public void StopDamagingPlayer()
    {
     
    }
    

    
}
