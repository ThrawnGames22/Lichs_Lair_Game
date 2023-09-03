using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    public Scene CurrentScene;
    public string LevelName;

    public int CurrentLevelIndex;

    public int LevelsTillChange = 2;

    public int maxLevelCount;

    public bool NextLevelIsChestRoom;

    public bool NextLevelIsEndGame;

    public int LevelsPlayerHasCompleted;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        LevelsTillChange = 2;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScene = SceneManager.GetActiveScene();
        LevelName = CurrentScene.name;
        CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        if(LevelsTillChange == 0)
        {
            NextLevelIsChestRoom = true;
            
        }

        if(LevelsPlayerHasCompleted == 10)
        {
            NextLevelIsEndGame = true;
        }
    }

    public void DecreaseLevelChange()
    {
        LevelsTillChange -= 1;
    }

    public void ResetLevelChange()
    {
        LevelsTillChange = 2;
        NextLevelIsChestRoom = false;
    }

    public void AddLevelCount()
    {
      LevelsPlayerHasCompleted += 1;
    }
}
