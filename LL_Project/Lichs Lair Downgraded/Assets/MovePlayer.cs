using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform SkipPos;

    public GameObject Player;

    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MoveThePlayer()
    {
        GameObject.Find("Level Settings").GetComponent<LevelSettings>().StopUnlock();
        Player.GetComponent<PlayerController>().characterController.enabled = false;
        yield return new WaitForSeconds(1f);
        Player.GetComponent<PlayerController>().characterController.enabled = true;
        
        GameObject.FindGameObjectWithTag("Player").transform.position = SkipPos.transform.position;
        //Destroy(GameObject.Find("SpawnPoint"));
    }

    public void StopMove()
    {
        StopCoroutine(MoveThePlayer());
    }

    public void StartMove()
    {
        StartCoroutine(MoveThePlayer());
    }
}
