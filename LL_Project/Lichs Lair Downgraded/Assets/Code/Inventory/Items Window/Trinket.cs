using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trinket", menuName = "Item/Create New Trinket")]
public class Trinket : ScriptableObject
{

    // This script is a scriptable object script that contains information about the 'Item" Class
    
    public enum TrinketType
    {

       //UNCOMMON//
       SmallBlueGem,

       IronBeetle,
       ChargedCoin,

       CalmStone,

       EnchantedHartshorn,

       BookOfHeroicTales,

       //RARE//
       
       ManaCrystal,

       DwarvenSteelCharm,

       BottledLightning,

       HeartRing,

       GiantKinGuantlets,

       LionHeartCharm,

       //LEGENDARY//

       DarkCrystal,

       VyngridsWardmail,

       BookOfForbiddenMagic,

       DevilsMark,

       LycansRing,

       CultistConcoction

        
    }

    public TrinketType trinketType;
    public int id;
    public string TrinketName;
    public int value;
    public Sprite TrinketIcon;
    
    public GameObject TrinketGameObject;
    
    public GameObject TriketEffects;

    
}


