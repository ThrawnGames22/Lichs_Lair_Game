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
    public GameObject WallToDisable;

    //bools

    public bool IsFront;
    public bool IsBack;
    public bool IsLeft;
    public bool IsRight;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      CSF = GameObject.Find("Main Camera").GetComponent<CameraSmoothFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player")
      {


        if(WallToDisable != null)
        {
            WallToDisable.SetActive(false);
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
        CSF.offset = OffsetNormal;
        
        PC.IsInFrontCameraView = true;
        PC.IsInRightCameraView = false;
          PC.IsInLeftCameraView = false;
          PC.IsInBackCameraView = false;

        if(WallToDisable != null)
        {
            WallToDisable.SetActive(true);
        }
        
      }
    }
}