using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasePanel : MonoBehaviour
{
    public bool IsWeaponPurchase;
    public bool IsPotionPurchase;
    public bool IsTrinketPurchase;
    public bool IsPetPurchase;

    public bool HasPressedBack;
    public bool HasPressedConfirm;
    public GameObject Panel;

    public GameObject ItemToPurchase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HasPressedConfirm == false)
        {
            StopCoroutine(ResetTriggerFlag());
        }
    }

    public void ClosePanel()
    {
        
      Panel.SetActive(false);
      IsWeaponPurchase = false;
      IsPotionPurchase = false;
      IsTrinketPurchase = false;
      IsPetPurchase = false;
      //StartCoroutine(ResetTriggerFlag());
    }

     public void OpenPanel()
    {
        
      Panel.SetActive(true);
      //ItemToPurchase = GameObject.Find()
      //StartCoroutine(ResetTriggerFlag());
    }

    public void ConfirmPurchase()
    {
        HasPressedConfirm = true;
        ClosePanel();
        StartCoroutine(ResetTriggerFlag());
        if(IsWeaponPurchase)
        {
            ItemToPurchase = null;
            //Destroy(GameObject.Find("WeaponSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            IsWeaponPurchase = false;
            
        }
        if(IsTrinketPurchase)
        {
            ItemToPurchase = null;
            //Destroy(GameObject.Find("TrinketSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            IsTrinketPurchase = false;
        }
        if(IsPotionPurchase)
        {
            ItemToPurchase = null;
            //Destroy(GameObject.Find("PotionSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            IsPotionPurchase = false;
        }
        if(IsPetPurchase)
        {
            ItemToPurchase = null;
            //Destroy(GameObject.Find("PetSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            IsPetPurchase = false;
        }
        
        
        

        
    }

    public IEnumerator ResetTriggerFlag()
    {
        yield return new WaitForSeconds(0.7f);
        HasPressedConfirm = false;
        
        
    }

    public IEnumerator RemovePreviousItem()
    {
        yield return null;
    }
}

    
