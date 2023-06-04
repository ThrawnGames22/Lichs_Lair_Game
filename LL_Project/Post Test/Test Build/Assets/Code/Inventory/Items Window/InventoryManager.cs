using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    // Adds items to inventory

    public void Add(Item item)
    {
        Items.Add(item);
    }

    // Removes items from inventory

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

     // Lists the updated Items when opening the inventory

    public void ListItems()
    {
        
       
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.ItemName;
            itemIcon.sprite = item.ItemIcon;

            if(EnableRemove.isOn)
               removeButton.gameObject.SetActive(true);
        }

        SetInventoryItems();
    }

    public void CleanInventory()
    {
        //Cleans the Inventory content before opening to prevent item duplication
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    // Enables to button to remove items  

    public void EnableItemsRemove()
    {
        if(EnableRemove.isOn)
        {
            foreach(Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
           foreach(Transform item in ItemContent)
           {
            item.Find("RemoveButton").gameObject.SetActive(false);
           }
        }
    }

    // Sets the items in inventory on pickup

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for(int i = 0; i < Items.Count; i++)
        {
           InventoryItems[i].AddItem(Items[i]);
        }
    }
}
