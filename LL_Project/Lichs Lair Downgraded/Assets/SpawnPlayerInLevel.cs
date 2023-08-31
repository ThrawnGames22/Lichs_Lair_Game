using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerInLevel : MonoBehaviour
{
    public GameObject Player;

    public Transform PlayerSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(UnlockPlayer());

        Player.GetComponent<PlayerController>().speed = 0;
        Player.transform.position = PlayerSpawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UnlockPlayer()
    {
      Player.GetComponent<PlayerController>().characterController.enabled = false;
      yield return new WaitForSeconds(0.1f);
      
        Player.GetComponent<PlayerController>().characterController.enabled = true;
        StopUnlock();
      
    }

    public void StopUnlock()
    {
      StopCoroutine(UnlockPlayer());
      Player.GetComponent<PlayerController>().speed = 5;
    }
}
