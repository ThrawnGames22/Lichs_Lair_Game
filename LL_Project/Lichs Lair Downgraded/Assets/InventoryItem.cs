using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [SerializeField] private Canvas canvas;
    public RectTransform ItemSlotRect;
    public string ItemType;
    public Vector2 SlotSpace;
    public Image image;

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
    // Start is called before the first frame update
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
        
    }
}
