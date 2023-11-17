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
    public GameObject OptionsSection;

    public bool isInMainMenu;
    public bool IsPaused;

    public string CurrentSceneName;
    public Scene CurrentScene;

    public GameObject MagePickerUI;
    public PlayerInventoryController inventoryController;
    public PlayerMagic PM;

    public bool InventoryIsOpen;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        
        PauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        PauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
        
        
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

        if(Input.GetKeyDown(KeyCode.Tab))
        {
        InventoryIsOpen = !InventoryIsOpen;
        }

        if(InventoryIsOpen == true)
        {
            GameObject.Find("DeathCanvas").GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        if(InventoryIsOpen == false)
        {
            GameObject.Find("DeathCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
        PauseMenu.GetComponent<CanvasGroup>().alpha = 1;
        PauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        PauseMenu.GetComponent<CanvasGroup>().interactable = true;
        //OptionsSection.GetComponent<CanvasGroup>().alpha = 0;
        //OptionsSection.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //OptionsSection.GetComponent<CanvasGroup>().interactable = false;
        PM.enabled = false;
        
    }

    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1;
        PauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        PauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
        //OptionsSection.GetComponent<CanvasGroup>().alpha = 0;
        //OptionsSection.GetComponent<CanvasGroup>().blocksRaycasts = false;
        //OptionsSection.GetComponent<CanvasGroup>().interactable = false;



        
        PM.enabled = true;
        //inventoryController.InventoryIsOpen = false;
        //GameObject.Find("ItemInventory").GetComponent<Canvas>().enabled = true;

        
    }
}
