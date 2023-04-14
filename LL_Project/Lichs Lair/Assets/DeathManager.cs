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

    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        DeathScreen = GameObject.Find("Death Screen");
        TryAgainButton = GameObject.Find("Try Again");
        
        
        BlackScreen = GameObject.Find("BlackDeathScreen");
        YouDiedImage = GameObject.Find("You Died Image");
        YouDiedImageAnimator = GameObject.Find("You Died Image").GetComponent<Animator>();

        var BScolor = BlackScreen.GetComponent<Image>().color;
        var YDIcolor = YouDiedImage.GetComponent<Image>().color;
        
        BScolor.a = 0f;
        YDIcolor.a = 0f;
        BlackScreen.GetComponent<Image>().color = BScolor;
        YouDiedImage.GetComponent<Image>().color = YDIcolor;
        TryAgainButton.SetActive(false);
        
    }

    /*void Awake()
    {
        DeathScreen = GameObject.Find("Death Screen");
        DeathScreen.SetActive(true);
    }
    */

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player == null)
        {
            YouDiedImageAnimator.SetTrigger("PlayerIsDead");
            //StartCoroutine(IncreaseAlphaOnDeathScreen());
        var BScolor = BlackScreen.GetComponent<Image>().color;
        var YDIcolor = YouDiedImage.GetComponent<Image>().color;
        StartCoroutine(SetButtonsActive());
        
        BScolor.a += 0.3f * Time.deltaTime;
        YDIcolor.a += 0.3f * Time.deltaTime;
        

        BlackScreen.GetComponent<Image>().color = BScolor;
        YouDiedImage.GetComponent<Image>().color = YDIcolor;
        }
    }

    public IEnumerator SetButtonsActive()
    {
      yield return new WaitForSeconds(TimeToActivateButton);
      TryAgainButton.SetActive(true);
    }

    public void Retry()
    {
        GlobalSceneManager.Instance.ResetScene();
    }

   
}
