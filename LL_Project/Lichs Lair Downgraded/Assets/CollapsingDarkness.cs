using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingDarkness : MonoBehaviour
{
     public bool HasSpawned;
    public float TotalSpellLifetime;

    public CombatSpell combatSpell;

    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Damage = combatSpell.spellToCast.DarkenAmount;
        TotalSpellLifetime = combatSpell.spellToCast.Lifetime;
        Destroy(this.gameObject, TotalSpellLifetime);
    }

    
     
      
    
}
