
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRewardManager : MonoBehaviour
{
    public GameObject UncommonChest;
    public GameObject RareChest;
    public GameObject LegendaryChest;


    public bool IsUncommon;
    public bool IsRare;
    public bool IsLegendary;
    
    public int chanceDigit;

    public bool HasChosenDigit;

    public GameObject ChosenChest;

    public Transform ChestSpawnPoint;

    public bool ChestHasSpawned;

    public ChestTrigger chestTrigger;



   /* public bool IsBetween(double testValue, double bound1, double bound2)
    {
        return(testValue >= Math.Min(bound1,bound2) && testValue <= Math.Min(bound1, bound2));
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //debug Chance
        /*
        if(Input.GetKeyDown(KeyCode.Keypad9))
        {
            chanceDigit = UnityEngine.Random.Range(0, 101);
        }
        */

        if(chestTrigger.PlayerIsInTrigger == true)
        {
            if(!HasChosenDigit)
            {
              chanceDigit = UnityEngine.Random.Range(0, 101);
              HasChosenDigit = true;
            }
            if(ChestHasSpawned == false)
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    
                    GameObject ChestSpawn = Instantiate(ChosenChest, ChestSpawnPoint.position, ChestSpawnPoint.rotation);
                    ChestHasSpawned = true;

                }
            }
        }

        if(chanceDigit >= 1 && chanceDigit <= 60)
        {
            IsUncommon = true;
            IsRare = false;
            IsLegendary = false;
            ChosenChest = UncommonChest;
        }

        if(chanceDigit >= 61 && chanceDigit <= 90)
        {
            IsRare = true;
            IsUncommon = false;
            IsLegendary = false;
            ChosenChest = RareChest;
        }

        if(chanceDigit >= 91 && chanceDigit <= 101)
        {
            IsRare = false;
            IsUncommon = false;
            IsLegendary = true;
            ChosenChest = LegendaryChest;
        }

        
    }
}
