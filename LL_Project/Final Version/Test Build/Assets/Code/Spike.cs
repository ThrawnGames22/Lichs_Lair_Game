using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int Damage;
    public SpikeTrap spikeTrap;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageP()
    {
      spikeTrap.DamagePlayer();
      this.GetComponent<MeshCollider>().enabled = true;
    }

    public void StopDamageP()
    {
      spikeTrap.StopDamagingPlayer();
      this.GetComponent<MeshCollider>().enabled = false;
    }

   

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
          other.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
