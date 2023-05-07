using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Vector3 OffsetToChange;
    public Vector3 OffsetNormal;
    public CameraSmoothFollow CSF;
    public PlayerController PC;

    //If any walls need Disabling
    public GameObject WallGroupToDisable;
    public GameObject WallGroupToEnable;
    public bool IsInCameraChange;


    //bools

    public bool IsFront;
    public bool IsBack;
    public bool IsLeft;
    public bool IsRight;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PC.IsInFrontCameraView = true;
        
    }

    // Update is called once per frame
    void Update()
    {
      CSF = GameObject.Find("Main Camera Main").GetComponent<CameraSmoothFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
        IsInCameraChange = true;
        if(WallGroupToDisable != null)
        {
        WallGroupToDisable.SetActive(false);
        }

        if(WallGroupToEnable != null)
        {
        WallGroupToEnable.SetActive(true);
        }

        
        
        CSF.offset = OffsetToChange;
        




        if(IsLeft)
        {
          PC.IsInLeftCameraView = true;
          PC.IsInRightCameraView = false;
          PC.IsInBackCameraView = false;
          PC.IsInFrontCameraView = false;



        }

        if(IsRight)
        {
          PC.IsInRightCameraView = true;
          PC.IsInLeftCameraView = false;
          PC.IsInBackCameraView = false;
          PC.IsInFrontCameraView = false;
        }

        if(IsBack)
        {
          PC.IsInBackCameraView = true;
          PC.IsInRightCameraView = false;
          PC.IsInLeftCameraView = false;
          PC.IsInFrontCameraView = false;
        }

        if(IsFront)
        {
          PC.IsInFrontCameraView = true;
          PC.IsInRightCameraView = false;
          PC.IsInLeftCameraView = false;
          PC.IsInBackCameraView = false;
        }
      }
    }

    private void OnTriggerExit(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {
         IsInCameraChange = false;
        CSF.offset = OffsetNormal;
        
        PC.IsInFrontCameraView = true;
        PC.IsInRightCameraView = false;
          PC.IsInLeftCameraView = false;
          PC.IsInBackCameraView = false;
       if(WallGroupToDisable != null)
        {
        WallGroupToDisable.SetActive(true);
        }

        if(WallGroupToEnable != null)
        {
        WallGroupToEnable.SetActive(false);
        }
        
      }
        
      
    }
}
