using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    public GameObject LevelCrossFader;
    public SceneTracker sceneTracker;
    // Start is called before the first frame update
    void Start()
    {
      LevelCrossFader = GameObject.Find("Level CrossFader");
      sceneTracker = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
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
        

        if(sceneTracker.LevelsTillChange == 0)
        {
          LevelCrossFader.GetComponent<MenuManager>().LoadChestLevel();
          sceneTracker.ResetLevelChange();
        }
        
      }
    }
}
