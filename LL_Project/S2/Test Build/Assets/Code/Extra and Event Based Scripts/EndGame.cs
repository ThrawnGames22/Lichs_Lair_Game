using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    
    public ArenaGroup ArenaGroup;
    public float TimetillChange;
    public MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ArenaGroup.EnemyGroupEliminated == true)
        {
          StartCoroutine(TimetillChangeScene());
        }
    }

    public IEnumerator TimetillChangeScene()
    {
        yield return new WaitForSeconds(TimetillChange);
        menuManager.LoadNextLevel();
        
            
        
    }


}
