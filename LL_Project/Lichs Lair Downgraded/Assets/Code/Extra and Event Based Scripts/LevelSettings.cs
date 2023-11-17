using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpawnPoint;

    public bool HasSpawned = false;

    public bool IsTutorialScene;
    
    // Start is called before the first frame update

    void Awake()
    {
      
      //Player.transform.position = PlayerSpawnPoint; 
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerController>().speed = 5;
        //Player.GetComponent<CharacterController>().enabled = true;
        
        Player.transform.position = SpawnPoint.transform.position;

        
        StartCoroutine(UnlockPlayer());
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log("LevelWorking");
       
    }

    public IEnumerator UnlockPlayer()
    {
      //HasSpawned = true;
      Player.GetComponent<PlayerController>().characterController.enabled = false;
      yield return new WaitForSeconds(0.01f);
      HasSpawned = true;
      
      Player.GetComponent<PlayerController>().characterController.enabled = true;
      StopUnlock();
      
    }

    public void StopUnlock()
    {
      StopCoroutine(UnlockPlayer());
    }
}
