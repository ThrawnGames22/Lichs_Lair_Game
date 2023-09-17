using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    //SCRIPT HANDLES PLAYER DEATH AND UI COMPONENTS TO ACTIVATE
    public GameObject Player;

    public GameObject DeathScreen;
    public GameObject BlackScreen;
    public GameObject YouDiedImage;
    public Color AlphaColor;

    public GameObject TryAgainButton;

    public Animator YouDiedImageAnimator;
    public float TimeToActivateButton;
    public bool PlayerIsDead;

    public AudioClip[] BossLaugh;

    public AudioSource bossLaughSource;
    public bool HasPlayed = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
        DeathScreen = GameObject.Find("Death Screen");
        TryAgainButton = GameObject.Find("Try Again");
        
        
        BlackScreen = GameObject.Find("BlackDeathScreen");
        YouDiedImage = GameObject.Find("You Died Image");
        YouDiedImageAnimator = GameObject.Find("You Died Image").GetComponent<Animator>();
        SetScreen();

        
        TryAgainButton.SetActive(false);
        
    }

    /*void Awake()
    {
        DeathScreen = GameObject.Find("Death Screen");
        DeathScreen.SetActive(true);
    }
    */

    // Update is called once per frame
    void Update()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerIsDead = Player.GetComponent<PlayerHealth>().IsDead;
        if(PlayerIsDead == true)
        {
            YouDiedImageAnimator.SetTrigger("PlayerIsDead");
            if(HasPlayed == false)
            {
               bossLaughSource.clip = BossLaugh[Random.Range(0, BossLaugh.Length)];
               bossLaughSource.Play();
               HasPlayed = true; 
            }
            //StartCoroutine(IncreaseAlphaOnDeathScreen());
        var BScolor = BlackScreen.GetComponent<Image>().color;
        var YDIcolor = YouDiedImage.GetComponent<Image>().color;
         TryAgainButton.SetActive(true);
        
        BScolor.a += 0.3f * Time.deltaTime;
        YDIcolor.a += 0.3f * Time.deltaTime;

        

        BlackScreen.GetComponent<Image>().color = BScolor;
        YouDiedImage.GetComponent<Image>().color = YDIcolor;
        }
        
        if(PlayerIsDead == false)
        {
           TryAgainButton.SetActive(false); 
        }
    }

    

    public void Retry()
    {
        GlobalSceneManager.Instance.ResetScene();
        ActivatePlayer();
        HasPlayed = false;
        
    }

    public void ActivatePlayer()
    {
        PlayerHealth.Instance.Revive();
        SetScreen();
        
    }

   

    public void SetScreen()
    {
        
        //TryAgainButton.SetActive(false);
        var BScolor = BlackScreen.GetComponent<Image>().color;
        var YDIcolor = YouDiedImage.GetComponent<Image>().color;
        
        BScolor.a = 0f;
        YDIcolor.a = 0f;
        BlackScreen.GetComponent<Image>().color = BScolor;
        YouDiedImage.GetComponent<Image>().color = YDIcolor;
    }

    public void SetDeathScreenActive()
    {
        DeathScreen.SetActive(true);
    }

   
}
