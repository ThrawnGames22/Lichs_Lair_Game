using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject MainPanel;
    public GameObject SettingsPanel;
    public GameObject QuitPanel;

    public string CurrentSceneName;
    public Scene CurrentScene;
    public UIHandler UIHandler;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneName = CurrentScene.name;

        
    }

    public void QuitToMenu()
    {
        UIHandler.ResumeGame();
        if(CurrentScene.name == "MagePicker")
        {
            GameObject.Find("MagePicker UI").SetActive(false);
        }
        GameObject.Find("Level CrossFader").GetComponent<MenuManager>().QuitToMenu();
        UIHandler.IsPaused = false;
        UIHandler.PauseMenu.SetActive(false);
    }
}
