using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagePickerUI : MonoBehaviour
{
    public GameObject ClassButtons;
    public GameObject InformationButton;
    public GameObject InformationPanel;

    public bool HasClicked;
    // Start is called before the first frame update
    void Start()
    {
        HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GameManager(Clone)").GetComponent<UIHandler>().IsPaused == true)
        {
          ClassButtons.SetActive(false);
          InformationButton.SetActive(false);
        }
        if(GameObject.Find("GameManager(Clone)").GetComponent<UIHandler>().IsPaused == false)
        {
          if(HasClicked == false)
          {
            ClassButtons.SetActive(true);
          InformationButton.SetActive(true);
          }
          
        }
    }

    public void EnablePanel()
    {
      InformationButton.SetActive(false);
      InformationPanel.SetActive(true);
      ClassButtons.SetActive(false);
    }

    public void HidePanel()
    {
      InformationButton.SetActive(true);
      InformationPanel.SetActive(false);
      ClassButtons.SetActive(true);
    }

    public void HideEverything()
    {
      HasClicked = true;
      InformationButton.SetActive(false);
      InformationPanel.SetActive(false);
      ClassButtons.SetActive(false);
    }
}
