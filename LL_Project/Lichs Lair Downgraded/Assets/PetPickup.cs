using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPickup : MonoBehaviour
{
    public Pet pet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(GameObject.Find("UI").GetComponent<SlotUIController>().HasPet == false)
            {
            GameObject.Find("Pets").GetComponent<PetManager>().CurrentPet = pet.PetGameObject;
            GameObject.Find("Pets").GetComponent<PetManager>().CurrentPetData = pet;
            Destroy(this.gameObject);
            }
        }
    }
}
