using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpawnPoint;

    public bool HasSpawned = false;
    
    // Start is called before the first frame update

    void Awake()
    {
      
      //Player.transform.position = PlayerSpawnPoint; 
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
      
      Player.GetComponent<PlayerController>().characterController.enabled = true;
      StopUnlock();
      
    }

    public void StopUnlock()
    {
      StopCoroutine(UnlockPlayer());
    }
}
