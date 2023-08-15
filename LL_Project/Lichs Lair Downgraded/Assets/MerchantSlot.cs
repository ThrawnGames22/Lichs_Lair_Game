using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MerchantSlot : MonoBehaviour, IDropHandler
{
    public bool ItemIsInSlot;
    public GameObject ItemInSlot;

   

[Header("DataObjects")]
    //DataObjects
    public Weapon weapon;
    public Item Potion;
    public Pet pet;
    public CombatSpellScriptableObject CombatSpell1;
    public CombatSpellScriptableObject CombatSpell2;
    public UtilitySpellScriptableObject UtilitySpell;
    public void OnDrop(PointerEventData eventData)
    {
        //Weapon
    }

    private void Update() 
    {
      
    }
}
