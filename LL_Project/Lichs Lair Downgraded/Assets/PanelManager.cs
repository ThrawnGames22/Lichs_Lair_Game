using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject SoundPanel;
    public GameObject VisualPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSoundPanel()
    {
      SoundPanel.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void HideSoundPanel()
    {
      SoundPanel.GetComponent<CanvasGroup>().alpha = 0;
        
    }
    public void ShowVisualPanel()
    {
      VisualPanel.GetComponent<CanvasGroup>().alpha = 1;
        
    }
    public void HideVisualPanel()
    {
      VisualPanel.GetComponent<CanvasGroup>().alpha = 0;
        
    }
}
