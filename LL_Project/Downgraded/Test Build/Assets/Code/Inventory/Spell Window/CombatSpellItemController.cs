using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSpellItemController : MonoBehaviour
{
    CombatSpellScriptableObject combatSpell;

    public void AddItem(CombatSpellScriptableObject newItem)
    {
      combatSpell = newItem;
    }

   

   
}
