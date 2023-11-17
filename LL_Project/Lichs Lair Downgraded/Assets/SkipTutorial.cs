using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTutorial : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Skip()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HasActivatedGameplay = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HasActivatedMagic = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HasActivatedWeapons = true;
        GameObject.Find("SkipTutorial").GetComponent<EnemyGroup>().HasSkippedTutorial = true;
        GameObject.Find("Level CrossFader").GetComponent<MenuManager>().LoadNextLevel();
        //GameObject.Find("Level Settings").GetComponent<MovePlayer>().StartMove();
        

        
    }

    
}
