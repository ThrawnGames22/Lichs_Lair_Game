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

 

[Header("DataObjects")]
    //DataObjects
    public Weapon weapon;
    public Item Potion;
    public Pet pet;
    public CombatSpellScriptableObject CombatSpell1;
    public CombatSpellScriptableObject CombatSpell2;
    public UtilitySpellScriptableObject UtilitySpell;
    public void OnDrop(PointerEventData eventData)
    {
      
        //Weapon
       if(IsWeaponSlot)
       {
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<DraggableItem>().IsWeapon)
            {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
              
            }
        }

        
       }

       if(IsTrinketSlot)
       {
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<DraggableItem>().IsTrinket)
            {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
              
            }
        }

        
       }
       if(IsPotionSlot)
       {
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<DraggableItem>().IsPotion)
            {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
             
            }
        }
       }

       if(IsPetSlot)
       {
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.GetComponent<DraggableItem>().IsPet)
            {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
             
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
        }
        if(eventData.pointerDrag == null)
        {
          ItemIsHovering = false;
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
      if(IsDropContainer == false)
      {
        
        ItemInSlot = this.gameObject.transform.GetChild(0).gameObject;
        
      }
    }
    
}
