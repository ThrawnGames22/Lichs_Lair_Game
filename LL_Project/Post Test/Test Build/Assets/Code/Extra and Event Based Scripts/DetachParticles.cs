using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachParticles : MonoBehaviour
{
    public ParticleSystem FireParticles;
    public ParticleSystem SmokeParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detach()
    {
        FireParticles.Stop();
        FireParticles.gameObject.transform.parent = null;
        SmokeParticles.Stop();
        SmokeParticles.gameObject.transform.parent = null;
        
    }

    
}
