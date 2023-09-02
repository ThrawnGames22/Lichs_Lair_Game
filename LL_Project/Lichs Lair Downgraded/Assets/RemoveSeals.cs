using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSeals : MonoBehaviour
{
    public GameObject[] RoomDoors;

    public GameObject[] Seals;
    // Start is called before the first frame update
    void Start()
    {
        RoomDoors = GameObject.FindGameObjectsWithTag("RoomDoor");
        Seals = GameObject.FindGameObjectsWithTag("SealStone");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
