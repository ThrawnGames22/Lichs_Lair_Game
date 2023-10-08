using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChecker : MonoBehaviour
{
    public GameObject WeaponInSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WeaponInSlot = this.gameObject.transform.GetChild(0).gameObject;
    }
}
