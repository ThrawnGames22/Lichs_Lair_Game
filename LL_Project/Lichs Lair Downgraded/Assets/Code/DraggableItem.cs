using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
  public bool IsInSlot;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    public RectTransform ItemSlotRect;
    public string ItemType;
    public Vector2 SlotSpace;
    public Image image;
    public GameObject thisObject;
    


    public bool IsWeapon;
    public bool IsTrinket;
    public bool IsPotion;
    public bool IsPet;
    public bool IsCBS1;
    public bool IsCBS2;
    public bool IsUTS;


    public Weapon weapon;
    public Item potion;
    public Pet pet;
    public CombatSpellScriptableObject CombatSpell1;
    public CombatSpellScriptableObject CombatSpell2;
    public UtilitySpellScriptableObject UtilitySpell;
    
    public bool heldDown;

    
    


    void Start() 
    {
      if(IsWeapon)
     {
      ItemSlotRect = GameObject.Find("WeaponSlotContainer").GetComponent<RectTransform>();
     }

      if(IsPotion)
     {
      ItemSlotRect = GameObject.Find("PotionSlotContainer").GetComponent<RectTransform>();
     }

      if(IsTrinket)
     {
      ItemSlotRect = GameObject.Find("TrinketSlotContainer").GetComponent<RectTransform>();
     }

      if(IsPet)
     {
      ItemSlotRect = GameObject.Find("PetSlotContainer").GetComponent<RectTransform>();
     }
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //this.transform.parent = GameObject.Find("UI").transform;
        image = GetComponent<Image>();
        if(IsWeapon)
        {
         this.gameObject.name = weapon.WeaponName;
         image.sprite = weapon.WeaponIcon;
        }

        if(IsPotion)
        {
         this.gameObject.name = potion.ItemName;
         image.sprite = potion.ItemIcon;
        }

        if(IsPet)
        {
         this.gameObject.name = pet.PetName;
         image.sprite = pet.PetIcon;
        }
        
      AutoAsign();
      
    
        
        
    }

    
   public void OnPointerDown(PointerEventData eventData)
   {
     heldDown = true;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
     heldDown = false;
   }

   public void OnBeginDrag(PointerEventData eventData)
   {
     canvasGroup.blocksRaycasts = false;

     if(IsWeapon)
     {
      eventData.pointerDrag.gameObject.transform.parent = GameObject.Find("UI").transform;
      ItemSlotRect.GetComponent<ItemSlotContainer>().ItemInSlot = null;
     }
      if(IsTrinket)
     {
      eventData.pointerDrag.gameObject.transform.parent = GameObject.Find("UI").transform;
      ItemSlotRect.GetComponent<ItemSlotContainer>().ItemInSlot = null;
     }
      if(IsPotion)
     {
      eventData.pointerDrag.gameObject.transform.parent = GameObject.Find("UI").transform;
      ItemSlotRect.GetComponent<ItemSlotContainer>().ItemInSlot = null;
     }
      if(IsPet)
     {
      eventData.pointerDrag.gameObject.transform.parent = GameObject.Find("UI").transform;
      ItemSlotRect.GetComponent<ItemSlotContainer>().ItemInSlot = null;
     }
     
   }

   public void OnEndDrag(PointerEventData eventData)
   {
     canvasGroup.blocksRaycasts = true;

     this.GetComponent<RectTransform>().anchoredPosition = ItemSlotRect.anchoredPosition;
     if(IsWeapon)
     {
      ParentItemToSlot();
     }
     if(IsTrinket)
     {
      ParentItemToSlot();
     }
     if(IsPotion)
     {
      ParentItemToSlot();
     }
     if(IsPet)
     {
      ParentItemToSlot();
     }
     
   }

   public void OnDrag(PointerEventData eventData)
   {
     rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
   }

   public void OnDrop(PointerEventData eventData)
   {

   }

   void Update() 
   {
    if(heldDown == false)
    {
      ParentItemToSlot();
    }
    thisObject = this.gameObject;
    if(ItemSlotRect.GetComponent<ItemSlotContainer>().ItemIsInSlot == false)
    {
     if(IsWeapon)
     {
      ItemSlotRect = GameObject.Find("WeaponSlotContainer").GetComponent<RectTransform>();
     }

      if(IsPotion)
     {
      ItemSlotRect = GameObject.Find("PotionSlotContainer").GetComponent<RectTransform>();
     }

      if(IsTrinket)
     {
      ItemSlotRect = GameObject.Find("TrinketSlotContainer").GetComponent<RectTransform>();
     }

      if(IsPet)
     {
      ItemSlotRect = GameObject.Find("PetSlotContainer").GetComponent<RectTransform>();
     }
    }



    if(this.GetComponent<RectTransform>().anchoredPosition == ItemSlotRect.anchoredPosition)
    {
      
      IsInSlot = true;
      ItemSlotRect.GetComponent<ItemSlotContainer>().ItemIsInSlot = true;
      if(IsWeapon)
      {
      ItemSlotRect.GetComponent<ItemSlotContainer>().weapon = weapon;
      }
      if(IsPotion)
      {
      ItemSlotRect.GetComponent<ItemSlotContainer>().Potion = potion;
      }
      if(IsTrinket)
      {
      //ItemSlotRect.GetComponent<ItemSlotContainer>().weapon = weapon;
      }
      if(IsPet)
      {
      ItemSlotRect.GetComponent<ItemSlotContainer>().pet = pet;
      }
      
      
    }

    if(this.GetComponent<RectTransform>().anchoredPosition != ItemSlotRect.anchoredPosition)
    {
      
      IsInSlot = false;
      ItemSlotRect.GetComponent<ItemSlotContainer>().ItemIsInSlot = false;
      if(IsWeapon)
      {
      ItemSlotRect.GetComponent<ItemSlotContainer>().weapon = null;
      }

      if(IsPotion)
      {
      ItemSlotRect.GetComponent<ItemSlotContainer>().Potion = null;
      }
      //this.transform.SetParent(GameObject.Find("UI").transform);
      
      
    }

   

    

    
    
    

    

    


    
   }

   public void ParentItemToSlot()
   {
    this.gameObject.transform.parent = ItemSlotRect.gameObject.transform;
   }

    public void DropItem()
    {
      Destroy(this.gameObject);
    }
    
    public void AutoAsign()
    {
      this.GetComponent<RectTransform>().anchoredPosition = ItemSlotRect.anchoredPosition;
    }
    
}

