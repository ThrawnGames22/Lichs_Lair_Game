using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public GameObject Player;
    public PlayerController playerController;

    public GameObject Chicken;
    public GameObject Rat;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        if(playerController.IsFireMage)
        {
            Chicken.SetActive(true);
            Rat.SetActive(false);
        }

        if(playerController.IsShadowWizard)
        {
            Chicken.SetActive(false);
            Rat.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
