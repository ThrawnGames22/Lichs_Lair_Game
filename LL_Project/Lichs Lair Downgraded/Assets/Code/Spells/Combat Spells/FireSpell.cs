using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    public CombatSpellScriptableObject FireCombatSpell;
    public CombatSpell combatSpell;
    public DetachParticles detachParticles;

//Attributes
    public int fireDamage;
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
        fireDamage = FireCombatSpell.FireDamage;
        manaCost = FireCombatSpell.ManaCost;
        lifetime = FireCombatSpell.Lifetime;
        speed = FireCombatSpell.Speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
            detachParticles.Detach();
            Destroy(this.gameObject);
        
    }

    
}
