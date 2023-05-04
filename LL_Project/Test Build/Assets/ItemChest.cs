using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    public Animator ChestAnimator;
    public GameObject[] ItemsDictionary;
    public Transform ItemSpawnPoint;
    public bool HasUnlocked;
    public bool isInRange;

    public bool IsVSliceChest;
    public GiveWeapons GiveWeapons;
    
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    

    //ChestEffects
    public GameObject Effects;

    
    // Start is called before the first frame update
    void Start()
    {
        Item1 = ItemsDictionary[Random.Range(0, ItemsDictionary.Length)];
        Item2 = ItemsDictionary[Random.Range(0, ItemsDictionary.Length)];
        Item3 = ItemsDictionary[Random.Range(0, ItemsDictionary.Length)];
        Effects.SetActive(false);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
        if(HasUnlocked == false)
          {
          if(Input.GetKeyDown(KeyCode.F))
          {
            SpawnItem();

            if(IsVSliceChest)
            {
              PlayerController.Instance.HasAquiredWeapons = true;
            }
          }
          }
        }
    }

    public void SpawnItem()
    {
      Effects.SetActive(true);
      ChestAnimator.SetTrigger("IsUnlocked");
      Instantiate(Item1, ItemSpawnPoint.transform.position, ItemSpawnPoint.rotation);
      Instantiate(Item2, ItemSpawnPoint.transform.position, ItemSpawnPoint.rotation);
      Instantiate(Item3, ItemSpawnPoint.transform.position, ItemSpawnPoint.rotation);
      HasUnlocked = true;


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
          isInRange = true;
          
        }
        else
        {
          isInRange = false;
        }
    }
}
