using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Animations;

public class MechantItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas PlayerInventoryCanvas;
    public RectTransform ItemSlotRect;

    public Merchant merchantScript;

    
    public string ItemType;
    public Vector2 SlotSpace;
    public Image image;
    public GameObject thisObject;

    public GameObject DraggableItemPrefab;
    


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
      eventData.pointerDrag.gameObject.transform.parent = GameObject.Find("MerchantGrid").transform;
      //ItemSlotRect.GetComponent<ItemSlotContainer>().ItemInSlot = null;
     }
      if(IsTrinket)
     {
      eventData.pointerDrag.gameObject.transform.parent = GameObject.Find("MerchantGrid").transform;
      //ItemSlotRect.GetComponent<ItemSlotContainer>().ItemInSlot = null;
     }
      if(IsPotion)
     {
      eventData.pointerDrag.gameObject.transform.parent = GameObject.Find("MerchantGrid").transform;
      //ItemSlotRect.GetComponent<ItemSlotContainer>().ItemInSlot = null;
     }
      if(IsPet)
     {
      eventData.pointerDrag.gameObject.transform.parent = GameObject.Find("MerchantGrid").transform;
      //ItemSlotRect.GetComponent<ItemSlotContainer>().ItemInSlot = null;
     }
     
     
     
     
   }

   public void OnEndDrag(PointerEventData eventData)
   {
     canvasGroup.blocksRaycasts = true;
     this.rectTransform.anchoredPosition = ItemSlotRect.anchoredPosition;
     

     
     
   }

   public void OnDrag(PointerEventData eventData)
   {
     rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
     transform.position = Input.mousePosition;
   }

   public void OnDrop(PointerEventData eventData)
   {
     
   }
    // Start is called before the first frame update
    void Start()
    {
      ItemSlotRect = transform.parent.GetComponent<RectTransform>();
      
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
      
        
    }

    // Update is called once per frame
    void Update()
    {
       
       thisObject = this.gameObject;
       PlayerInventoryCanvas = GameObject.Find("UI").GetComponent<Canvas>();
       canvas = GameObject.Find("Merchant Inventory").GetComponent<Canvas>();
       
    }

  
}
