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
    public bool TutorialStoneIsDone;
    public float UiTime;
    public GameObject Barrier;

    //Prompts

    public GameObject StartPrompt;
    
    public 
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        StoneUI.SetActive(false);
        StartPrompt.SetActive(false);
        
        //Barrier.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
      if(IsInRange)
      {
        if(TutorialStoneIsDone == false)
        {

        if(Input.GetKeyDown(KeyCode.F))
        {
         //Camera.GetComponent<CameraSmoothFollow>().target = this.transform;
         PlayerController.Instance.speed = 0;
         StartPrompt.SetActive(true);
         
         TutorialStoneIsDone = true;
         
         //StartCoroutine(UI());
        }
        }
      }
      else
      {
        return;
      }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
          if(TutorialStoneIsDone == false)
          {
            IsInRange = true;
           
          }
        
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
          if(TutorialStoneIsDone == false)
          {
            IsInRange = false;
           
          }
       
        }
        
    }

    public void UnlockAndCloseStoneTutorial()
    {
        Camera.GetComponent<CameraSmoothFollow>().target = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerController.Instance.speed = 5;
        //PlayerController.Instance.HasActivatedGameplay = true;
       

        StartPrompt.SetActive(false);
        //Barrier.SetActive(false);
    }

/*
    public IEnumerator UI()
    {
      StoneUI.SetActive(true);
      yield return new WaitForSeconds(UiTime);
      UnlockAndCloseStoneTutorial();
      StopUI();
      
      
    }
    

    public void StopUI()
    {
      StopCoroutine(UI());
    }
    */

}

