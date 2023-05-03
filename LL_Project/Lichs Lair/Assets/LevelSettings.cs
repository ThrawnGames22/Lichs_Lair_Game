using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public GameObject Player;
    public Vector3 PlayerSpawnPoint;
    // Start is called before the first frame update

    void Awake()
    {
      
      //Player.transform.position = PlayerSpawnPoint; 
    }
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
