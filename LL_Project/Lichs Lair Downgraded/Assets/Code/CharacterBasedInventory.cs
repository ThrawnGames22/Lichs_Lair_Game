using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBasedInventory : MonoBehaviour
{
    

    [Header("Spells")]

    public UtilitySpellScriptableObject CurrentUtilitySpell;
    public CombatSpellScriptableObject CurrentCombatSpell1;
    public CombatSpellScriptableObject CurrentCombatSpell2;


    [Header("Item")]

    public Item CurrentPotion;

     [Header("Weapon")]

    public Weapon CurrentWeapon;


    


    [Header("UI")]

    public GameObject InventoryPanel;

    public Image WeaponSlot;
    public Image TrinketSlot; 
    public Image PotionSlot; 
    public Image PetSlot;

    public GameObject CBSSlot1;
    public GameObject CBSSlot2;
    public GameObject UTSSlot; 

    public SlotUIController slotUIController;

    public ItemSlotContainer PotionSlotContainer;

    public bool InvenOpen;

    public InventoryItemDataBase inventoryItemDataBase;

    public PlayerController PC;



    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            InvenOpen = !InvenOpen;

            
        }

        if(InvenOpen)
        {
            //UpdateSlot();
            InventoryPanel.GetComponent<CanvasGroup>().alpha = 1;

            WeaponSlot.sprite = PC.CurrentWeaponSlot.GetComponent<WeaponHandler>().weapon.WeaponIcon;
            
        }
        if(!InvenOpen)
        {
            InventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
        }

        
    }

    /*public void UpdateSlot()
    {
      if(slotUIController.HasPotion == false)
      {
        Destroy(PotionSlotContainer.ChildObjects[0]);
      }

      if(slotUIController.HasHealthPotion == true)
      {
        GameObject HPClone = Instantiate(inventoryItemDataBase.HealthPotionItem);
      }
    }
    */
}
