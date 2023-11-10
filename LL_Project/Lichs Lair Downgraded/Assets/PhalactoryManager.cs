using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhalactoryManager : MonoBehaviour
{

    public TheLich lichController;

    public int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = lichController.CurrentHealth;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "FireSpell")
        {
            lichController.TakeDamage(other.gameObject.GetComponent<CombatSpell>().spellToCast.FireDamage);
            //Destroy(other);
        }

        if(other.gameObject.tag == "DarkSpell")
        {
            lichController.TakeDamage(other.gameObject.GetComponent<CombatSpell>().spellToCast.DarkenAmount);
            //Destroy(other);

        }

        if(other.gameObject.tag == "LightningSpell")
        {
            lichController.TakeDamage(other.gameObject.GetComponent<CombatSpell>().spellToCast.LightningDamage);
            //Destroy(other);

        }
    }
}
