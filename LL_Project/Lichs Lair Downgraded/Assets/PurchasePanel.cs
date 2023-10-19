using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasePanel : MonoBehaviour
{
    
    public bool IsPotionPurchase;
    public bool IsTrinketPurchase;
    public bool IsCombatSpell2Purchase;

    public bool HasPressedBack;
    public bool HasPressedConfirm;
    public GameObject Panel;

    public CombatSpellScriptableObject CBSItemToPurchase;
    public Item PTItemToPurchase;
    public Trinket TKItemToPurchase;


    public Image PurchaseItem;

    public GameObject MerchantItemPrefab;

    public Transform ItemDropPoint;

    public GameObject FundsFailedText;

    public int Coins;

    public CurrencyCounter currencyCounter;



    
    // Start is called before the first frame update
    void Start()
    {
        FundsFailedText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Coins = currencyCounter.coins;
        if(HasPressedConfirm == false)
        {
            StopCoroutine(ResetTriggerFlag());
        }

        

        if(IsCombatSpell2Purchase)
        {
            //CBSItemToPurchase = null;
            PurchaseItem.sprite = CBSItemToPurchase.SpellIcon;
            
            
        }
        if(IsTrinketPurchase)
        {
            //TKItemToPurchase = null;
            PurchaseItem.sprite = TKItemToPurchase.TrinketIcon;

            
            
        }
        if(IsPotionPurchase)
        {
           // PTItemToPurchase = null;
            PurchaseItem.sprite = PTItemToPurchase.ItemIcon;

            
            
        }
    }

    public void ClosePanel()
    {
        
      Panel.GetComponent<CanvasGroup>().alpha = 0;
      Panel.GetComponent<CanvasGroup>().interactable = false;
      Panel.GetComponent<CanvasGroup>().blocksRaycasts = false;

      IsCombatSpell2Purchase = false;
      IsPotionPurchase = false;
      IsTrinketPurchase = false;
      CBSItemToPurchase = null;
      PTItemToPurchase = null;
      TKItemToPurchase = null;
      MerchantItemPrefab = null;

      FundsFailedText.SetActive(false);
      
      //StartCoroutine(ResetTriggerFlag());
    }

     public void OpenPanel()
    {
        
      Panel.GetComponent<CanvasGroup>().alpha = 1;
      Panel.GetComponent<CanvasGroup>().interactable = true;
      Panel.GetComponent<CanvasGroup>().blocksRaycasts = true;


      //ItemToPurchase = GameObject.Find()
      //StartCoroutine(ResetTriggerFlag());
    }

    public void ConfirmPurchase()
    {
        HasPressedConfirm = true;
        
        StartCoroutine(ResetTriggerFlag());
        if(IsCombatSpell2Purchase)
        {
            if(Coins >= CBSItemToPurchase.ItemStoreCost || Coins == CBSItemToPurchase.ItemStoreCost)
            {
            
            //Destroy(GameObject.Find("WeaponSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            
            GameObject SpellClone = Instantiate(CBSItemToPurchase.SpellDropObject, ItemDropPoint.position, ItemDropPoint.rotation);
            Destroy(MerchantItemPrefab);
            CBSItemToPurchase = null;
            IsCombatSpell2Purchase = false;
            ClosePanel();
            }

            if(Coins != CBSItemToPurchase.ItemStoreCost)
            {
                FundsFailedText.SetActive(true);
            }
            
        }
        if(IsTrinketPurchase)
        {
            if(Coins >= TKItemToPurchase.ItemStoreCost || Coins == TKItemToPurchase.ItemStoreCost)
            {
            
            //Destroy(GameObject.Find("TrinketSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            GameObject.Find("UI").GetComponent<SlotUIController>().Coins -= TKItemToPurchase.ItemStoreCost;
            GameObject SpellClone = Instantiate(TKItemToPurchase.TrinketGameObject, ItemDropPoint.position, ItemDropPoint.rotation);
            Destroy(MerchantItemPrefab);
            TKItemToPurchase = null;
            IsTrinketPurchase = false;
            
            ClosePanel();
            }
            if(Coins != TKItemToPurchase.ItemStoreCost)
            {
                FundsFailedText.SetActive(true);
            }

        }
        if(IsPotionPurchase)
        {
            if(Coins >= PTItemToPurchase.ItemStoreCost || Coins == PTItemToPurchase.ItemStoreCost )
            {
            GameObject.Find("UI").GetComponent<SlotUIController>().Coins -= PTItemToPurchase.ItemStoreCost;
            
            //Destroy(GameObject.Find("PotionSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
            
            GameObject SpellClone = Instantiate(PTItemToPurchase.ItemGameObject, ItemDropPoint.position, ItemDropPoint.rotation);
            Destroy(MerchantItemPrefab);
            PTItemToPurchase = null;
            IsPotionPurchase = false;
            ClosePanel();
            }
            if(Coins != PTItemToPurchase.ItemStoreCost)
            {
                FundsFailedText.SetActive(true);
            }
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

    
