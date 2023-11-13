using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public TheLich lichController;
    public CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            lichController.FightHasStarted = true;
            cameraShake.start = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
