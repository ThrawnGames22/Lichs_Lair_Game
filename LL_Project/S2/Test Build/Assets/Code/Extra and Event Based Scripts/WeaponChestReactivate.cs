using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChestReactivate : MonoBehaviour
{
    public static WeaponChestReactivate Instance;

    public bool IsInMenu;

    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       IsInMenu = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
