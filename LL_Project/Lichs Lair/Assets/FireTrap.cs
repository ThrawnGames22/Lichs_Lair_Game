using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public Fire fire;
    public bool EnableFire;
    public GameObject FireObject;
    public MeshCollider meshCollider;
    public GameObject FireMainObject;
    // Start is called before the first frame update
    void Start()
    {
    FireMainObject.SetActive(false);
    this.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnableFire)
        {
            FireObject.SetActive(true);
        }

         if(!EnableFire)
        {
            FireObject.SetActive(false);
        }
    }

    public void ApplyFireDamage()
    {
     //meshCollider.enabled = false;
     EnableFire = true;
     meshCollider.enabled = true;
    }

    public void StopApplyingFireDamage()
    {
        //meshCollider.enabled = true;
        EnableFire = false;
        meshCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
        FireMainObject.SetActive(true);
        this.GetComponent<Animator>().enabled = true;
      }
    }
}
