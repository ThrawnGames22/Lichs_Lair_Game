using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public List<GameObject> Enemies;

    public bool EnemyGroupEliminated;

    public bool IsTutorialScene;
    public GameObject TutorialCompleteCanvas;

    public RoomDoor DoorToOpenOnElimination;

    public GameObject SkipPrompt;

    public bool HasSkippedTutorial;
    // Start is called before the first frame update
    void Start()
    {
        EnemyGroupEliminated = false;
        if(IsTutorialScene)
        {
        TutorialCompleteCanvas.SetActive(false);
        
        
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(HasSkippedTutorial == true)
        {
          //foreach(GameObject enemy in Enemies)
          //{
           //     enemy.SetActive(false);
           //     Enemies.Remove(enemy);
                
            
          //}

        if(IsTutorialScene)
        {
          TutorialCompleteCanvas.SetActive(true);
        }
        }
        foreach(GameObject enemy in Enemies)
        {
            if(enemy.GetComponent<EnemyHealth>().IsDead)
            {
                Enemies.Remove(enemy);
            }
        }

        if(Enemies.Count == 0)
        {
           EnemyGroupEliminated = true;
        }

        if(EnemyGroupEliminated)
        {
            DoorToOpenOnElimination.UnlockDoor = true;
        
        }

       
        
    }
}
