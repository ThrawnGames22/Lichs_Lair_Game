using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public List<GameObject> Enemies;

    public bool EnemyGroupEliminated;

    public RoomDoor DoorToOpenOnElimination;
    // Start is called before the first frame update
    void Start()
    {
        EnemyGroupEliminated = false;
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
            DoorToOpenOnElimination.UnlockDoor = true;
        }
        
    }
}
