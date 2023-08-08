using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    public MenuManager MenuManager;
    public float CutsceneTime = 6f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadIntoNewGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadIntoNewGame()
    {
        yield return new WaitForSeconds(CutsceneTime);
        MenuManager.StartGame();
    }
}
