using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }
    
    
    public void AddItem(Item newItem)
    {
      item = newItem;
    }

    public void UseItem()
    {
      /*
      switch(item.itemType)
      {
        case Item.ItemType.HealthPotion:
             //if(PlayerHealth.Instance.currentHealth < PlayerHealth.Instance.maxHealth)
             //{
              
               GameObject clone;
               Vector3 rotationVector = transform.rotation.eulerAngles;
               rotationVector.x = -90;
               PlayerHealth.Instance.IncreaseHealth(item.value);
               clone = Instantiate(item.ItemEffects, PlayerController.Instance.transform.position, PlayerController.Instance.transform.rotation);
               clone.transform.parent = PlayerController.Instance.transform;
               GameObject.Find("UI").GetComponent<SlotUIController>().HasHealthPotion = true;
               clone.transform.rotation = Quaternion.Euler(rotationVector);
               RemoveItem();
             //}
             
             

               break;

        
      }
      switch(item.itemType)
      {
        case Item.ItemType.ManaPotion:
             //if(PlayerMagic.Instance.currentMana < PlayerMagic.Instance.maxMana)
             //{
               GameObject clone;
               Vector3 rotationVector = transform.rotation.eulerAngles;
               rotationVector.x = -90;
               PlayerMagic.Instance.IncreaseMana(item.value);
               clone = Instantiate(item.ItemEffects, PlayerController.Instance.transform.position, PlayerController.Instance.transform.rotation);
               clone.transform.parent = PlayerController.Instance.transform;
               
               clone.transform.rotation = Quaternion.Euler(rotationVector);
               RemoveItem();



             //}
             
             break;
      }
      */

      
    }
}
