using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupHealth()
    {
      GameObject.Find("UI").GetComponent<SlotUIController>().HasHealthPotion = true;
      Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerPickupCollider")
        {
            if(GameObject.Find("UI").GetComponent<SlotUIController>().HasHealthPotion == false)
            {
              PickupHealth();
            }
        }
    }
}
