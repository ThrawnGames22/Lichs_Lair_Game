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

    [Header("Scene Randomnizer")]

    public int Startinglevel;
    public int EndingLevel;

    public bool UseSceneRandomisation; 

   public SceneTracker sceneTracker;

   public int randomIndex;

   public int NextSceneIndex;

    


    // Start is called before the first frame update
    void Start()
    {
        CurrentSceneName = CurrentScene.name;
        sceneTracker = GameObject.Find("SceneTracker").GetComponent<SceneTracker>();
        randomIndex = Random.Range(6, 13);
        NextSceneIndex = randomIndex;
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneName = CurrentScene.name;
        if(CurrentScene.name == "Level 1")
        {
            
        }
        
        if(sceneTracker.LevelsTillChange == 0)
        {
            NextSceneIndex = SceneManager.GetSceneByName("Chest Room").buildIndex;
        }

        if(sceneTracker.NextLevelIsBossRoom == true)
        {
            StartCoroutine(LoadBossRoom());
        }
    }

    public void StartNewGameScene()
    {
        StartCoroutine(LoadMagePickerLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void StartGame()
    {
       StartCoroutine(LoadFirstLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void QuitToMenu()
    {
        StartCoroutine(LoadMenu());
        
    }
     public void LoadNextLevel()
    {
        StartCoroutine(LoadRandomLevel());
    }

    public void LoadChestLevel()
    {
        StartCoroutine(LoadChestRoom());
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
        LoadMenu("Load Into Game");
    }

    IEnumerator LoadNextLV(int LevelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(LevelIndex);
    }

    IEnumerator LoadRandomLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(NextSceneIndex);
        sceneTracker.DecreaseLevelChange();
    }

    IEnumerator LoadChestRoom()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene("Chest Room");
        
    }

    IEnumerator LoadMenu()
    {
        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        LoadMenu("Load Back To Menu");
    }

    public void LoadMenu(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void LoadEndGameScene()
    {
        SceneManager.LoadScene("EndGame");
    }

    public void LoadBossRoomScene()
    {
        SceneManager.LoadScene("Level 8 Upgraded");
    }


    public IEnumerator LoadEndGame()
    {
        yield return new WaitForSeconds(2.5f);
        LoadEndGameScene();
        StopCoroutine(LoadEndGame());
    }

    public IEnumerator LoadBossRoom()
    {
        yield return new WaitForSeconds(2.5f);
        LoadBossRoomScene();
        StopCoroutine(LoadBossRoom());
    }

  
    
    
}
