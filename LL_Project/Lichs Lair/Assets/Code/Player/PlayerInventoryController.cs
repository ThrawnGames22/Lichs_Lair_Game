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
      if(Input.GetKeyDown(KeyCode.Tab))
      {
        InventoryIsOpen = !InventoryIsOpen;
        this.gameObject.GetComponent<InventoryManager>().ListItems();
      }

      if(InventoryIsOpen)
      {
        InventoryWindow.SetActive(true);
        
      }
      else
      {
        InventoryWindow.SetActive(false);
        //this.gameObject.GetComponent<InventoryManager>().ListItems();
      }
    }
}
