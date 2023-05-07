using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;



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

    public GameObject UnlockedCanvas;
    public float UnlockedCanvasTime;

    public GameObject Prompt;

    public Volume volume;
    private Vignette vig;
    public float vigneteIntensity = 0.625f;
    public float normalVigneteIntensity = 0.25f;

    
    // Start is called before the first frame update
    void Start()
    {
      
      if(IsVSliceChest == false)
      {
        Item1 = ItemsDictionary[Random.Range(0, ItemsDictionary.Length)];
        Item2 = ItemsDictionary[Random.Range(0, ItemsDictionary.Length)];
        Item3 = ItemsDictionary[Random.Range(0, ItemsDictionary.Length)];
        
      }

      if(IsVSliceChest == true)
      {
        volume.profile.TryGet(out vig);
        vig.intensity.value = normalVigneteIntensity;
      }
      Effects.SetActive(false);
      UnlockedCanvas.SetActive(false);
      Prompt.SetActive(false);  
        
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
            if(IsVSliceChest == false)
            {
            SpawnItem();
            }

            if(IsVSliceChest == true)
            {
              
            }



            
          }
          }




        }
        
        if(isInRange)
        {
        if(HasUnlocked == false)
          {
          if(IsVSliceChest == true)
          
           {
            if(Input.GetKeyDown(KeyCode.F))
            {
              PlayerController.Instance.speed = 0;
              PlayerController.Instance.HasAquiredWeapons = true;
              PlayerMagic.Instance.HasAquiredMagic = true;
              Prompt.SetActive(true);
              volume.profile.TryGet(out vig);
              vig.intensity.value = vigneteIntensity;
              
              SpawnWeapons();
              StartCoroutine(UIUnlocked());
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

    public void SpawnWeapons()
    {
      Effects.SetActive(true);
      ChestAnimator.SetTrigger("IsUnlocked");
      
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

    public IEnumerator UIUnlocked()
    {
      UnlockedCanvas.SetActive(true);
      yield return new WaitForSeconds(UnlockedCanvasTime);
      UnlockedCanvas.SetActive(false);
      StopUIUnlocked();
      
    }

    public void StopUIUnlocked()
    {
      StopCoroutine(UIUnlocked());
    }

    public void ClosePrompt()
    {
      Prompt.SetActive(false);
      volume.profile.TryGet(out vig);
      vig.intensity.value = normalVigneteIntensity;
      PlayerController.Instance.speed = 5;
    }
}
