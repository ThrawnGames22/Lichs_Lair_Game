using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject TeleportUI;
    public Transform TeleportLocation;

    public GameObject DroppedTeleportLocation;

    public Transform Player;

    public bool HasPressedKey;

    public GameObject TeleportParticles;

    public float TimeTillTeleportStart = 0.5f;
    public float TimeTillTeleportFinish;
    

    public float TeleportSpeed;

    public bool HasTeleported = false;

    public Animator ParticleAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //TeleportUI.SetActive(false);
        this.gameObject.transform.parent = Player.transform;
        this.transform.Rotate(0,270,0);
        //Player.transform.position = new Vector3(13,13,13);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            TeleportUI.SetActive(true);
            HasPressedKey = true;
            Player.GetComponent<CharacterController>().enabled = false;
            //Player.transform.position = new Vector3(13,13,13);
        }

       
        if(Input.GetKeyUp(KeyCode.Q))
        {
            TeleportUI.SetActive(false);
            TeleportPlayerToLocation();
            DroppedTeleportLocation.transform.parent = null;
        }

        ParticleAnimator.SetBool("HasTeleported", HasTeleported);
        
    }

    public IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(TimeTillTeleportStart);
        Player.GetComponent<CharacterController>().enabled = true;
        StartCoroutine(DestroySpell());
        
    }

    public void TeleportPlayerToLocation()
    {
      if(HasTeleported == false)
      {
        StartCoroutine(TeleportPlayer());
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = DroppedTeleportLocation.transform.position;
        HasTeleported = true;
      }
    }

    public IEnumerator DestroySpell()
    {
       yield return new WaitForSeconds(0.5f);
       
        Destroy(this.gameObject);
       
    }
}
