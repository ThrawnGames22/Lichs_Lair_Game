using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/Create New Weapon")]
public class Weapon : ScriptableObject
{
    public enum WeaponType
    {
        Sword,
        Axe,
        Bow,
        Dagger,
        Staff
    }


    public int id;
    public string WeaponName;
    public int Damage;
    public Sprite WeaponIcon;
    public GameObject WeaponGameObject;
    public Sprite WeaponCoolDownIcon;
    public WeaponType weaponType;
    public GameObject WeaponFX;
}
