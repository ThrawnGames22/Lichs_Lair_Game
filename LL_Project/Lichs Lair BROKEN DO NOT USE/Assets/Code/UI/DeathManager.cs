using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathManager : MonoBehaviour
{
    public GameObject Player;

    public GameObject DeathScreen;
    public GameObject BlackScreen;
    public GameObject YouDiedImage;
    public Color AlphaColor;

    public GameObject TryAgainButton;

    public Animator YouDiedImageAnimator;
    public float TimeToActivateButton;
    public bool PlayerIsDead;

    
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
        
    }

    public void ActivatePlayer()
    {
        PlayerHealth.Instance.Revive();
        
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

   
}
