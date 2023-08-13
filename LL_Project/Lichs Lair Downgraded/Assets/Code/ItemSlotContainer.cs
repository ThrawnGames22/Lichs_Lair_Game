using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ItemSlotContainer : MonoBehaviour, IDropHandler
{
    public bool ItemIsInSlot;
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

    private void Update() 
    {
      if(IsDropContainer == false)
      {
        if(ItemInSlot != null)
        {
        ItemInSlot = this.gameObject.transform.GetChild(0).gameObject;
        }
      }
    }
    
}
