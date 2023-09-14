using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSceneTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     GameObject.Find("SceneTracker").GetComponent<SceneTracker>().NextLevelIsBossRoom = false;
     GameObject.Find("SceneTracker").GetComponent<SceneTracker>().LevelsPlayerHasCompleted = 0;
     //GameObject.Find("SceneTracker").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
