using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public MenuManager menuManager;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.FindGameObjectWithTag("GameManager"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
      Application.Quit();
    }

    public void ResetGame()
    {
        menuManager.QuitToMenu();
    }
}
