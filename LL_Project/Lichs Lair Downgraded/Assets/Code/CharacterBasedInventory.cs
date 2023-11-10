using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
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

    [Header("Pet")]

    public Pet CurrentPet;


    


    [Header("UI")]

    public GameObject InventoryPanel;

    public Image WeaponSlot;
    public Image TrinketSlot; 
    public Image PotionSlot; 
    public Image PetSlot;

    public Image CBSSlot1;
    public Image CBSSlot2;
    public Image UTSSlot; 

    public SlotUIController slotUIController;

    public ItemSlotContainer PotionSlotContainer;

    public bool InvenOpen;

    public InventoryItemDataBase inventoryItemDataBase;

    public TrinketManager trinketManager;

    public PlayerController PC;

    public PlayerMagic PM;

    public TrinketManager TM;

    [Header("Empty Slot Icons")]

    public Sprite EmptyItemSprite;

    [Header("Drop Slots")]
    //public GameObject WDrop;
    public GameObject PDrop;
    public GameObject TDrop;
    public GameObject PTDrop;

    public Transform DropPos;

   
   


    
    // Start is called before the first frame update
    void Start()
    {
        //WDrop.SetActive(false);
        PDrop.SetActive(false);
        TDrop.SetActive(false);
        PTDrop.SetActive(false);
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
            
            //WEAPON//
            WeaponSlot.sprite = PC.CurrentWeaponSlot.GetComponent<WeaponHandler>().weapon.WeaponIcon;

            CBSSlot1.sprite = PM.Spell1.SpellIcon;

            UTSSlot.sprite = PM.UtilitySpellData.SpellIcon;
            
            if(PM.HasSecondarySpell)
            {
            CBSSlot2.sprite = PM.Spell2.SpellIcon;
            }


            //POTION//
            if(slotUIController.HasPotion == true)
            {
              PotionSlot.sprite = slotUIController.CurrentPotion.ItemIcon;
            }

            if(slotUIController.HasPotion == false)
            {
              PotionSlot.sprite = EmptyItemSprite; 
            }

            //TRINKETS//

            if(trinketManager.HasTrinket == true)
            {
              TrinketSlot.sprite = trinketManager.CurrentTrinket.TrinketIcon;
            }

            if(trinketManager.HasTrinket == false)
            {
              TrinketSlot.sprite = EmptyItemSprite; 
            }

            //PET//
            if(slotUIController.HasPet == true)
            {
              PetSlot.sprite = slotUIController.currentPet.PetIcon;
            }

            if(slotUIController.HasPet == false)
            {
              PetSlot.sprite = EmptyItemSprite; 
            }

            
        }
        if(!InvenOpen)
        {
            InventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
            PDrop.SetActive(false);
        TDrop.SetActive(false);
        PTDrop.SetActive(false);
        }

        TrinketSlot.gameObject.GetComponent<Image>().preserveAspect = true;

        
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
   

   //WEAPON//
    public void WDropButtonOn()
    {
     //WDrop.SetActive(true);
    }

    public void WDropButtonOff()
    {
      //WDrop.SetActive(false);
    }
   //POTION
    public void PDropButtonOn()
    {
     PDrop.SetActive(true);
    }

    public void PDropButtonOff()
    {
     PDrop.SetActive(false);
    }
   //TRINKET//
    public void TDropButtonOn()
    {
      TDrop.SetActive(true);
    }
  
    public void TDropButtonOff()
    {
      TDrop.SetActive(false);
    }
   //PET//
    public void PTDropButtonOn()
    {
     PTDrop.SetActive(true);
    }

    public void PTDropButtonOff()
    {
     PTDrop.SetActive(false);
    }

    public void DropPotion()
    {
      GameObject PotionClone = Instantiate(slotUIController.CurrentPotion.ItemGameObject, DropPos.position, DropPos.rotation);
      slotUIController.CurrentPotion = null;
      slotUIController.ResetPotionFlags();
      slotUIController.HasPotion = false;
      
    }

    public void DropTrinket()
    {
      if(TM.CurrentTrinket.name == "Calm Stone")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(29.724f, 0f, 0f));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Wizards Journal")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(0, 90, 30));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Charged Coin")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(45, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Dragon Scale Charm")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(45.872f, 0, 0.299f));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Enchanted HartsHorn")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(60, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Small Blue Gem")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(-37.04f, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Mana Cyrstal")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(60, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Iron Beetle")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(-42.511f, 0.883f, 8.532f));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Sorcery Focus")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(51.51f, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Bottled Lightning")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(90, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Heart Ring")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(0, 90, 45));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Giant Kin Guantlets")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(60, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Vyngrids Wardmail")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(60, 0, 180));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Cultist Concoction")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(0, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Tome Of Forbidden Magic")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(45, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Devils Mark")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(45, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Black Gem")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(0, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      if(TM.CurrentTrinket.name == "Lycans Ring")
      {
      GameObject TrinketClone = Instantiate(TM.CurrentTrinket.TrinketGameObject, DropPos.position, Quaternion.Euler(0, 0, 0));
      TM.CurrentTrinket = null;
      TM.HasTrinket = false;
      }

      
    }

    public void DropPet()
    {
      GameObject PetCageClone = Instantiate(slotUIController.currentPet.PetDropObject, DropPos.position, DropPos.rotation);
      GameObject.Find("Pets").GetComponent<PetManager>().CurrentPetData = null;
      slotUIController.currentPet = null;
      slotUIController.HasPet = false;
    }

    



    
}
