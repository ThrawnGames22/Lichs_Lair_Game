using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagePickerBasin : MonoBehaviour
{
    public ParticleSystem NormalFire;
    public ParticleSystem MageFire;

    public PlayerManager playerManager;
    public GameObject MageImageFadeIn;
    public GameObject MageImageFadeOut;

    
    // Start is called before the first frame update
    void Start()
    {
       NormalFire.Play();
       MageFire.Stop();
       playerManager = GameObject.Find("GameManager(Clone)").GetComponent<PlayerManager>();
       MageImageFadeIn.SetActive(false);
       MageImageFadeOut.SetActive(false);

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateNormalFire()
    {
       NormalFire.Play();
       MageFire.Stop();
       MageImageFadeOut.SetActive(true);
       MageImageFadeIn.SetActive(false);
      
       
    }

    public void ActivateMageFire()
    {
       NormalFire.Stop();
       MageFire.Play();
       MageImageFadeOut.SetActive(false);
       MageImageFadeIn.SetActive(true);
       
    }

    public void SetRedMage()
    {
        playerManager.PlayAsRedMage();
    }

    public void SetShadowMage()
    {
        playerManager.PlayAsShadowMage();
    }

    public void SetSunMage()
    {
        playerManager.PlayAsSunMage();
    }

    
}
