using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameData : MonoBehaviour
{
    public GameObject GameData;
    // Start is called before the first frame update
    void Start()
    {
       if(GameObject.Find("GamePerformanceSettings(Clone)") == null)
       {
        Instantiate(GameData);
       } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
