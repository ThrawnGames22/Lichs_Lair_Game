using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitySpell : MonoBehaviour
{
    //HANDLES UTILITY SPELL
    public UtilitySpellScriptableObject spellToCast;

    private SphereCollider spellCollider;
    private Rigidbody spellRigidBody;
    public bool IsAttachedToPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        spellCollider = GetComponent<SphereCollider>();
        spellCollider.isTrigger = true;
        spellCollider.radius = spellToCast.SpellRadius;

        spellRigidBody = GetComponent<Rigidbody>();
        spellRigidBody.useGravity = false;

        Destroy(this.gameObject, spellToCast.Lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //Attaches spell to player
        if(!IsAttachedToPlayer)
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
        
    }
}
