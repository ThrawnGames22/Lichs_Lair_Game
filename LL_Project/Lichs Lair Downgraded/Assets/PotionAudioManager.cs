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

    public bool HasHealthPotion;
    public bool HasManaPotion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slotUIController = GameObject.Find("UI").GetComponent<SlotUIController>();
        /*
        if(HasHealthPotion)
        {
            
            //PotionSource.Play(); 
            if(Input.GetKeyDown(KeyCode.R))
            {
                PotionSource.clip = HealthPotionSound;
                PotionSource.Play(); 
                
            }
        }
        if(slotUIController.HasHealthPotion == false)
        {
            HasHealthPotion = false;
        }

        if(slotUIController.HasHealthPotion == true)
        {
            HasHealthPotion = true;
        }

        if(slotUIController.HasManaPotion == true)
        {
            HasManaPotion = true;
        }

        if(slotUIController.HasManaPotion == false)
        {
            HasManaPotion = false;
        }
        

        if(HasManaPotion == true)
        {
            
            //PotionSource.Play(); 
            if(Input.GetKeyDown(KeyCode.R))
            {
                PotionSource.clip = ManaPotionSound;
                PotionSource.Play(); 
                
            }
        }
        */
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Mana Potion")
        {
            if(slotUIController.HasManaPotion == false)
            {
            PotionSource.clip = PickupSound;
                PotionSource.Play(); 
            }
        }

        if(other.gameObject.name == "Health Potion")
        {
             if(slotUIController.HasHealthPotion == false)
            {
            PotionSource.clip = PickupSound;
                PotionSource.Play(); 
            }
        }
    }
}
