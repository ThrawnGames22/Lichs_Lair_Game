using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketController : MonoBehaviour
{
    public Trinket trinketData;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
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
            PickupTrinket();
        }
    }

    public void PickupTrinket()
    {
     Player.GetComponent<TrinketManager>().CurrentTrinket = trinketData;
     Player.GetComponent<TrinketManager>().HasTrinket = true;
     Destroy(this.gameObject);
    }
}
