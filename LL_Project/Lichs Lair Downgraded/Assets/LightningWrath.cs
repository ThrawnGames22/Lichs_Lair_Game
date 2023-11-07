using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningWrath : MonoBehaviour
{
    public CombatSpell combatSpell;

    public int Damage;

    public float LifeTime;

    public Transform LightningWrathLocator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LightningWrathLocator = GameObject.Find("LightningWrathLocator").transform;
        this.gameObject.transform.position = LightningWrathLocator.transform.position;
        this.gameObject.transform.rotation = LightningWrathLocator.transform.rotation;

        Damage = combatSpell.spellToCast.LightningDamage;
        LifeTime = combatSpell.spellToCast.Lifetime;
        Destroy(this.gameObject, LifeTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().enemyCurrentHealth -= Damage;
        }
    }
}
