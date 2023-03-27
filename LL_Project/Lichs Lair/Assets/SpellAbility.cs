using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;




public enum SpellType
    {
        CombatSpell,
        UtilitySpell
        



    }

public enum EffectType
    {
        Fire,
        Ice,
        Drain,
        Shroud,
        Slow,

        Enhance,
        Heal,
        Summon
        



    }

    [System.Serializable]
public class SpellAbility
{
    
      
    
    
        public string name, description;

        public int manaCost;

        public float castTime;

        public SpellType spellType;
        
        public EffectType effectType;

        public GameObject SpellPrefab;

        public bool hasBeenDiscovered;


    
    
}





