using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public GameObject Player;
    public GameObject SpawnPoint;

    public bool HasSpawned = false;
    public static LevelSettings Instance;
    // Start is called before the first frame update

    void Awake()
    {
      Instance = this;
      //Player.transform.position = PlayerSpawnPoint; 
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<CharacterController>().enabled = true;
        StartCoroutine(UnlockPlayer());
        Player.transform.position = SpawnPoint.transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator UnlockPlayer()
    {
      HasSpawned = true;
      Player.GetComponent<PlayerController>().characterController.enabled = false;
      yield return new WaitForSeconds(0.1f);
      
        Player.GetComponent<PlayerController>().characterController.enabled = true;
        StopUnlock();
      
    }

    public void StopUnlock()
    {
      StopCoroutine(UnlockPlayer());
    }
}
