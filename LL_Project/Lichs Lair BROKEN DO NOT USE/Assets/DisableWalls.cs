using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWalls : MonoBehaviour
{
    public GameObject[] WallsToDisable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(GameObject Wall in WallsToDisable)
            {
                Wall.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(GameObject Wall in WallsToDisable)
            {
                Wall.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
