using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChestManager : MonoBehaviour
{
    
    public GameObject LockedObject;
    public GameObject UnlockedObject;

    public bool GlobalOverrideUnlocked;
    public GameObject WeaponChestPrompt;
    public GameObject UnlockedCanvas;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       if(PlayerController.Instance.HasUnlockedWeaponChest == true)
       {
        GlobalOverrideUnlocked = true;
       } 

        if(PlayerController.Instance.HasUnlockedWeaponChest == false)
       {
        GlobalOverrideUnlocked = false;
       }

       if(GlobalOverrideUnlocked == true)
       {
        LockedObject.SetActive(false);
        UnlockedObject.SetActive(true);
       }
       if(GlobalOverrideUnlocked == false)
       {
        LockedObject.SetActive(true);
        UnlockedObject.SetActive(false);
        
       }

       if(WeaponChestReactivate.Instance.IsInMenu == true)
       {
        GlobalOverrideUnlocked = false;
       } 

       

    }
}
