using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSceneManager : MonoBehaviour
{
    public static GlobalSceneManager Instance;
    public string CurrentSceneName;
    public Scene CurrentScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneName = CurrentScene.name;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Pixel Shader Test");
    }
}
