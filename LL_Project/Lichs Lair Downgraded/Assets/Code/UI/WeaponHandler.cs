using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Weapon weapon;
    public WeaponHolder weaponHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();
       weaponHolder.weapon = weapon; 
    }
}
