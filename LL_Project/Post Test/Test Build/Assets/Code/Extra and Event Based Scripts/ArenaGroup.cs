using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaGroup : MonoBehaviour
{
    public List<GameObject> Enemies;

    public bool EnemyGroupEliminated;

    public GameObject GameCompleteCanvas;
    // Start is called before the first frame update
    void Start()
    {
      EnemyGroupEliminated = false;
      GameCompleteCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
          GameCompleteCanvas.SetActive(true);
        }
    }
}
