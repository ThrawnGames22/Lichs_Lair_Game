using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    

    public bool UnlockDoor;

    public Animator DoorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    DoorAnimator.SetBool("IsUnlocked", UnlockDoor);
       


       
    }
}
