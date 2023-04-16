using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotController : MonoBehaviour
{
    [Header("UI Components")]
    public Image WeaponReadyImage;
    public Image WeaponCoolingImage;
    public PlayerController playerController;
    public Slider CoolDownSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        WeaponCoolingImage.gameObject.SetActive(false);
        ResetAllValues();
    }

    // Update is called once per frame
    void Update()
    {
      WeaponReadyImage.sprite = playerController.CurrentWeaponSlot.GetComponent<ItemHandler>().item.ItemIcon;
      WeaponCoolingImage.sprite = playerController.CurrentWeaponSlot.GetComponent<ItemHandler>().item.ItemCoolDownIcon;
      



      if(playerController.CurrentWeaponSlot.tag == "Bow")
      {
        CoolDownSlider.maxValue = playerController.CurrentWeaponSlot.GetComponent<BowController>().CurrentDelayTimer;
        //ResetBowValue();

        if(playerController.CurrentWeaponSlot.GetComponent<BowController>().CanUse == false)
        {
            CoolDownSlider.value -= 1 * Time.deltaTime;
            SetCooldownSliderActive();
            WeaponReadyImage.gameObject.SetActive(false);
            WeaponCoolingImage.gameObject.SetActive(true);
        }
        else
        {
          SetCooldownSliderOff();
          ResetBowValue();
          WeaponReadyImage.gameObject.SetActive(true);
          WeaponCoolingImage.gameObject.SetActive(false);
        }

        
        
      }

      if(playerController.CurrentWeaponSlot.tag == "Sword")
      {
        CoolDownSlider.maxValue = playerController.CurrentWeaponSlot.GetComponent<SwordController>().MeleeWeaponDelay;
        //ResetSwordValue();

        if(playerController.CurrentWeaponSlot.GetComponent<SwordController>().CanUse == false)
        {
            CoolDownSlider.value -= 1 * Time.deltaTime;
            SetCooldownSliderActive();
            WeaponReadyImage.gameObject.SetActive(false);
            WeaponCoolingImage.gameObject.SetActive(true);
        }
        else
        {
          ResetSwordValue();
          SetCooldownSliderOff();
          WeaponReadyImage.gameObject.SetActive(true);
          WeaponCoolingImage.gameObject.SetActive(false);
        }
        
      }

      if(playerController.CurrentWeaponSlot.tag == "Axe")
      {
        
      }
      
    }


    public void ResetBowValue()
    {
      CoolDownSlider.value = playerController.CurrentWeaponSlot.GetComponent<BowController>().CurrentDelayTimer;
    }

     public void ResetSwordValue()
    {
      CoolDownSlider.value = playerController.CurrentWeaponSlot.GetComponent<SwordController>().CurrentDelayTimer;
      
    }

    public void ResetAllValues()
    {
        ResetBowValue();
        ResetSwordValue();
    }

    public void SetCooldownSliderActive()
    {
        CoolDownSlider.gameObject.SetActive(true);
    }

    public void SetCooldownSliderOff()
    {
        CoolDownSlider.gameObject.SetActive(false);
    }
}
