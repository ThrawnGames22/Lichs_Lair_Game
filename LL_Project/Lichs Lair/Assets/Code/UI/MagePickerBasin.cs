using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagePickerBasin : MonoBehaviour
{
    public ParticleSystem NormalFire;
    public ParticleSystem MageFire;

    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
       ActivateNormalFire();
       playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateNormalFire()
    {
       NormalFire.Play();
       MageFire.Stop();
    }

    public void ActivateMageFire()
    {
        NormalFire.Stop();
       MageFire.Play();
    }

    public void SetRedMage()
    {
        playerManager.PlayAsRedMage();
    }

     public void SetShadowMage()
    {
        playerManager.PlayAsShadowMage();
    }
}
