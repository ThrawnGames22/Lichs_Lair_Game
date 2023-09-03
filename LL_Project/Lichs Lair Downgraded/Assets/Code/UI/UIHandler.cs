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
    public PlayerInventoryController inventoryController;
    public PlayerMagic PM;

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
        
        //inventoryController = GameObject.Find("Item Inventory Manager").GetComponent<PlayerInventoryController>();
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMagic>();
        
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
        IsPaused = true;
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        PM.enabled = false;
        
    }

    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        PM.enabled = true;
        //inventoryController.InventoryIsOpen = false;
        //GameObject.Find("ItemInventory").GetComponent<Canvas>().enabled = true;

        
    }
}
