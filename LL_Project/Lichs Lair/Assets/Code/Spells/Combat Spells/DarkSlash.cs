using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSlash : MonoBehaviour
{
    public CombatSpellScriptableObject DarkCombatSpell;
    public CombatSpell combatSpell;

//Attributes
    public float DarkDamage;

    public float darkenDamagePerSecond;
     public float manaCost;
    public float lifetime;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //takes data from Scriptable Object
        DarkDamage = DarkCombatSpell.FireDamage;
        manaCost = DarkCombatSpell.ManaCost;
        lifetime = DarkCombatSpell.Lifetime;
        speed = DarkCombatSpell.Speed;
        darkenDamagePerSecond = DarkCombatSpell.DarkenAmount;

    }
}
