using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FireParticles : MonoBehaviour
{
    public ParticleSystem FireParticleSystem;
    public ParticleSystem AshParticleSystem;
    public GameObject FireLight;

    // Start is called before the first frame update
    void Start()
    {
        FireParticleSystem.Stop();
        AshParticleSystem.Stop();
        FireLight.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnFireOn()
    {
        FireParticleSystem.Play();
        AshParticleSystem.Play();
        FireLight.SetActive(true);
    }

    public void TurnFireOff()
    {
        FireParticleSystem.Stop();
        AshParticleSystem.Stop();
        FireLight.SetActive(false);

    }
}
