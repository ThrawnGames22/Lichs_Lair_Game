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
        ControlsPanel.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        PanelAnimator.SetBool("IsOpen", IsOpen);
    }

    public void ShowControls()
    {
      MainPanel.SetActive(false);
      IsOpen = true;
      
    }

    public void HideControls()
    {
      IsOpen = false;
    }

    

    
}
