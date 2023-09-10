using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGrenadeBoss : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    public Rigidbody spellRigidBody;
    public DetachParticles detachParticles;

    public float speed;


    public float fireDamage;
     
    public float lifetime;

    public Rigidbody FireGrenadeRB;

    public float TimeBeforeDrop = 0.5f;

    public bool IsAngled;
    public bool UseAngle;

    public bool changeAngle;

    public float LiftSpeed;

    public bool isProjectile = true;
    // Start is called before the first frame update
    void Start()
    {

        
        
            //StartCoroutine(DropFireBomb());
    }

    // Update is called once per frame
    void Update()
    {
       
           spellRigidBody.AddForce(transform.forward * 10);
           spellRigidBody.useGravity = true;
           
          
        
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
        // /IsAngled = false;
    }

}
