using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject Player;
    public PlayerController playerController;

    public GameObject Chicken;
    public GameObject Rat;

    public GameObject Eagle;


    public GameObject CurrentPet;

    public Pet CurrentPetData;

    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        Chicken.SetActive(false);
        Rat.SetActive(false);
        Eagle.SetActive(false);

        if(playerController.IsFireMage)
        {
            Chicken.SetActive(true);
            Rat.SetActive(false);
            Eagle.SetActive(false);

        }

        if(playerController.IsShadowWizard)
        {
            Chicken.SetActive(false);
            Rat.SetActive(true);
            Eagle.SetActive(false);

        }

        if(playerController.IsPaladin)
        {
            Chicken.SetActive(false);
            Rat.SetActive(false);
            Eagle.SetActive(true);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
       if(GameObject.Find("UI").GetComponent<SlotUIController>().HasPet == true)
       {
        GameObject.Find("UI").GetComponent<SlotUIController>().currentPet = CurrentPet.GetComponent<PetController>().pet;
       }

       if(GameObject.Find("UI").GetComponent<SlotUIController>().HasPet == false)
       {
         TurnOffPets();
       }
       
       if(CurrentPet.name == "Chicken Pet")
       {
        Chicken.SetActive(true);
        Rat.SetActive(false);
       }

       if(CurrentPet == Rat)
       {
        Chicken.SetActive(false);
        Rat.SetActive(true);
       }

       if(CurrentPetData == null)
       {
        TurnOffPets();
        CurrentPet = null;
       }
       */
    }

    public void TurnOffPets()
    {
        Chicken.SetActive(false);
        Rat.SetActive(false);
    }
}
