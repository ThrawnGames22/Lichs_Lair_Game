using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScreenManager : MonoBehaviour
{
    public bool IsLoadGame;
    public bool IsLoadMenu;

    public bool isWarningScene;

    public float loadTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        if(IsLoadMenu)
        {
        StartCoroutine(LoadTime());
        }

        if(IsLoadGame)
        {
        StartCoroutine(LoadGameTime());
        }

        if(isWarningScene)
        {
        StartCoroutine(LoadWarningTime());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsLoadMenu)
        {
        Destroy(GameObject.FindGameObjectWithTag("GameManager"));
        }

        if(IsLoadGame)
        {
        Destroy(GameObject.Find("Red Mage"));
        }
    }

    public void LoadMenu(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

     public void LoadGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

      public void LoadGameIntoScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public IEnumerator LoadTime()
    {
        yield return new WaitForSeconds(loadTime);
        LoadMenu("Menu");
    }

    public IEnumerator LoadGameTime()
    {
        yield return new WaitForSeconds(loadTime);
        LoadGame("Levl 1 Recovery");
    }

    public IEnumerator LoadWarningTime()
    {
        yield return new WaitForSeconds(loadTime);
        LoadGameIntoScene("Load Into Game");
    }
}
