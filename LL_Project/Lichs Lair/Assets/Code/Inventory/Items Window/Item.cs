using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        HealthPotion,
        ManaPotion,
        EXPBook,
        Weapon
    }
    public int id;
    public string ItemName;
    public int value;
    public Sprite ItemIcon;
    public ItemType itemType;
}
