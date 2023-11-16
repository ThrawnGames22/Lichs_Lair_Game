using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketPrompt : MonoBehaviour
{
     public GameObject TrinketPromptText;

     public SkipTutorial skipTutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            TrinketPromptText.SetActive(true);
            other.gameObject.GetComponent<PlayerController>().speed = 0;
        }
    }

    public void Close()
    {
        TrinketPromptText.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed = 5;
        skipTutorial.Skip();
    }
}
