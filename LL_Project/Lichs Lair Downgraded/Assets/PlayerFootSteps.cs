using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    public AudioSource FootstepSource;
    public AudioClip[] FootstepClips;

    public PlayerController playerController;

    public CharacterController cc;

    public bool PlaySteps;
    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.isGrounded == true && cc.velocity.magnitude > 2f && FootstepSource.isPlaying == false)
        {
            FootstepSource.Play();
            FootstepSource.volume = Random.Range(0.2f, 0.6f);
            FootstepSource.pitch = Random.Range(0.8f, 1.1f);

            
        }

        
    }

    /*public IEnumerator PlayFootSteps()
    {
        PlaySteps = false;
        if(PlaySteps == false)
        {
          FootstepSource.PlayOneShot(FootstepClips[Random.Range(0, FootstepClips.Length)]);
          yield return new WaitForSeconds(5f);
          PlaySteps = true;
          StartCoroutine(PlayFootSteps());
        }
        
    }
    */
}
