using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public GameObject InventoryMenu;
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    // Start is called before the first frame update
    void Start()
    {
        InventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
    }

    private void UseItem(Item item) {
        switch (item.itemType) {
        case Item.ItemType.HealthPotion:
            
            inventory.RemoveItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
            break;
        case Item.ItemType.ManaPotion:
            
            inventory.RemoveItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
            break;
        }
    }
}
