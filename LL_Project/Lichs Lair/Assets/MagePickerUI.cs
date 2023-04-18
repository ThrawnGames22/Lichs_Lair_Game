using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagePickerUI : MonoBehaviour
{
    public GameObject ClassButtons;
    public GameObject InformationButton;
    public GameObject InformationPanel;
    // Start is called before the first frame update
    void Start()
    {
        HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
