using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(Rigidbody))]

public class CombatSpell : MonoBehaviour
{

  // SCRIPT THAT AFFECTS THE PHYSICAL SPELL PREFAB NOT THE SPELL ABILITY ITSELF
    public bool UsesBox;
    public bool UsesSphere;
    public bool isProjectile;
    public CombatSpellScriptableObject spellToCast;
    public GameObject SpellObject;

    private SphereCollider spellCollider;
    private BoxCollider spellBoxCollider;

    private Rigidbody spellRigidBody;

    public bool IsAngled;
    public bool UseAngle;

    public bool changeAngle;

    public float LiftSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        if(UsesSphere)
        {
          spellCollider = GetComponent<SphereCollider>();
          spellCollider.isTrigger = true;
          spellCollider.radius = spellToCast.SpellRadius;
        }
        if(UsesBox)
        {
          spellBoxCollider = GetComponent<BoxCollider>();
          spellBoxCollider.isTrigger = true;
          
        }
        

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
           
           if(UseAngle)
           {
           if(IsAngled == true)
           {
            if(spellToCast.Speed > 0 ) spellRigidBody.AddForce(transform.up * LiftSpeed * Time.deltaTime);
           }
           
           
           if(IsAngled == false)
           {
             spellRigidBody.AddForce(-transform.up * LiftSpeed * Time.deltaTime);
           }
           }
           

           if(changeAngle == true)
           {
            if(spellToCast.Speed > 0 ) spellRigidBody.AddForce(-transform.up * spellToCast.Speed * Time.deltaTime);
           }
           if(changeAngle == false)
           {
            return;
           }
        }
        else
        {
          return;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //this.GetComponent<FreezeParticles>().StopParticleMovement();
        //Destroy(SpellObject);
    }
}
