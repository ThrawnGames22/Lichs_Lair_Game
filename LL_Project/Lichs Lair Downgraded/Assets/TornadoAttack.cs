using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoAttack : MonoBehaviour
{
    public GameObject TornadoPrefab;

    public Transform SpawnPos1;
    public Transform SpawnPos2;
    public Transform SpawnPos3;

    public Transform BossSitPos;

    public bool HasSpawnedTornados;

    public Transform Player;

    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        BossSitPos = GameObject.Find("BossSitPos").transform;
        SpawnPos1 = GameObject.Find("SpawnPos1").transform;
        SpawnPos2 = GameObject.Find("SpawnPos2").transform;
        SpawnPos3 = GameObject.Find("SpawnPos3").transform;

        transform.position = Vector3.Lerp(transform.position, BossSitPos.transform.position, Time.deltaTime * MoveSpeed);
        transform.LookAt(Player);

        if(HasSpawnedTornados == false)
        {
            GameObject TornadoClone1 = Instantiate(TornadoPrefab, SpawnPos1.transform.position, SpawnPos1.transform.rotation);
            GameObject TornadoClone2 = Instantiate(TornadoPrefab, SpawnPos2.transform.position, SpawnPos2.transform.rotation);
            GameObject TornadoClone3 = Instantiate(TornadoPrefab, SpawnPos3.transform.position, SpawnPos3.transform.rotation);
            HasSpawnedTornados = true;

        }

    }

    
}
