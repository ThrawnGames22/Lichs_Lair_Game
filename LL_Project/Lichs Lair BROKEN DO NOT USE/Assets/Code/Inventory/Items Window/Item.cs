using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        //Potions
        PotionOfNegation,

        //Food
        CarrotCake,
        SuspiciousMushroom,

        EXPBook,
        Weapon
    }
    public int id;
    public string ItemName;
    public int value;
    public Sprite ItemIcon;
    public Sprite ItemCoolDownIcon;
    public ItemType itemType;
    public GameObject ItemEffects;
}


