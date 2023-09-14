using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPrompt : MonoBehaviour
{
    public GameObject PromptOject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePrompt()
    {
        PromptOject.SetActive(false);
    }
}
