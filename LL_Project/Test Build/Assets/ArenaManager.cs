using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public GameObject[] Braziers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(GameObject brazier in Braziers)
            {
             brazier.GetComponent<TurnOnEffects>().TurnOn();
            }
            
        }
    }
}
