using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChance : MonoBehaviour
{
    public int DespawnObjectChance;
    public int SpawnObjectChance;

    public int ChanceRange = 2;

    public bool DespawnObject;

    public GameObject[] roomDoors;

    // Start is called before the first frame update
    void Start()
    {
        ChanceRange = UnityEngine.Random.Range(1,3);
        roomDoors = GameObject.FindGameObjectsWithTag("RoomDoor");
    }

    // Update is called once per frame
    void Update()
    {
        if(ChanceRange == 1)
        {
          foreach(GameObject Door in roomDoors)
          {
            Door.GetComponent<RoomDoor>().isMagicDoor = false;
          }
          Destroy(this.gameObject);
        }
        if(ChanceRange == 2)
        {
          return;
        }
    }
}
