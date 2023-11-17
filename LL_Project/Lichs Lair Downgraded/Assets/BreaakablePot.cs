using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreaakablePot : MonoBehaviour
{
    public MeshRenderer StaticMesh;

    public GameObject PotMesh;

    public BoxCollider boxCollider;

    public GameObject[] CoinsToSpawn;

    public bool CanSpawnCoins;

    public Transform CoinsSpawnpoint;

    public bool HasSpawned;
    // Start is called before the first frame update
    void Start()
    {
        StaticMesh.enabled = true;
        PotMesh.SetActive(false);
        boxCollider.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "FireSpell")
        {
            Break();
        }

        if(other.gameObject.tag == "DarkSpell")
        {
            Break();
        }

        if(other.gameObject.tag == "LightningSpell")
        {
            Break();
        }

        if(other.gameObject.tag == "Sword")
        {
            Break();
        }

        if(other.gameObject.tag == "Arrow")
        {
            Break();
        }
    }

    public void Break()
    {
        StaticMesh.enabled = false;
        PotMesh.SetActive(true);
        boxCollider.enabled = false;

        if(CanSpawnCoins == true && HasSpawned == false)
        {
          GameObject CoinsClone = Instantiate(CoinsToSpawn[Random.Range(0, CoinsToSpawn.Length)], CoinsSpawnpoint.position, CoinsSpawnpoint.rotation);
          HasSpawned = true;
        }
    }
}
