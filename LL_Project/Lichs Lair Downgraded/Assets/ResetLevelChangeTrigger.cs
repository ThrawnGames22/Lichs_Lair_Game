using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevelChangeTrigger : MonoBehaviour
{
    public SceneTracker sceneTracker;
    // Start is called before the first frame update
    void Start()
    {
        sceneTracker = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
     if(other.gameObject.tag == "Player")
     {
        sceneTracker.ResetLevelChange();
        sceneTracker.LevelsTillChange = 3;
     }   
    }
}
