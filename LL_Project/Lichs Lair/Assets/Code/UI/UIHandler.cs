using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;

    public GameObject ItemInventory;
    public GameObject WeaponInventory;
    public GameObject SpellInventory;
    public GameObject PauseMenu;
    public bool isInMainMenu;
    public bool IsPaused;

    public string CurrentSceneName;
    public Scene CurrentScene;

    public GameObject MagePickerUI;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        PauseMenu.SetActive(false);
        
    }

    void Update()
    {
        
        
        CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneName = CurrentScene.name;

        if(CurrentScene.name != "Menu")
        {

        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }

        if(IsPaused)
        {
            PauseGame();
        }

        if(!IsPaused)
        {
            ResumeGame();
        }
        }

        

        
    }

    public void PauseGame()
    {
        
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);

        
    }
}
