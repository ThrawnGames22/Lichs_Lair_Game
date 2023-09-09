using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTeleport : MonoBehaviour
{
     public LayerMask Obstacle;

    public Transform RayCastPoint;

    public TeleportManager teleportManager;

    public bool CanUseTeleport;

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
        if(other.gameObject.tag == "Room")
        {
            teleportManager.CanTeleport = false;
            CanUseTeleport = false;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.tag == "Room")
        {
            teleportManager.CanTeleport = true;
            CanUseTeleport = true;
        }
    }
            
            
        
        
}
