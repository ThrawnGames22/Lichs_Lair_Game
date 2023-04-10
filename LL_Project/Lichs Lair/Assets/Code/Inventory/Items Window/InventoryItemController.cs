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
      switch(item.itemType)
      {
        case Item.ItemType.HealthPotion:
             //if(PlayerHealth.Instance.currentHealth < PlayerHealth.Instance.maxHealth)
             //{
               PlayerHealth.Instance.IncreaseHealth(item.value);
               RemoveItem();
             //}
             
             

               break;

        
      }
      switch(item.itemType)
      {
        case Item.ItemType.ManaPotion:
             //if(PlayerMagic.Instance.currentMana < PlayerMagic.Instance.maxMana)
             //{
               PlayerMagic.Instance.IncreaseMana(item.value);
               RemoveItem();



             //}
             
             break;
      }

      
    }
}
