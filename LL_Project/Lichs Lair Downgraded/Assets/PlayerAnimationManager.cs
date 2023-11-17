using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Animator PlayerAnimator;
    public PlayerController playerController;

    public Vector3 speed;

    public bool IsSwinging;

    public bool IsUsingBow;

    public SwordController Sword;
    public BowController Bow;

    // Start is called before the first frame update
    void Start()
    {
        

        

        if(playerController.IsShadowWizard)
        {
        Bow = GameObject.FindGameObjectWithTag("Bow").GetComponent<BowController>();
        //PlayerAnimator.SetBool("IsUsingBow", IsUsingBow);
        }

        if(playerController.IsPaladin)
        {
        Sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>();
        Sword.boxCollider.enabled = false;

        //PlayerAnimator.SetBool("IsSwinging", IsSwinging);
        }

        if(playerController.IsFireMage)
        {
        Sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>();
        Sword.boxCollider.enabled = false;

        //PlayerAnimator.SetBool("IsSwinging", IsSwinging);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.IsFireMage)
        {
        //Sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>();
        PlayerAnimator.SetBool("IsSwinging", IsSwinging);
        }

        if(playerController.IsShadowWizard)
        {
        //Bow = GameObject.FindGameObjectWithTag("Bow").GetComponent<BowController>();
        PlayerAnimator.SetBool("IsUsingBow", IsUsingBow);
        }

        if(playerController.IsPaladin)
        {
       // Sword = GameObject.FindGameObjectWithTag("Sword").GetComponent<SwordController>();
        PlayerAnimator.SetBool("IsSwinging", IsSwinging);
        }
       speed = playerController.velocity;

       
        
       
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

    public IEnumerator UsingBow()
    {
        IsUsingBow = true;
        PlayerAnimator.SetLayerWeight(3, 1);
        yield return new WaitForSeconds(0.525f);
        Bow.Shoot();
        yield return new WaitForSeconds(0.525f);
        PlayerAnimator.SetLayerWeight(3, 0);
        IsUsingBow = false;
        StopCoroutine(UsingBow());

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

    public void ResetBowFlag()
    {
        
    }
}
