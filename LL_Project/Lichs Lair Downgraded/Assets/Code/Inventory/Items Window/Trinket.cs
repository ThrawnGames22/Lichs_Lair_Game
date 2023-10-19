using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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

       WizardsJournal,

       //RARE//
       
       ManaCrystal,

       DragonScaleCharm,

       BottledLightning,

       HeartRing,

       GiantKinGuantlets,

       SorceryFocus,

       //LEGENDARY//

       BlackGem,

       VyngridsWardmail,

       TomeOfForbiddenMagic,

       DevilsMark,

       LycansRing,

       CultistConcoction

        
    }

    public enum TrinketRarity
    {
        Uncommon,
        Rare,
        Legendary
    }

    public TrinketType trinketType;

    public TrinketRarity trinketRarity;
    public int id;
    public string TrinketName;
    public int value;
    public Sprite TrinketIcon;
    
    public GameObject TrinketGameObject;
    
    public TrinketEffects trinketEffects;

    //TEXT FOR ITEM INFORMATION//

    public string Description;

    public string Rarity;

    public string TrinketEffect;

    public int ItemStoreCost;


    
}


