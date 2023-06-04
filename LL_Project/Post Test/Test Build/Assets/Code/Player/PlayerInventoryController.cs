using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public GameObject InventoryWindow;
    public bool InventoryIsOpen;

    private void Start()
    {
        InventoryWindow.SetActive(false);
    }

    private void Update()
    {

      // Open inventory
      if(Input.GetKeyDown(KeyCode.Tab))
      {
        InventoryIsOpen = !InventoryIsOpen;
        this.gameObject.GetComponent<InventoryManager>().ListItems();
        
      }

      if(InventoryIsOpen)
      {
        InventoryWindow.SetActive(true);
        
      }
      
      // If inevntory is open, clean the inventory
      if(!InventoryIsOpen)
      {
        InventoryWindow.SetActive(false);
        this.gameObject.GetComponent<InventoryManager>().CleanInventory();
        //this.gameObject.GetComponent<InventoryManager>().ListItems();
      }
    }
}
