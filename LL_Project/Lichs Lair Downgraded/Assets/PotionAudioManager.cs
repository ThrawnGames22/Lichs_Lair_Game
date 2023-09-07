using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAudioManager : MonoBehaviour
{
    public AudioSource PotionSource;

    public AudioClip HealthPotionSound;
    public AudioClip ManaPotionSound;

    public AudioClip PickupSound;

    public SlotUIController slotUIController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slotUIController.HasHealthPotion)
        {
            
            //PotionSource.Play(); 
            if(Input.GetKeyDown(KeyCode.R))
            {
                PotionSource.clip = HealthPotionSound;
                PotionSource.Play(); 
            }
        }
        

        if(slotUIController.HasManaPotion)
        {
            
            //PotionSource.Play(); 
            if(Input.GetKeyDown(KeyCode.R))
            {
                PotionSource.clip = ManaPotionSound;
                PotionSource.Play(); 
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Mana Potion")
        {
            PotionSource.clip = PickupSound;
                PotionSource.Play(); 
        }

        if(other.gameObject.name == "Health Potion")
        {
            PotionSource.clip = PickupSound;
                PotionSource.Play(); 
        }
    }
}
