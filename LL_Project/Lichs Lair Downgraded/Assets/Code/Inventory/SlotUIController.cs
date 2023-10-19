using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUIController : MonoBehaviour
{
    public PlayerController PC;
    public PlayerMagic PM;
    public PlayerHealth PH;
    public GameObject Player;
    
    [Header("Spell UI")]
    public Image SpellReadyImage1;
    public Image SpellCoolingImage1;

    public Image SpellReadyImage2;
    public Image SpellCoolingImage2;

    public Image UtilitySpellReadyImage;
    public Image UtilitySpellCoolingImage;
    
    [Header("Potion UI")]
    public GameObject HealthPotionAV;
    public GameObject HealthPotionUV;
    public GameObject ManaPotionAV;
    public GameObject ManaPotionUV;

    public GameObject HealthPotionUI;
    public GameObject ManaPotionUI;


    public bool HasHealthPotion;
    public bool HasManaPotion;

    public GameObject HealEffect;
    public GameObject ManaEffect;

    public bool HasPotion;

    

    public Item CurrentPotion;


    public bool TogglePotionUI;

    [Header("Weapon UI")]
    public Slider cooldownSlider;

    

    public Image WeaponReadyImage1;
    public Image FillImage;

    public float HalfNumber;

    [Header("Coin UI")]
   
    public GameObject CoinUI;
    public TMP_Text CoinText;
    public int Coins;
    public Animator CoinUIAnimator;
    public bool ActivateCoinUI;

    [Header("TrinketUI")]
    public bool HasTrinket;

    public Trinket currentTrinket;

    [Header("Pet UI")]
    public bool HasPet;

    public Pet currentPet;
    

    // Start is called before the first frame update

    void Start()
    {

      // Sets Cooling Images off and other sliders off at start
        SpellCoolingImage1.gameObject.SetActive(false);
        SpellCoolingImage2.gameObject.SetActive(false);
        UtilitySpellCoolingImage.gameObject.SetActive(false);
        SetValue();
        cooldownSlider.gameObject.SetActive(false); 
        //ResetCooldown();

        // Sets The text and float values at start
        HalfNumber += (cooldownSlider.value) / 2; 
        CoinText.text = "Coins: " + Coins.ToString();
        

    }

    // Update is called once per frame
    void Update()
    {

      if(HasPotion == false)
      {
         CurrentPotion = null;
      }

      //currentPet = GameObject.Find("Pets").GetComponent<PetManager>().CurrentPetData;

      //if(currentPet != null)
      //{
      //   HasPet = true;
      //}

      // if(currentPet == null)
      //{
       //  HasPet = false;
      //}

      //Coins
      CoinUIAnimator.SetBool("ActivateCoinUI", ActivateCoinUI);

      if(!ActivateCoinUI)
      {
         StopCoroutine(ShowAndHideCoinUI());
         if(Input.GetKeyDown(KeyCode.F))
      {
         StartCoroutine(ShowAndHideCoinUI());
      }
      }

      

      //PotionUses

      // If player has a Health Potion, turn Health Potion UI on;
     if(HasManaPotion == false)
     {
      if(HasHealthPotion == true && HealthPotionUI.active)
      {
         if(Input.GetKeyDown(KeyCode.R))
         {
           GameObject EffectClone;
           EffectClone = Instantiate(HealEffect, Player.transform.position, Quaternion.Euler(-90,0,0));
           EffectClone.transform.parent = Player.gameObject.transform;
           PH.IncreaseHealth(100);
           HasHealthPotion = false;
           //Destroy(GameObject.Find("PotionSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
           //GameObject.Find("PotionSlotContainer").GetComponent<ItemSlotContainer>().ItemInSlot = null;
           HasPotion = false;
         }
      }
     }

      // If player has a Mana Potion, turn Mana Potion UI on;
      
     if(HasHealthPotion == false)
     {
      if(HasManaPotion == true && ManaPotionUI.active)
      {
         if(Input.GetKeyDown(KeyCode.R))
         {
           GameObject EffectClone;
           EffectClone = Instantiate(ManaEffect, Player.transform.position, Quaternion.Euler(-90,0,0));
           EffectClone.transform.parent = Player.gameObject.transform;
           PM.IncreaseMana(100);
           HasManaPotion = false;
           //Destroy(GameObject.Find("PotionSlotContainer").GetComponent<ItemSlotContainer>().ChildObjects[0]);
           //GameObject.Find("PotionSlotContainer").GetComponent<ItemSlotContainer>().ItemInSlot = null;
           HasPotion = false;
           
         }
      }
     }
      

      //PotionUI

      if(HasHealthPotion == true)
      {
         HealthPotionAV.SetActive(true);
         HealthPotionUV.SetActive(false);


      }
      else
      {
        HealthPotionAV.SetActive(false);
         HealthPotionUV.SetActive(true); 
      }

      if(HasManaPotion == true)
      {
         ManaPotionAV.SetActive(true);
         ManaPotionUV.SetActive(false);


      }
      else
      {
        ManaPotionAV.SetActive(false);
         ManaPotionUV.SetActive(true); 
      }
     /*
      if(Input.GetKeyDown(KeyCode.X))
      {
        TogglePotionUI = !TogglePotionUI;
      }


      if(TogglePotionUI)
      {
         HealthPotionUI.SetActive(true);
         ManaPotionUI.SetActive(false);

      }

      if(!TogglePotionUI)
      {
         HealthPotionUI.SetActive(false);
         ManaPotionUI.SetActive(true);

      }
      */

      //Automatically slots the correct spell images based on their data files


       SpellReadyImage1.sprite = PM.CombatSpellSlot1.spellToCast.SpellIcon;
       SpellCoolingImage1.sprite = PM.CombatSpellSlot1.spellToCast.SpellCoolingIcon;
       if(PlayerMagic.Instance.HasAquiredMagic)
       {
        SpellReadyImage2.sprite = PM.CombatSpellSlot2.spellToCast.SpellIcon;
        UtilitySpellReadyImage.sprite = PM.UtilitySpell.spellToCast.SpellIcon;
        SpellCoolingImage2.sprite = PM.CombatSpellSlot2.spellToCast.SpellCoolingIcon;
        UtilitySpellCoolingImage.sprite = PM.UtilitySpell.spellToCast.SpellCoolingIcon;
       }

       
       
       //SetValue();
       if(cooldownSlider.value < HalfNumber)
       {
        
        FillImage.color = new Color32(225, 0, 0, 18);
       }
       else
       {
         FillImage.color = new Color32(225, 214, 0, 18);
       }

       //WeaponUI
       


    }

    

    
   // Reset Cooldown values and Set Cooldown values on start
    public void ResetCooldown()
    {
       cooldownSlider.maxValue = PlayerMagic.Instance.UtilityCoolDown;
       cooldownSlider.value = PlayerMagic.Instance.UtilityCoolDown;
       cooldownSlider.gameObject.SetActive(false); 
    }

    public void SetValue()
    {
       cooldownSlider.maxValue = PlayerMagic.Instance.UtilityCoolDown;
       cooldownSlider.value = PlayerMagic.Instance.UtilityCoolDown; 
    }

    // Set coin Amount on refresh 

    public void SetCoinAmount(int value)
    {
      StartCoroutine(ShowAndHideCoinUI());
      Coins += value;
      CoinText.text = "Coins: " + Coins.ToString();
    }

    public IEnumerator ShowAndHideCoinUI()
    {
      ActivateCoinUI = true;
      yield return new WaitForSeconds(5);
      ActivateCoinUI = false;
    }

    public void ResetPotionFlags()
    {
      HasHealthPotion = false;
      HasManaPotion = false;
    }

    
}
