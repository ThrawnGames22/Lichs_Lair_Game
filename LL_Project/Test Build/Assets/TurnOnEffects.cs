using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnEffects : MonoBehaviour
{
    public ParticleSystem PSFire;
    public ParticleSystem PSSmoke;
    public GameObject Light;

    // Start is called before the first frame update
    void Start()
    {
       TurnOff(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn()
    {
       
        PSFire.Play();
        PSSmoke.Play();
        Light.SetActive(true);
        
    }

    public void TurnOff()
    {
        
        PSFire.Stop();
        PSSmoke.Stop();
        Light.SetActive(false);
    }
    
}
