using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    public GameObject LevelCrossFader;
    // Start is called before the first frame update
    void Start()
    {
      LevelCrossFader = GameObject.Find("Level CrossFader");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
        LevelCrossFader.GetComponent<MenuManager>().LoadNextLevel();
      }
    }
}
