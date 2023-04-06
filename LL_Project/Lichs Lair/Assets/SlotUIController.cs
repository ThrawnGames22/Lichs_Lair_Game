using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUIController : MonoBehaviour
{
    public PlayerController PC;
    public PlayerMagic PM;

    public Image SpellImage;
    public Image WeaponImage;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       SpellImage.sprite = PM.CombatSpellToCast.spellToCast.SpellIcon;
    }
}
