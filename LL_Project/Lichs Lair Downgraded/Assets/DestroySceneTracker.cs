using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySceneTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("SceneTracker"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}