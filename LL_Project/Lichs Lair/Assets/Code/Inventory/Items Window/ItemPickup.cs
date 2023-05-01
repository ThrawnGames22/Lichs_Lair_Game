using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public Item Item;

   void Pickup()
   {
    InventoryManager.Instance.Add(Item);
    Destroy(gameObject);
   }

  private void OnTriggerEnter(Collider other) 
  {
    if(other.gameObject.tag == "PlayerPickupCollider")
    {
       Pickup();
    }
  }


}
