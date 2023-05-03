using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrippingOnAcid : MonoBehaviour
{
    
    public GameObject GlobalVolume;

    public bool PlayerIsInRange;
    
    // Start is called before the first frame update
    void Start()
    {
      //SceneVolume = GameObject.Find("Global Volume").GetComponent<Volume>();
      //SceneVolume.profile = NormalProfile;
      GlobalVolume = GameObject.Find("Global Volume");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerIsInRange == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
              GlobalVolume.GetComponent<AcidTripController>().AcidTrip();
              Destroy(this.gameObject);
              print("Oh Shit, What the FUCK IS HAPPENING!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
          PlayerIsInRange = true;
        }
    }
     private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
          PlayerIsInRange = false;
        }
    }
}
