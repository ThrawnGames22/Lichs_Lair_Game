using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject WeaponSlot;
    public GameObject TrinketSlot; 
    public GameObject PotionSlot; 
    public GameObject PetSlot;

    public GameObject CBSSlot1;
    public GameObject CBSSlot2;
    public GameObject UTSSlot; 



    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
