using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatType
{
    Fire,
    Ice,
    Posion,
    Drain

}
[CreateAssetMenu(fileName = "New Combat Spell", menuName = "Combat Spells")]
public class CombatSpellScriptableObject : ScriptableObject
{
    
    //Name
    public string SpellName;
    public string Description;
    //Attributes

    public CombatType combatType;
    public float Damage = 10f;
    public float ManaCost = 5f;
    public float Lifetime = 2f;
    public float Speed = 15f;
    public float SpellRadius = 0.5f;

     
   
    
}
