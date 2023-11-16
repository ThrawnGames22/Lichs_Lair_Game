using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpikeBox : MonoBehaviour
{
    
    public GameObject Spikes;

    public GameObject SpikePrompt;

    public GameObject HealthPotion;
    public GameObject ManaPotion;

    // Start is called before the first frame update
    void Start()
    {
        Spikes.SetActive(false);
        HealthPotion.SetActive(false);
        ManaPotion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            Spikes.SetActive(true);
            SpikePrompt.SetActive(true);
            other.GetComponent<PlayerController>().speed = 0;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void DisableSpikes()
    {
        Spikes.SetActive(false);
        HealthPotion.SetActive(true);
        ManaPotion.SetActive(true);

        
    }
}
