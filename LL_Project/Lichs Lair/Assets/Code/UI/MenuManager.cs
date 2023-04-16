using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public string CurrentSceneName;
    public Scene CurrentScene;
    public Scene NextScene;
    public string NextSceneName;
    public Animator transition;
    public float TransitionTime;
    public Scene LastScene;


    // Start is called before the first frame update
    void Start()
    {
        CurrentSceneName = CurrentScene.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneName = CurrentScene.name;

    }

    public void StartNewGameScene()
    {
        StartCoroutine(LoadMagePickerLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void StartGame()
    {
       StartCoroutine(LoadFirstLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadMagePickerLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(LevelIndex);
    }

    IEnumerator LoadFirstLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(LevelIndex);
    }

    
    
}
