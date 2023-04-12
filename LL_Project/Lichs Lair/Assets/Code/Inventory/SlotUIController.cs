using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUIController : MonoBehaviour
{
    public PlayerController PC;
    public PlayerMagic PM;

    public Image SpellReadyImage1;
    public Image SpellCoolingImage1;

    public Image SpellReadyImage2;
    public Image SpellCoolingImage2;

    public Image UtilitySpellReadyImage;
    public Image UtilitySpellCoolingImage;

    public Slider cooldownSlider;

    

    public Image WeaponReadyImage1;
    public Image FillImage;

    public float HalfNumber;
    

    // Start is called before the first frame update

    void Start()
    {
        SpellCoolingImage1.gameObject.SetActive(false);
        SpellCoolingImage2.gameObject.SetActive(false);
        UtilitySpellCoolingImage.gameObject.SetActive(false);
        SetValue();
        cooldownSlider.gameObject.SetActive(false); 
        //ResetCooldown();
        HalfNumber += (cooldownSlider.value) / 2; 

    }

    // Update is called once per frame
    void Update()
    {
       SpellReadyImage1.sprite = PM.CombatSpellSlot1.spellToCast.SpellIcon;
       SpellReadyImage2.sprite = PM.CombatSpellSlot2.spellToCast.SpellIcon;
       UtilitySpellReadyImage.sprite = PM.UtilitySpell.spellToCast.SpellIcon;

       SpellCoolingImage1.sprite = PM.CombatSpellSlot1.spellToCast.SpellCoolingIcon;
       SpellCoolingImage2.sprite = PM.CombatSpellSlot2.spellToCast.SpellCoolingIcon;
       UtilitySpellCoolingImage.sprite = PM.UtilitySpell.spellToCast.SpellCoolingIcon;
       //SetValue();
       if(cooldownSlider.value < HalfNumber)
       {
        
        FillImage.color = new Color32(225, 0, 0, 18);
       }
       else
       {
         FillImage.color = new Color32(225, 214, 0, 18);
       }


    }

    

    

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

    
}
