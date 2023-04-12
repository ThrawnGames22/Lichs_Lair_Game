using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;

    public GameObject ItemInventory;
    public GameObject WeaponInventory;
    public GameObject SpellInventory;

    private void Awake() 
    {
        instance = this;
    }
}
