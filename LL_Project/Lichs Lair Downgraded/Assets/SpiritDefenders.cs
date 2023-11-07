using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritDefenders : MonoBehaviour
{
    public Animator SpellAnimator;
    public GameObject Player;

    public float TimeTillDestruction;

    public CombatSpell combatSpell;

    public int Damage;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        TimeTillDestruction = 6f;
        DestroySpell();
        
        
    }

    private void Update() {
        Damage = combatSpell.spellToCast.LightningDamage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Player.transform.position;
        
    }


    void DestroySpell()
    {
        Destroy(this.gameObject, TimeTillDestruction);
    }
}
