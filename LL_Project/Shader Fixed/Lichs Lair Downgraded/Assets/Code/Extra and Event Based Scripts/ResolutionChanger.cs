using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResolutionChanger : MonoBehaviour
{
    public bool isFS;
    public bool isWD;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        SwitchToFS();
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void SwitchToLowEnd()
    {
       if(isWD)
       {
       Screen.SetResolution(1920, 1080, false);
       }

       if(isFS)
       {
       Screen.SetResolution(1920, 1080, true);
       }

       
       print(Screen.currentResolution);
    }

     public void SwitchToRecommended()
    {
        if(isWD)
        {
       Screen.SetResolution(2560, 1440, false);
        }

        if(isFS)
        {
        Screen.SetResolution(2560, 1440, true);
        }


       
       print(Screen.currentResolution);
    }

     public void SwitchToHighEnd()
    {
        if(isWD)
        {
       Screen.SetResolution(3840, 2160, false);
        }
         if(isFS)
        {
             Screen.SetResolution(3840, 2160, true);
        }
       
       print(Screen.currentResolution);

    }

    public void SwitchToFS()
    {
      Screen.fullScreen = true;
      isFS = true;
      isWD = false;

    }

    public void SwitchToWD()
    {
       Screen.fullScreen = false;
       isFS = false;
      isWD = true;
    }
}
