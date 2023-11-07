using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketManager : MonoBehaviour
{

    public Trinket CurrentTrinket;
    public bool HasTrinket;

    public PlayerController PC;

    public PlayerHealth PH;

    public PlayerMagic PM;
    public bool HasFoundWeapon;


//RESET VALUES//
    public float NormalHealthRegenSW;
    public float NormalHealthRegenFM;
    public float NormalHealthRegenPD;

    public int NormalManaRegenSW;
    public int NormalManaRegenFM;
    public int NormalManaRegenPD;

    public float NormalSwordCooldownPaladin;
    public float NormalSwordCooldownFireMage;
    public float NormalBowCooldown;




    // Start is called before the first frame update
    void Start()
    {
        NormalBowCooldown = 5;
          NormalSwordCooldownFireMage = 5;
          NormalSwordCooldownPaladin = 5;
          
          
    }

    // Update is called once per frame
    void Update()
    {
      
        //COMMON//
      if(HasTrinket == true)
      {
        if(CurrentTrinket.name == "Small Blue Gem")
        {
          if(PC.IsFireMage)
          {
            PM.maxMana = 115;
          }

          if(PC.IsShadowWizard)
          {
            PM.maxMana = 140;
          }
          if(PC.IsPaladin)
          {
            PM.maxMana = 90;
          }
         
        }

         if(CurrentTrinket.name == "Iron Beetle")
        {
          if(PC.IsFireMage)
          {
            PH.maxHealth = 115;
          }

          if(PC.IsShadowWizard)
          {
            PH.maxHealth = 90;
            
          }
          if(PC.IsPaladin)
          {
            PH.maxHealth = 140;
            
          }
          
        }

        if(CurrentTrinket.name == "Calm Stone")
        {
          PH.HealthToRegen = 1;
        }

         if(CurrentTrinket.name == "Enchanted HartsHorn")
        {
          if(PC.CurrentWeaponSlot.name == "Paladin Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 4.5f;
          }

          if(PC.CurrentWeaponSlot.name == "Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 4.5f;
          }

          if(PC.CurrentWeaponSlot.name == "Bow")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Bow").GetComponent<BowController>().CurrentDelayTimer = 4.5f;
          }
        }

         if(CurrentTrinket.name == "Wizards Journal")
        {
          PM.UtilitySpellData.CoolingDownTime = PM.UtilitySpellData.CoolingDownTime = 18;
        }

         if(CurrentTrinket.name == "Charged Coin")
        {
          PM.ManaToRegen = 4;
        }



        //RARE//
        
        if(CurrentTrinket.name == "Mana Cyrstal")
        {
          if(PC.IsFireMage)
          {
            PM.maxMana = 130;
          }

          if(PC.IsShadowWizard)
          {
            PM.maxMana = 155;
          }
          if(PC.IsPaladin)
          {
            PM.maxMana = 105;
          }
        }

        if(CurrentTrinket.name == "Dragon Scale charm")
        {
          if(PC.IsFireMage)
          {
            PH.maxHealth = 130;
          }

          if(PC.IsShadowWizard)
          {
            PH.maxHealth = 105;
            
          }
          if(PC.IsPaladin)
          {
            PH.maxHealth = 155;
            
          }
        }

        if(CurrentTrinket.name == "Bottled Lightning")
        {
          PM.ManaToRegen = 6;
        }

        if(CurrentTrinket.name == "Giant Kin Guantlets")
        {
           if(PC.CurrentWeaponSlot.name == "Paladin Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 4f;
          }

          if(PC.CurrentWeaponSlot.name == "Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 4f;
          }

          if(PC.CurrentWeaponSlot.name == "Bow")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Bow").GetComponent<BowController>().CurrentDelayTimer = 4f;
          }
        }

        if(CurrentTrinket.name == "Heart Ring")
        {
            PH.HealthToRegen = 2;
        }

        if(CurrentTrinket.name == "Sorcery Focus")
        {
          PM.UtilitySpellData.CoolingDownTime = PM.UtilitySpellData.CoolingDownTime = 16;
        }




        //LEGENDARY//

        if(CurrentTrinket.name == "Black Gem")
        {
          if(PC.IsFireMage)
          {
            PM.maxMana = 200;
            PH.maxHealth = 75;
          }

          if(PC.IsShadowWizard)
          {
            PM.maxMana = 225;
            PH.maxHealth = 50;

          }
          if(PC.IsPaladin)
          {
            PM.maxMana = 175;
            PH.maxHealth = 100;

          }
        }

        if(CurrentTrinket.name == "Vyngrids Wardmail")
        {
          if(PC.IsFireMage)
          {
            PH.maxHealth = 200;
            PM.maxMana = 75;

          }

          if(PC.IsShadowWizard)
          {
            PH.maxHealth = 175;
            PM.maxMana = 100;

            
          }
          if(PC.IsPaladin)
          {
            PH.maxHealth = 225;
            PM.maxMana = 50;

            
          }
        }

        if(CurrentTrinket.name == "Tome of Forbidden Magic")
        {
          PM.ManaToRegen = 15;
          if(PC.IsFireMage)
          {
            
            PM.maxMana = 75;

          }

          if(PC.IsShadowWizard)
          {
           
            PM.maxMana = 100;

            
          }
          if(PC.IsPaladin)
          {
            
            PM.maxMana = 50;

            
          }
        }

        if(CurrentTrinket.name == "Devils Mark")
        {
          PH.HealthToRegen = 5;
          if(PC.IsFireMage)
          {
            
            PH.maxHealth = 75;
          }

          if(PC.IsShadowWizard)
          {
            
            PH.maxHealth = 50;

          }
          if(PC.IsPaladin)
          {
            
            PH.maxHealth = 100;

          }
        }

        if(CurrentTrinket.name == "Lycans Ring")
        {
          PM.UtilitySpellData.CoolingDownTime = PM.UtilitySpellData.CoolingDownTime = 24;
           if(PC.CurrentWeaponSlot.name == "Paladin Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 3.5f;
          }

          if(PC.CurrentWeaponSlot.name == "Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 3.5f;
          }

          if(PC.CurrentWeaponSlot.name == "Bow")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Bow").GetComponent<BowController>().CurrentDelayTimer = 3.5f;
          }
        }

        if(CurrentTrinket.name == "Cultist Concoction")
        {
          PM.UtilitySpellData.CoolingDownTime = PM.UtilitySpellData.CoolingDownTime = 10;
           if(PC.CurrentWeaponSlot.name == "Paladin Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 5.75f;
          }

          if(PC.CurrentWeaponSlot.name == "Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 5.75f;
          }

          if(PC.CurrentWeaponSlot.name == "Bow")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Bow").GetComponent<BowController>().CurrentDelayTimer = 5.75f;
          }
        }
      }

        //NULL//

        if(HasTrinket == false)
        {
          NormalBowCooldown = 5;
          NormalSwordCooldownFireMage = 5;
          NormalSwordCooldownPaladin = 5;
          PM.ManaToRegen = 1;
          PM.RegenTime = 1;
          PM.UtilitySpellData.CoolingDownTime = PM.UtilitySpellData.NormalCoolingDownTime;
          PH.HealthToRegen = 0.5f;
          PH.RegenTime = 1f;

          if(PC.IsPaladin)
          {
            PM.maxMana = 75;
            PH.maxHealth = 125;
          }

          if(PC.IsShadowWizard)
          {
            PM.maxMana = 125;
            PH.maxHealth = 75;
          }
          if(PC.IsFireMage)
          {
            PM.maxMana = 100;
            PH.maxHealth = 125;
          }

           if(PC.CurrentWeaponSlot.name == "Paladin Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 5f;
          }

          if(PC.CurrentWeaponSlot.name == "Sword")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>().MeleeWeaponDelay = 5f;
          }

          if(PC.CurrentWeaponSlot.name == "Bow")
          {
            HasFoundWeapon = true;
            GameObject.FindGameObjectWithTag("Bow").GetComponent<BowController>().CurrentDelayTimer = 5f;
          }
        }


    }
}
