using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Animator PlayerAnimator;
    public PlayerController playerController;

    public Vector3 speed;

    public bool IsSwinging;

    public SwordController Sword;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.IsFireMage)
        {
        Sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>();
        }
       speed = playerController.velocity;

       PlayerAnimator.SetBool("IsSwinging", IsSwinging);

       
    }

    public void UpadateAnimator(float horizontalValue, float verticalValue)
    {
        PlayerAnimator.SetFloat("Horizontal", horizontalValue);
        PlayerAnimator.SetFloat("Vertical", verticalValue);

    }

    public IEnumerator Swinging()
    {
        IsSwinging = true;
        Sword.ActivateParticles();
        yield return new WaitForSeconds(1);
        Sword.DeactivateParticles();

        
        ResetSwingFlag();

    }

    public IEnumerator SwingingBoxCollider()
    {
        
        Sword.boxCollider.enabled = false;
        Sword.StopDamage();
        yield return new WaitForSeconds(0.2f);
        Sword.boxCollider.enabled = true;
        Sword.StartDamage();
        yield return new WaitForSeconds(0.5f);
        Sword.StopDamage();
        Sword.boxCollider.enabled = false;

        
        ResetSwingFlag();

    }

    public void ResetSwingFlag()
    {
        StopCoroutine(Swinging());
        StopCoroutine(SwingingBoxCollider());

        IsSwinging = false;
    }
}
