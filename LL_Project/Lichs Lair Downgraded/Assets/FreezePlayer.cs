using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnfreezePlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed = 5;
        
    }
}
