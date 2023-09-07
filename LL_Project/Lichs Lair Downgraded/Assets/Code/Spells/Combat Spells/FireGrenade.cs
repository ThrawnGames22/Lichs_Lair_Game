using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrenade : MonoBehaviour
{
    public CombatSpellScriptableObject FireGrenadeSpell;
    public CombatSpell combatSpell;
    public DetachParticles detachParticles;

    public GameObject ExplosionPrefab;

    public Rigidbody spellRigidBody;

    public float speed;

//Attributes
    public float fireDamage;
     public float manaCost;
    public float lifetime;

    public Rigidbody SpellRB;

    public float TimeBeforeDrop = 0.5f;

    
    //public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        //if(speed > 0 ) spellRigidBody.AddForce(transform.forward * speed * Time.deltaTime);
        //if(speed > 0 ) spellRigidBody.AddForce(transform.up * speed * Time.deltaTime);
        
            combatSpell.IsAngled = true;
            StartCoroutine(DropFireBomb());
        
    }

    // Update is called once per frame
    void Update()
    {
        //takes data from Scriptable Object
        fireDamage = FireGrenadeSpell.FireDamage;
        manaCost = FireGrenadeSpell.ManaCost;
        //lifetime = FireGrenadeSpell.Lifetime;
        speed = FireGrenadeSpell.Speed;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
            detachParticles.Detach();
            GameObject ExplosionClone = Instantiate(ExplosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        
    }

    public void ReEnableRigidBody()
    {
        
    }

    public IEnumerator DropFireBomb()
    {
        yield return new WaitForSeconds(TimeBeforeDrop);
        combatSpell.IsAngled = false;
    }

    
}
