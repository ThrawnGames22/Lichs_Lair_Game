using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ItemSlotContainer : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public bool ItemIsInSlot;
    public bool ItemIsHovering;
    public GameObject ItemInSlot;

    public bool IsWeaponSlot;
    public bool IsTrinketSlot;
    public bool IsPotionSlot;
    public bool IsPetSlot;
    public bool IsCBS1Slot;
    public bool IsCBS2Slot;
    public bool IsUTSSlot;
    public bool IsDropContainer;
    public Merchant Merchant;
    public PurchasePanel purchasePanel;

    public bool HasItemAlready;

    public List<GameObject> ChildObjects;
    public Transform[] ChildObjectTransforms;

[Header("Last Merchant Item That Was Referenced")]
    public GameObject ItemReference;

 

[Header("DataObjects")]
    //DataObjects
    public Weapon weapon;
    public Item Potion;
    public Pet pet;
    public CombatSpellScriptableObject CombatSpell1;
    public CombatSpellScriptableObject CombatSpell2;
    public UtilitySpellScriptableObject UtilitySpell;

    [Header("UISlotHolder")]
    public SlotUIController UIController;



    


   
    public void OnDrop(PointerEventData eventData)
    {
      
        //Weapon
       if(IsWeaponSlot)
       {
        if(eventData.pointerDrag.tag == "InventoryItem")
        {
            if(eventData.pointerDrag.GetComponent<DraggableItem>().IsWeapon)
            {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
              
            }
        }

        if(eventData.pointerDrag.tag == "StoreItem")
        {
            if(eventData.pointerDrag.GetComponent<MechantItem>().IsWeapon)
            {
              print("Buy");
              Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>().OpenPanel();
              Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>().IsWeaponPurchase = true;
              //eventData.pointerDrag.GetComponent<RectTransform>().anchorMax = Vector2.zero;
              //eventData.pointerDrag.GetComponent<RectTransform>().anchorMin = Vector2.zero;

              eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector2(2.462006f, 2.052948f);
              
              
              
              
              
            }
        }

        
       }

       if(IsTrinketSlot)
       {
        if(eventData.pointerDrag.tag == "InventoryItem")
        {
            if(eventData.pointerDrag.GetComponent<DraggableItem>().IsTrinket)
            {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
              
            }
        }

        if(eventData.pointerDrag.tag == "StoreItem")
        {
            if(eventData.pointerDrag.GetComponent<MechantItem>().IsTrinket)
            {
              print("Buy");
              Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>().OpenPanel();
              Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>().IsTrinketPurchase = true;

              eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector2(2.462006f, 2.052948f);
              
              
              
              
              
            }
        }

        
       }
       if(IsPotionSlot)
       {
        if(eventData.pointerDrag.tag == "InventoryItem" )
        {
            if(eventData.pointerDrag.GetComponent<DraggableItem>().IsPotion)
            {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
             
            }
        }

        if(eventData.pointerDrag.tag == "StoreItem")
        {
            if(eventData.pointerDrag.GetComponent<MechantItem>().IsPotion)
            {
              print("Buy");
              Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>().OpenPanel();
              Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>().IsPotionPurchase = true;

              eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector2(2.462006f, 2.052948f);
              
              
              
              
              
            }
        }
       }

       if(IsPetSlot)
       {
        if(eventData.pointerDrag.tag == "InventoryItem")
        {
            if(eventData.pointerDrag.GetComponent<DraggableItem>().IsPet)
            {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
             
            }
        }

        if(eventData.pointerDrag.tag == "StoreItem")
        {
            if(eventData.pointerDrag.GetComponent<MechantItem>().IsPet)
            {
              print("Buy");
              Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>().OpenPanel();
              Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>().IsPetPurchase = true;

              eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector2(2.462006f, 2.052948f);
              
              
              
              
              
            }
        }
       }

       if(IsDropContainer)
       {
        eventData.pointerDrag.GetComponent<DraggableItem>().DropItem();
       }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag.tag == "StoreItem")
        {
          ItemIsHovering = true;
          ItemReference = eventData.pointerDrag.gameObject;
        }
        if(eventData.pointerDrag)
        {
          ItemIsHovering = false;
          print("IsHovering");
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(eventData.pointerDrag.tag == "StoreItem")
        {
          ItemIsHovering = false;
        }

        

        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ItemIsHovering = false;
    }

    private void Update() 
    {
      UIController = GameObject.Find("UI").GetComponent<SlotUIController>();
      Merchant = GameObject.Find("MerchantManager").GetComponent<Merchant>();
      purchasePanel = Merchant.ConfirmPurchasePanel.GetComponent<PurchasePanel>();
      
      ChildObjects = gameObject.GetChildren();
      ItemInSlot = ChildObjects[0];
      if(IsDropContainer == false)
      {
        if(ItemInSlot != null)
        {
        //ItemInSlot = this.gameObject.transform.GetChild(0).gameObject;
        ItemIsInSlot = true;
        }
        
        
      }
      if(ChildObjects[0] != null)
        {
          ItemIsInSlot = true;
        }

        
      
      


      if(purchasePanel.HasPressedConfirm == true)
              {
                GameObject WeaponClone = Instantiate(ItemReference.GetComponent<MechantItem>().DraggableItemPrefab);
                ItemInSlot = WeaponClone;
                Destroy(ItemReference);
                ItemReference = null;
                print("ItemDeleted");
                
              }

              if(ItemInSlot != null)
              {
                HasItemAlready = true;
              }
              else
              {
                HasItemAlready = false;
              }
    }


    

    

    
}

public static class HelperMethods
{
    public static List<GameObject> GetChildren(this GameObject go)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform tran in go.transform)
        {
            children.Add(tran.gameObject);
        }
        return children;
    }
}
