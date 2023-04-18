using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mage Class", menuName = "Class/Create New Mage Class")]
public class ClassData : ScriptableObject
{
    public enum MageClassType
    {
        Fire,
        Shadow,
        Sun
    }
    public MageClassType MageType;
    public string ClassName;
    public int maxMana;
    public int maxHealth;
    public CombatSpell CombatSpell1;
    public CombatSpell CombatSpell2;
    public UtilitySpell UtilitySpell;
    public GameObject Trinket;
    public GameObject Pet;
    public GameObject StarterWeapon;
    
}
