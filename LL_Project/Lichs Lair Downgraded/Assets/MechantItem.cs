using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Animations;

public class MechantItem : MonoBehaviour
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas PlayerInventoryCanvas;
    public RectTransform ItemSlotRect;

    public Merchant merchantScript;
    
    public GameObject[] slotContainers;

    public GameObject[] PlayerInventoryItems;

    
    public string ItemType;
    public Vector2 SlotSpace;
    public Image image;
    public GameObject thisObject;

    public PurchasePanel purchasePanel;

    
    


    public bool IsWeapon;
    public bool IsTrinket;
    public bool IsPotion;
    public bool IsPet;
    public bool IsCBS1;
    public bool IsCBS2;
    public bool IsUTS;


    
    public Item potion;
    public Trinket trinket;
    
    public CombatSpellScriptableObject CombatSpell2;
    

    public bool heldDown;

    public bool IsHoveringOverSlot;

    public Sprite ItemSprite;

    public ShopInformationPanel InformationPanel;


   
    
    
    // Start is called before the first frame update
    void Start()
    {

      ItemSlotRect = transform.parent.GetComponent<RectTransform>();
      
      rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //this.transform.parent = GameObject.Find("UI").transform;
        image = GetComponent<Image>();
        if(IsCBS2)
        {
         this.gameObject.name = CombatSpell2.SpellName;
         image.sprite = CombatSpell2.SpellIcon;
         ItemSprite = CombatSpell2.SpellIcon;
        }

        if(IsPotion)
        {
         this.gameObject.name = potion.ItemName;
         image.sprite = potion.ItemIcon;
         ItemSprite = potion.ItemIcon;
        }

        if(IsTrinket)
        {
         this.gameObject.name = trinket.TrinketName;
         image.sprite = trinket.TrinketIcon;
         ItemSprite = trinket.TrinketIcon;
        }
      
        
    }

    // Update is called once per frame
    void Update()
    {
       
       thisObject = this.gameObject;
       PlayerInventoryCanvas = GameObject.Find("UI").GetComponent<Canvas>();
       canvas = GameObject.Find("Merchant Inventory").GetComponent<Canvas>();
       purchasePanel = GameObject.Find("Confirm Purchase Panel").GetComponent<PurchasePanel>();
       InformationPanel = GameObject.Find("Information Panel Merchant").GetComponent<ShopInformationPanel>();
      
      
    }

    public void CombatSpellPurchase()
    {
      purchasePanel.IsCombatSpell2Purchase = true;
      purchasePanel.IsPotionPurchase = false;
      purchasePanel.IsTrinketPurchase = false;
      purchasePanel.CBSItemToPurchase = CombatSpell2;
      purchasePanel.MerchantItemPrefab = this.gameObject;
      purchasePanel.OpenPanel();
    }

    public void PotionPurchase()
    {
      purchasePanel.IsCombatSpell2Purchase = false;
      purchasePanel.IsPotionPurchase = true;
      purchasePanel.IsTrinketPurchase = false;
      purchasePanel.PTItemToPurchase = potion;
      purchasePanel.MerchantItemPrefab = this.gameObject;


      purchasePanel.OpenPanel();

    }

    public void TrinketPurchase()
    {
      purchasePanel.IsCombatSpell2Purchase = false;
      purchasePanel.IsPotionPurchase = false;
      purchasePanel.IsTrinketPurchase = true;
      purchasePanel.TKItemToPurchase = trinket;
      purchasePanel.MerchantItemPrefab = this.gameObject;

      

      purchasePanel.OpenPanel();

      
    }

    public void UpdateItemToInfoPanel()
    {
      
        InformationPanel.merchantItem = this;
      
    }

    public void OpenPanel()
    {
      InformationPanel.HoveringOn();
      UpdateItemToInfoPanel();
    }

    public void ClosePanel()
    {
      InformationPanel.HoveringOff();
    }

  
}
