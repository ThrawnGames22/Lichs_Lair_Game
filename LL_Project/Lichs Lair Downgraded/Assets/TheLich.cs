using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheLich : MonoBehaviour
{
    [Header("Mechanics")]

    public bool IsPhase1;

    public bool IsPhase2;

    public bool FightHasStarted;

    public bool StartFight;

    public BossTrigger bossTrigger;

    

    [Header("Spawning")]
    public GameObject Imps;
    public GameObject Zombies;
    public GameObject DeathKnights;

    
    [Header("Walls")]
    public GameObject[] LeftWalls;
    
    public GameObject[] RightWalls;

    public GameObject[] FrontWalls;
    




    [Header("Animations")]

    public Animator LichAnimator;

    public Animator LichRiseAnimator;
    


    public bool IsDead;
    public bool IsCastingLeft;
    public bool IsCastingRight;

    public bool IsCastingForward;

    public bool IsSummoning;

    [Header("Health")]

    public int MaxHealth;
    public int CurrentHealth;

    public CanvasGroup HealthBarUI;

    public Slider HealthBar;

    public bool IsHurt;

    public Animator HurtAnim;




    [Header("Sounds")]

    public AudioSource LichSoundSource;




    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject wall in LeftWalls)
        {
            wall.SetActive(false);
        }

        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }

        HealthBarUI.alpha = 0;
        HealthBar.maxValue = MaxHealth;
        CurrentHealth = MaxHealth;


        
    }

    // Update is called once per frame
    void Update()
    {
        LichAnimator.SetBool("IsDead", IsDead);
        LichAnimator.SetBool("IsCastingLeft", IsCastingLeft);
        LichAnimator.SetBool("IsCastingRight", IsCastingRight);
        LichAnimator.SetBool("IsCastingForward", IsCastingForward);
        LichAnimator.SetBool("IsSummoning", IsSummoning);
        //LichAnimator.SetBool("",);
        HealthBar.value = CurrentHealth;

        HurtAnim.SetBool("IsHurt", IsHurt);
        LichRiseAnimator.SetBool("FightHasStarted", FightHasStarted);

        if(FightHasStarted == true)
        {
            if(StartFight == false)
            {
            Phase1();
            HealthBarUI.alpha = 1;
            StartFight = true;
            }
        }

    }

    public void TakeDamage(int Damage)
    {
      CurrentHealth -= Damage;
      IsHurt = true;
      
      StartCoroutine(ResetHurtFlag());
    }

    public IEnumerator ResetHurtFlag()
    {
      yield return new WaitForSeconds(0.1f);
      IsHurt = false;
      ResetFlag();

      
    }

    public void ResetFlag()
    {
      //HasPlayedSound = false;
      StopCoroutine(ResetHurtFlag());
    }

    // ________________PHASE 1________________//

    public void Phase1()
    {
      IsPhase1 = true;
      

      StartCoroutine(Phase1Idle1());
    }
    

    public IEnumerator Phase1Idle1()
    {
        StopCoroutine(Phase1Walls4());
        IsDead = false;
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        IsSummoning = false;
        yield return new WaitForSeconds(5);
        StartCoroutine(Phase1Walls());
    }

    public IEnumerator Phase1Walls()
    {
        StopCoroutine(Phase1Idle1());
        IsCastingLeft = true;
        IsCastingRight = false;
        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = false;
        IsCastingRight = true;
        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = true;
        IsCastingRight = false;
        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = false;
        IsCastingRight = false;
        StartCoroutine(Phase1Idle2());
        
    }

    public IEnumerator Phase1Idle2()
    {
        StopCoroutine(Phase1Walls());

        yield return new WaitForSeconds(5);

        StartCoroutine(Phase1Spawning1());

    }

    public IEnumerator Phase1Spawning1()
    {
        StopCoroutine(Phase1Idle2());
        IsSummoning = true;
        yield return new WaitForSeconds(5.333f);
        IsSummoning = false;
        yield return new WaitForSeconds(9);
        StartCoroutine(Phase1Idle3());
    }

    public IEnumerator Phase1Idle3()
    {
        StopCoroutine(Phase1Spawning1());

        yield return new WaitForSeconds(5);

        StartCoroutine(Phase1Walls2());
    }

    public IEnumerator Phase1Walls2()
    {
        StopCoroutine(Phase1Idle3());

        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = true;
        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = false;
        IsCastingRight = true;
        IsCastingForward = false;

        yield return new WaitForSeconds(2.292f);
        IsCastingForward = false;
        IsCastingRight = false;
        IsCastingForward = true;

        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;



        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        
        StartCoroutine(Phase1Idle4());

        
    }

    public IEnumerator Phase1Idle4()
    {
        StopCoroutine(Phase1Walls2());

        yield return new WaitForSeconds(2);

        StartCoroutine(Phase1Walls4());
    }

    public IEnumerator Phase1Walls4()
    {
        StopCoroutine(Phase1Idle4());

        IsCastingLeft = false;
        IsCastingRight = true;
        IsCastingForward = false;
        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;

        yield return new WaitForSeconds(2.292f);
        IsCastingForward = false;
        IsCastingRight = false;
        IsCastingForward = true;

        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = true;



        yield return new WaitForSeconds(2.292f);
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        StartCoroutine(Phase1Idle1());
        //yield return new WaitForSeconds(5);
    }














    // ________________PHASE 2________________//

    public void Phase2()
    {
      IsPhase2 = true;
      LichAnimator.speed = 1f;
      StartCoroutine(Phase2Idle1());
    }
    

    public IEnumerator Phase2Idle1()
    {
        StopCoroutine(Phase2Walls4());
        LichAnimator.speed = 1f;

        IsDead = false;
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        IsSummoning = false;
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Phase2Walls());
    }

    public IEnumerator Phase2Walls()
    {
        StopCoroutine(Phase1Idle1());
       LichAnimator.speed = 2f;

        IsCastingLeft = true;
        IsCastingRight = false;
        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = false;
        IsCastingRight = true;
        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = true;
        IsCastingRight = false;
        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = false;
        IsCastingRight = false;
        StartCoroutine(Phase2Idle2());
        
    }

    public IEnumerator Phase2Idle2()
    {
        

        StopCoroutine(Phase2Walls());
        LichAnimator.speed = 1f;


        yield return new WaitForSeconds(2.5f);

        StartCoroutine(Phase2Spawning1());

    }

    public IEnumerator Phase2Spawning1()
    {
        

        StopCoroutine(Phase1Idle2());
        LichAnimator.speed = 1f;

        IsSummoning = true;
        yield return new WaitForSeconds(5.333f);
        IsSummoning = false;
        yield return new WaitForSeconds(9);
        StartCoroutine(Phase2Idle3());
    }

    public IEnumerator Phase2Idle3()
    
    {
        
        StopCoroutine(Phase1Spawning1());
        LichAnimator.speed = 1f;
        

        yield return new WaitForSeconds(5);

        StartCoroutine(Phase2Walls2());
    }

    public IEnumerator Phase2Walls2()
    {
        StopCoroutine(Phase2Idle3());
        LichAnimator.speed = 2f;
        
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = true;
        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = false;
        IsCastingRight = true;
        IsCastingForward = false;

        yield return new WaitForSeconds(1.146f);
        IsCastingForward = false;
        IsCastingRight = false;
        IsCastingForward = true;

        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;



        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        
        StartCoroutine(Phase2Idle4());

        
    }

    public IEnumerator Phase2Idle4()
    {
        

        StopCoroutine(Phase2Walls2());
        LichAnimator.speed = 1f;

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(Phase2Walls4());
    }

    public IEnumerator Phase2Walls4()
    {
        StopCoroutine(Phase1Idle4());
        LichAnimator.speed = 2f;
        
        IsCastingLeft = false;
        IsCastingRight = true;
        IsCastingForward = false;
        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;

        yield return new WaitForSeconds(1.146f);
        IsCastingForward = false;
        IsCastingRight = false;
        IsCastingForward = true;

        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = true;



        yield return new WaitForSeconds(1.146f);
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        StartCoroutine(Phase2Idle1());
        //yield return new WaitForSeconds(5);
    }

}
