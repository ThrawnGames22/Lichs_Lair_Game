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

    

    public Image WeaponReadyImage1;
    

    // Start is called before the first frame update

    void Start()
    {
        SpellCoolingImage1.gameObject.SetActive(false);
        SpellCoolingImage2.gameObject.SetActive(false);
        UtilitySpellCoolingImage.gameObject.SetActive(false);


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



    }
}
