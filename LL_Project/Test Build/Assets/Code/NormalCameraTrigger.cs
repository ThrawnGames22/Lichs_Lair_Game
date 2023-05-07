using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCameraTrigger : MonoBehaviour
{
    public CameraChange[] cameraChange;
    public GameObject WallGroupToDisable;
    public GameObject WallGroupToEnable;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach(CameraChange Camera in cameraChange)
        {
      if(Camera.IsInCameraChange)
      {
        WallGroupToDisable.SetActive(true);
      }
      else
      {
        WallGroupToDisable.SetActive(false); 
      }
        }
    }
}
