using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public Item Item;
   
   // Pickup Item and Destroy Collectible Object prefab

   void Pickup()
   {
    InventoryManager.Instance.Add(Item);
    Destroy(gameObject);
   }
   

   // When player collides with object, pickup item

  private void OnTriggerEnter(Collider other) 
  {
    if(other.gameObject.tag == "PlayerPickupCollider")
    {
       Pickup();
    }
  }


}
