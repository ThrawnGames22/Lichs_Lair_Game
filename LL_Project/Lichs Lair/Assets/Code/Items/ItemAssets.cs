using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public List<ItemAsset> itemAssets = new List<ItemAsset>();
    //WeaponTypes
    public GameObject[] SpawnableWeaponObject;





    public Sprite weaponSprite;
    public Sprite healthPotionSprite;
    public Sprite manaPotionSprite;
    public Sprite coinSprite;
    

}
