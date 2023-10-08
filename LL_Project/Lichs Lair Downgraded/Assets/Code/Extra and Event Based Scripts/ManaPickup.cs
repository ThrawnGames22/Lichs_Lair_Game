using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{
  public Item PotionItem;
  //public AudioClip PickupSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupMana()
    {
      GameObject.Find("UI").GetComponent<SlotUIController>().HasManaPotion = true;
      GameObject.Find("UI").GetComponent<SlotUIController>().CurrentPotion = PotionItem;
      
           
      Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerPickupCollider")
        {
          //GameObject.Find("PotionSource").GetComponent<AudioSource>().clip = PickupSound;
            if(GameObject.Find("UI").GetComponent<SlotUIController>().HasManaPotion == false && GameObject.Find("UI").GetComponent<SlotUIController>().HasPotion == false)
            {
              PickupMana();
              GameObject.Find("UI").GetComponent<SlotUIController>().HasPotion = true;
            }
        }
    }
}
