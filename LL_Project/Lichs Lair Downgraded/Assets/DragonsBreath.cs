using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DragonsBreath : MonoBehaviour
{

    public BreathColldier breathColldier;
    public CombatSpell combatSpell;

    public int Damage;

    public float Lifetime;

    public Transform DragonBreathLocator;

    public ParticleSystem FireBreath1;
    public ParticleSystem FireBreath2;
    public ParticleSystem FireBreath3;
    public ParticleSystem FireBreath4;

    public ParticleSystem GroundFireBreath1;
    public ParticleSystem GroundFireBreath2;
    public ParticleSystem GroundFireBreath3;
    public ParticleSystem GroundFireBreath4;
    public ParticleSystem GroundFireBreath5;
    public ParticleSystem GroundFireBreath6;



    // Start is called before the first frame update
    void Start()
    {
        FireBreath1.Stop();
        GroundFireBreath1.Stop();

        FireBreath2.Stop();
        GroundFireBreath2.Stop();

        FireBreath3.Stop();
        GroundFireBreath3.Stop();
        
        FireBreath4.Stop();
        GroundFireBreath4.Stop();

        GroundFireBreath5.Stop();
        GroundFireBreath6.Stop();


        StartCoroutine(Particles());
    }

    // Update is called once per frame
    void Update()
    {
       DragonBreathLocator = GameObject.Find("Dragons Breath Locator").transform;
       Damage = combatSpell.spellToCast.FireDamage;
       Lifetime = combatSpell.spellToCast.Lifetime;
       this.transform.position = DragonBreathLocator.position;
       this.transform.rotation = DragonBreathLocator.rotation;

       Destroy(this.gameObject, Lifetime);
    }

    public IEnumerator Particles()
    {
        FireBreath1.Play();
        GroundFireBreath1.Play();

        FireBreath2.Play();
        GroundFireBreath2.Play();

        FireBreath3.Play();
        GroundFireBreath3.Play();
        
        FireBreath4.Play();
        GroundFireBreath4.Play();

        GroundFireBreath5.Play();
        GroundFireBreath6.Play();


        yield return new WaitForSeconds(4);

        FireBreath1.Stop();
        GroundFireBreath1.Stop();

        FireBreath2.Stop();
        GroundFireBreath2.Stop();

        FireBreath3.Stop();
        GroundFireBreath3.Stop();
        
        FireBreath4.Stop();
        GroundFireBreath4.Stop();

        GroundFireBreath5.Stop();
        GroundFireBreath6.Stop();

    }
    

    
}
