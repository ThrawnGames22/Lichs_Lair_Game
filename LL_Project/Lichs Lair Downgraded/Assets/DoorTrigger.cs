using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool PlayerIsInTrigger;

    public RoomDoor roomDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerIsInTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
              roomDoor.UnlockDoor = true;  
            }
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
      if(other.gameObject.tag == "Player")
      {
        PlayerIsInTrigger = true;
      }
    }

    private void OnTriggerExit(Collider other) 
    {
      if(other.gameObject.tag == "Player")
      {
        PlayerIsInTrigger = false;
      }
    }
}
