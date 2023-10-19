using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrinketInformationPanel : MonoBehaviour
{
    public TrinketManager TM;

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
      trinketText.text = TM.CurrentTrinket.TrinketName;
      trinketDescription.text = TM.CurrentTrinket.Description;
      trinketRarity.text = TM.CurrentTrinket.trinketRarity.ToString();
      trinketEffect.text = TM.CurrentTrinket.TrinketEffect;

       ItemImage.sprite = TM.CurrentTrinket.TrinketIcon; 

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

       if(TM.CurrentTrinket.trinketRarity == Trinket.TrinketRarity.Uncommon)
       {
        trinketRarity.color = Color.green;
       }

       if(TM.CurrentTrinket.trinketRarity == Trinket.TrinketRarity.Rare)
       {
        trinketRarity.color = Color.magenta;
       }

       if(TM.CurrentTrinket.trinketRarity == Trinket.TrinketRarity.Legendary)
       {
        trinketRarity.color = Color.yellow;
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
