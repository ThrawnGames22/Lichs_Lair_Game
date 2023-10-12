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
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
