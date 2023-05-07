using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    public GameObject[] CameraChanges;
    public bool HasStarted;
    // Start is called before the first frame update
    void Start()
    {
       HasStarted = false; 
       PlayerHealth.Instance.IsDead = false;
       PlayerHealth.Instance.currentHealth = 100f;
       foreach(GameObject Camera in CameraChanges)
       {
        Camera.GetComponent<CameraChange>().IsInCameraChange = false;
       }
       
       
       

    }

    // Update is called once per frame
    void Update()
    {
       if(HasStarted == false)
       {
         PlayerController.Instance.IsInFrontCameraView = true;
         HasStarted = true;
       }

       if(PlayerHealth.Instance.IsDead == true)
       {
         foreach(GameObject Camera in CameraChanges)
         {
          //Camera.GetComponent<CameraChange>().enabled = false;
          Camera.GetComponent<CameraChange>().GetComponent<BoxCollider>().enabled = false;
         }
       }
    }
}
