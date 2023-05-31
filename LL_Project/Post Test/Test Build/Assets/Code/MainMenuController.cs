using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject ControlsPanel;
    public GameObject OptionsPanel;

    public float FadeTime;
    public bool IsOpenControls;
    public bool IsOpenOptions;

    public Animator PanelAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        //ControlsPanel.GetComponent<CanvasGroup>().alpha = 0;
        ControlsPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //PanelAnimator.SetBool("IsOpen", IsOpen);

        if(IsOpenControls)
        {
          MainPanel.SetActive(false);
          ControlsPanel.SetActive(true);
        }

        if(!IsOpenControls)
        {
          MainPanel.SetActive(true);
           ControlsPanel.SetActive(false);
        }

        if(IsOpenOptions)
        {
          MainPanel.SetActive(false);
          OptionsPanel.SetActive(true);
        }

        if(!IsOpenOptions)
        {
          MainPanel.SetActive(true);
           OptionsPanel.SetActive(false);
        }
    }

    public void ShowControls()
    {
      
      IsOpenControls = true;
      
    }

    public void HideControls()
    {
      
      IsOpenControls = false;
    }

     public void ShowOptions()
    {
      
      IsOpenOptions = true;
      
    }

    public void HideOptions()
    {
      
      IsOpenOptions = false;
    }

    

    
}
