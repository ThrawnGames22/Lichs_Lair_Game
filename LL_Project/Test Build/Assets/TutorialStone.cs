using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialStone : MonoBehaviour
{
    public GameObject StoneModel;
    public GameObject StoneUI;
    public GameObject Camera;
    public bool IsInRange;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
      if(IsInRange)
      {
        if(Input.GetKeyDown(KeyCode.F))
        {
         Camera.GetComponent<CameraSmoothFollow>().target = this.transform;
         PlayerController.Instance.speed = 0;
        }
      }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            IsInRange = true;
        
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            IsInRange = false;
       
        }
        
    }

    public void UnlockAndCloseStoneTutorial()
    {
        Camera.GetComponent<CameraSmoothFollow>().target = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerController.Instance.speed = 5;
    }
}

