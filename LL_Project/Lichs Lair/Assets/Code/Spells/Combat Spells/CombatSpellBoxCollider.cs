using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CombatSpellBoxCollider : MonoBehaviour
{
    public bool isProjectile;
    public CombatSpellScriptableObject spellToCast;
    public GameObject SpellObject;

    private BoxCollider spellCollider;
    private Rigidbody spellRigidBody;
    // Start is called before the first frame update
    void Awake()
    {
        spellCollider = GetComponent<BoxCollider>();
        spellCollider.isTrigger = true;
        

        spellRigidBody = GetComponent<Rigidbody>();
        spellRigidBody.useGravity = false;

        Destroy(this.gameObject, spellToCast.Lifetime);
    }

    // Update is called once per frame
    void Update()
    {
       if(isProjectile)
        {
           if(spellToCast.Speed > 0 ) spellRigidBody.AddForce(transform.forward * spellToCast.Speed * Time.deltaTime);
        }
        else
        {
          return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<FreezeParticles>().StopParticleMovement();
        Destroy(SpellObject);
    }
}
