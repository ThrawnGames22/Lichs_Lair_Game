using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public ParticleSystem LeftTorch;
    public ParticleSystem LeftAsh;
    public Light LeftLight;


    public ParticleSystem RightTorch;
    public ParticleSystem RightAsh;
    public Light RightLight;

    // Start is called before the first frame update
    void Start()
    {
          LeftTorch.Stop();
          LeftAsh.Stop();
          RightTorch.Stop();
          RightTorch.Stop();
          LeftLight.enabled = false;
          RightLight.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
          LeftTorch.Play();
          LeftAsh.Play();
          RightTorch.Play();
          RightTorch.Play();
          LeftLight.enabled = true;
          RightLight.enabled = true;

        }
    }
}
