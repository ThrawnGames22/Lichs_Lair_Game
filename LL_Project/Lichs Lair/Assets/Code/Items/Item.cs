using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item // : ScriptableObject
{
    public enum ItemType
    {
      Weapon,
      HealthPotion,
      AbilityPotion,
      ManaPotion,
      EXPBook,
      Coins
    }
    public ItemType itemType;
    public int amount; 

    public Sprite GetSprite() 
    {
        switch (itemType) 
        {
        default:
        case ItemType.Weapon:        return ItemAssets.Instance.weaponSprite;
        case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
        case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
        case ItemType.Coins:         return ItemAssets.Instance.coinSprite;
        
        }
    }

    

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
            case ItemType.AbilityPotion:
            case ItemType.Coins:
            case ItemType.EXPBook:
                 return true;
            case ItemType.Weapon:
                 return false;





        }
    }
    
}
