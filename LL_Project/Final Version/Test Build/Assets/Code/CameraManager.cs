using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject CameraToStartWith;
    public GameObject FrontCamera;
    public GameObject BackCamera;
    public GameObject LeftCamera;
    public GameObject RightCamera;

    // Start is called before the first frame update
    void Start()
    {
        CameraToStartWith.SetActive(true);
        BackCamera.SetActive(false);
        LeftCamera.SetActive(false);
        RightCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFrontCamera()
    {
        FrontCamera.SetActive(true);
        BackCamera.SetActive(false);
        LeftCamera.SetActive(false);
        RightCamera.SetActive(false);

    }

    public void SetBackCamera()
    {
        FrontCamera.SetActive(false);
        BackCamera.SetActive(true);
        LeftCamera.SetActive(false);
        RightCamera.SetActive(false);

    }

    public void SetLeftCamera()
    {
        FrontCamera.SetActive(false);
        BackCamera.SetActive(false);
        LeftCamera.SetActive(true);
        RightCamera.SetActive(false);

    }
    public void SetRightCamera()
    {
        FrontCamera.SetActive(false);
        BackCamera.SetActive(false);
        LeftCamera.SetActive(false);
        RightCamera.SetActive(true);

    }
}
