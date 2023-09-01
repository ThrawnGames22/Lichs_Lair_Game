using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActivateSound : MonoBehaviour
{
    

   
    public GameObject Ambinece2;

    public bool FadeOut;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P Pressed");
            

            
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            FadeOut = true;

            

        }

        if(FadeOut == true)
        {
           Fade(); 
        }
    }

    public void Fade()
    {
      
    }
}
