using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDelete : MonoBehaviour
{
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
       if(GameObject.Find("GameManager(Clone)") == null)
       {
        Instantiate(GameManager);
       } 

       if(GameObject.FindGameObjectWithTag("Player") != null)
       {
         Destroy(GameObject.FindGameObjectWithTag("Player"));
       }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
