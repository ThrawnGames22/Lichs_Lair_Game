using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public GameObject InventoryWindow;

    private void Start()
    {
        InventoryWindow.SetActive(false);
    }
}
