using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject ControlsPanel;

    public float FadeTime;
    public bool IsOpen;
    public Animator PanelAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        //ControlsPanel.GetComponent<CanvasGroup>().alpha = 0;
        ControlsPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        PanelAnimator.SetBool("IsOpen", IsOpen);

        if(IsOpen)
        {
          MainPanel.SetActive(false);
          ControlsPanel.SetActive(true);
        }

        if(!IsOpen)
        {
          MainPanel.SetActive(true);
           ControlsPanel.SetActive(false);
        }
    }

    public void ShowControls()
    {
      
      IsOpen = true;
      
    }

    public void HideControls()
    {
      
      IsOpen = false;
    }

    

    
}
