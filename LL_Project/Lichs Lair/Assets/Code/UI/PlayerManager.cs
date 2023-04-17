using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public GameObject RedMage;
    public GameObject ShadowMage;
    public GameObject SunMage;

    public GameObject PlayerObject;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAsRedMage()
    {
      GameObject Player;
      Player = Instantiate(RedMage, this.transform.position, this.transform.rotation);
      Player.transform.parent = PlayerObject.transform;
      //UI.SetActive(true);
    }

     public void PlayAsShadowMage()
    {
      GameObject Player;
      Player = Instantiate(ShadowMage, this.transform.position, this.transform.rotation);
      Player.transform.parent = PlayerObject.transform;
    }

     public void PlayAsSunMage()
    {
      GameObject Player;
      Player = Instantiate(SunMage, this.transform.position, this.transform.rotation);
      Player.transform.parent = PlayerObject.transform;
    }

    
}
