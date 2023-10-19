using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningToss : MonoBehaviour
{
    public CombatSpellScriptableObject LigtningSpell;
    public CombatSpell combatSpell;
    public DetachParticles detachParticles;

    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Damage = combatSpell.spellToCast.LightningDamage;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy")
        {
            
        }
    }
}
