using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketController : MonoBehaviour
{
    public Trinket trinketData;
    public GameObject Player;

    //public Quaternion RotationOffset;
    // Start is called before the first frame update
    void Start()
    {
       //this.transform.rotation = RotationOffset; 
    }

    // Update is called once per frame
    void Update()
    {
      Player = GameObject.FindGameObjectWithTag("Player");  
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<TrinketManager>().HasTrinket == false)
            {
            PickupTrinket();
            }
        }
    }

    public void PickupTrinket()
    {
     Player.GetComponent<TrinketManager>().CurrentTrinket = trinketData;
     Player.GetComponent<TrinketManager>().HasTrinket = true;
     Destroy(this.gameObject);
    }
}
