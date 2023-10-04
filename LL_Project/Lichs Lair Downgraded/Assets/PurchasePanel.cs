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
      //StartCoroutine(ResetTriggerFlag());
    }

     public void OpenPanel()
    {
        
      Panel.SetActive(true);
      //StartCoroutine(ResetTriggerFlag());
    }

    public void ConfirmPurchase()
    {
        HasPressedConfirm = true;
        ClosePanel();
        StartCoroutine(ResetTriggerFlag());
        if(IsWeaponPurchase)
        {
            Destroy(GameObject.Find("WeaponSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            IsWeaponPurchase = false;
        }
        if(IsTrinketPurchase)
        {
            Destroy(GameObject.Find("TrinketSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            IsTrinketPurchase = false;
        }
        if(IsPotionPurchase)
        {
            Destroy(GameObject.Find("PotionSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            IsPotionPurchase = false;
        }
        if(IsPetPurchase)
        {
            Destroy(GameObject.Find("PetSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            IsPetPurchase = false;
        }
        
        
        

        
    }

    public IEnumerator ResetTriggerFlag()
    {
        yield return new WaitForSeconds(0.7f);
        HasPressedConfirm = false;
        
        
    }
}

    
