using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInformationPanel : MonoBehaviour
{
    public MechantItem merchantItem;

    public Image ItemImage;

    public CanvasGroup canvasGroup;

    public bool IsHovering;

    public Text trinketText;

    public Text trinketDescription;

    public Text trinketRarity;
    public Text trinketEffect;



    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {

      if(merchantItem.IsTrinket)
      {
      trinketText.text = merchantItem.trinket.TrinketName;
      trinketDescription.text = merchantItem.trinket.Description;
      trinketRarity.text = merchantItem.trinket.trinketRarity.ToString();
      trinketEffect.text = merchantItem.trinket.TrinketEffect;

       ItemImage.sprite = merchantItem.trinket.TrinketIcon; 

       

       if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Uncommon)
       {
        trinketRarity.color = Color.green;
       }

       if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Rare)
       {
        trinketRarity.color = Color.magenta;
       }

       if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Legendary)
       {
        trinketRarity.color = Color.yellow;
       }
      }
      //Potion//
      if(merchantItem.IsPotion)
      {
      trinketText.text = merchantItem.potion.ItemName;
      trinketDescription.text = merchantItem.potion.ItemName;
      trinketRarity.text = "Potion";
      trinketEffect.text = "";

       ItemImage.sprite = merchantItem.potion.ItemIcon; 

       

       //if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Uncommon)
       //{
       // trinketRarity.color = Color.green;
       //}

       //if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Rare)
       //{
       // trinketRarity.color = Color.magenta;
       //}

       //if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Legendary)
       //{
       // trinketRarity.color = Color.yellow;
       //}
      }
      //Combat Spell
      if(merchantItem.IsCBS2)
      {
      trinketText.text = merchantItem.CombatSpell2.SpellName;
      trinketDescription.text = merchantItem.CombatSpell2.Description;
      trinketRarity.text = "";
      trinketEffect.text = "";

       ItemImage.sprite = merchantItem.CombatSpell2.SpellIcon; 

       

       //if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Uncommon)
       //{
       // trinketRarity.color = Color.green;
       //}

       //if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Rare)
       //{
       // trinketRarity.color = Color.magenta;
       //}

       //if(merchantItem.trinket.trinketRarity == Trinket.TrinketRarity.Legendary)
       //{
       // trinketRarity.color = Color.yellow;
       //}
      }

      if(IsHovering == false)
       {
        canvasGroup.alpha = 0;
        
       }

       if(IsHovering == true)
       {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
          canvasGroup.alpha = 1;
        }
        if(Input.GetKeyUp(KeyCode.Mouse1))
        {
          canvasGroup.alpha = 0;
        }
        
       }
      
      
    }

    public void HoveringOn()
    {
        IsHovering = true;
    }

    public void HoveringOff()
    {
        IsHovering = false;
    }
}
