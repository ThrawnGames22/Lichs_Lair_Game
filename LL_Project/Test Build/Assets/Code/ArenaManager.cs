using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public GameObject[] Braziers;
    public GameObject DoorToClose;
    public GameObject[] ArenaEnemies;
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
            DoorToClose.GetComponent<RoomDoor>().HasPassedThrough = true;
            DoorToClose.GetComponent<RoomDoor>().UnlockDoor = false;

            foreach(GameObject Enemy in ArenaEnemies)
            {
                Enemy.GetComponent<EnemyController>().minDistance = 100f;
            }

            this.GetComponent<BoxCollider>().enabled = false;
            
        }
    }
}
