using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Settings : MonoBehaviour
{
    public GameObject Player;
    public MeshRenderer PlayerMeshRenderer;
    public Material[] Materials;
    public float startAlpha;
    public float EmissionIntensity = 0.01f;
    public Transform PlayerSpawnPoint;
    public GameObject DeathCanvas;
 
     
    // Start is called before the first frame update
    void Start()
    {
        //DeathCanvas = GameObject.Find("DeathCanvas");
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerMeshRenderer = GameObject.FindGameObjectWithTag("PlayerRenderer").GetComponent<MeshRenderer>();
        Materials = PlayerMeshRenderer.materials;
        StartCoroutine(UnlockPlayer());
        foreach(Material mat in Materials)
        {
            
            Color EmissionColor = new Color(0, 191, 169);
            mat.SetColor("_EmissionColor", EmissionColor * EmissionIntensity);
            
            
            
            
        }
        Player.GetComponent<PlayerController>().speed = 0;
        Player.transform.position = PlayerSpawnPoint.position;

        
       GameObject.Find("Death Screen").GetComponent<DeathManager>().SetScreen();
       

        
    }

    // Update is called once per frame
    void Update()
    {
      

      if(PlayerHealth.Instance.IsDead)
      {
        //DeathCanvas.SetActive(true);
      }
      else
      {
        //DeathCanvas.SetActive(false);
      }
      StartCoroutine(FadeInPlayer());
      if(EmissionIntensity < 0f)
      {
        EmissionIntensity = 0f;
        foreach(Material mat in Materials)
        {
            
            Color EmissionColor = Color.black;
            mat.SetColor("_EmissionColor", EmissionColor);
             
            
            
            
        }
      }  
    }

    public IEnumerator FadeInPlayer()
    {
        EmissionIntensity -= 0.005f * Time.deltaTime;
        foreach(Material mat in Materials)
        {
            
            Color EmissionColor = new Color(0, 191, 169);
            mat.SetColor("_EmissionColor", EmissionColor * EmissionIntensity);
             
            
            
            
        }
        yield return new WaitForSeconds(2);
        StopFading();

        
    }

    public IEnumerator UnlockPlayer()
    {
      Player.GetComponent<PlayerController>().characterController.enabled = false;
      yield return new WaitForSeconds(0.1f);
      
        Player.GetComponent<PlayerController>().characterController.enabled = true;
        StopUnlock();
      
    }

    public void StopFading()
    {
      StopCoroutine(FadeInPlayer());
      Player.GetComponent<PlayerController>().speed = 5;
    }

    public void StopUnlock()
    {
      StopCoroutine(UnlockPlayer());
    }

}
