using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemAsset
{
    public ItemWorld itemWorld;
    public string Name;
    public GameObject SpawnableObject;

    void Start()
    {
        itemWorld.Name = Name;
    }
}
