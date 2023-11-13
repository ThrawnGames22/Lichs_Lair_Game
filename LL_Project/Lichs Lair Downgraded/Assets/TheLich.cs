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
    public bool SwipeIsActive1;
    public bool SwipeIsActive2;

    public bool HasStartedPhase2;

    public SkinnedMeshRenderer Pupils;

    public SkinnedMeshRenderer LichRenderer;


    //DeathMats
    public Material CapeDeathMat;
    public Material GoldDeathMat;
    public Material GemDeathMat;
    public Material Bone1DeathMat;
    public Material Bone2DeathMat;
    public Material BlackDeathMat;
    
    public Material[]NormalMats;




    public MeshRenderer Phalactory1;
    public MeshRenderer Phalactory2;


    public Material Phase2PupilMaterial;



    public BossTrigger bossTrigger;

    public GameObject BlockerBox;

    

    [Header("Spawning")]
    public GameObject Imps;
    public GameObject Zombies;
    public GameObject DeathKnights;

    public GameObject ManaPotion;
    public GameObject HealthPotion;


    public bool HasSpawned;

    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;
    public Transform SpawnPoint4;
    public Transform SpawnPoint5;
    public Transform SpawnPoint6;

    public Transform PotionSpawnPoint1;
    public Transform PotionSpawnPoint2;
    public Transform PotionSpawnPoint3;
    public Transform PotionSpawnPoint4;



    
    [Header("Walls")]
    public GameObject[] LeftWalls;
    
    public GameObject[] RightWalls;

    public GameObject[] FrontWalls;
    




    [Header("Animations")]

    public Animator LichAnimator;

    public Animator LichRiseAnimator;
    public Animator NecromancyLightAnimator1;
    public Animator NecromancyLightAnimator2;


    


    public bool IsDead;
    public bool IsCastingLeft;
    public bool IsCastingRight;

    public bool IsCastingForward;

    public bool IsSummoning;

    public bool StartDisolve;

    [Header("Health")]

    public int MaxHealth;
    public int CurrentHealth;

    public CanvasGroup HealthBarUI;

    public Slider HealthBar;

    public bool IsHurt;

    public Animator HurtAnim;

    public Sprite Phase1Bar;
    public Sprite Phase2Bar;

    public Image HealthBarImage;

    public int HalfWayPoint;

    public bool HasDied;

    public GameObject VictoryText;





    [Header("Sounds")]

    public AudioSource LichSoundSource;

    public AudioClip[]Screeches;

    public AudioClip SpawnSound;

    public bool HasPlayed;

    public AudioClip CombatMusic;
    public AudioClip VictoryMusic;

    public GameObject CombatMusicTriggerSphere;

    [Header("Particles and FX")]
    public ParticleSystem LeftHandParticles;
    public ParticleSystem RightHandParticles;

    public ParticleSystem DarkParticles;
    public ParticleSystem DarkAsh;

    public Light PurpleLight;
    public Light PurpleRoomLight;

    public Light RoomLight;




    [Header("MaterialData")]
    public float DisolveAmount1;
    public float DisolveAmount2;
    public float DisolveAmount3;
    public float DisolveAmount4;
    public float DisolveAmount5;
    public float DisolveAmount6;






    // Start is called before the first frame update
    void Start()
    {
        BlockerBox.SetActive(false);
        VictoryText.SetActive(false);
        DarkParticles.Stop();
        DarkAsh.Stop();
        PurpleLight.enabled = false;
        PurpleRoomLight.gameObject.SetActive(false);
        //CombatMusicTriggerSphere.SetActive(false);

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

        SpawnPoint1.gameObject.SetActive(false);
            SpawnPoint2.gameObject.SetActive(false);
            SpawnPoint3.gameObject.SetActive(false);
            SpawnPoint4.gameObject.SetActive(false);
            SpawnPoint5.gameObject.SetActive(false);
            SpawnPoint6.gameObject.SetActive(false);
        LeftHandParticles.Stop();
        RightHandParticles.Stop();

        //LichRenderer.materials[0] = CapeDeathMat;
        //LichRenderer.materials[1] = GoldDeathMat;
        //LichRenderer.materials[2] = GemDeathMat;
        //LichRenderer.materials[3] = Bone1DeathMat;
        //LichRenderer.materials[4] = Bone2DeathMat;
        //LichRenderer.materials[5] = BlackDeathMat;
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
        //HurtAnim.SetBool("IsDead", StartDisolve);

        LichRiseAnimator.SetBool("FightHasStarted", FightHasStarted);
        LichRiseAnimator.SetBool("IsDead", IsDead);

        NecromancyLightAnimator1.SetBool("SwipeIsActive", SwipeIsActive1);
        NecromancyLightAnimator2.SetBool("SwipeIsActive", SwipeIsActive2);
        
        



        if(FightHasStarted == true)
        {
            if(StartFight == false)
            {
            Phase1();
            HealthBarUI.alpha = 1;
            StartFight = true;
            LichSoundSource.clip = SpawnSound;
            LichSoundSource.Play();
            GameObject.Find("CombatAudioManager").GetComponent<CharacterSoundManager>().SwapTrack(CombatMusic);
            BlockerBox.SetActive(true);
            //CombatMusicTriggerSphere.SetActive(true);
            }
        }

        if(CurrentHealth <= HalfWayPoint)
        {
            FightHasStarted = false;
            
            HealthBarImage.sprite = Phase2Bar;
            HealthBarImage.color = new Color(255, 124, 0);
            Pupils.material = Phase2PupilMaterial; 
            Phalactory1.material = Phase2PupilMaterial;
            Phalactory2.material = Phase2PupilMaterial;


            if(HasStartedPhase2 == false)
            {
                Phase2();
                HasStartedPhase2 = true;
            }
        }

        if(CurrentHealth <= 0)
        {
          
            if(HasDied == false)
        {
            Die();
            StartCoroutine(DeathDisolve());
            GameObject.Find("CombatAudioManager").GetComponent<CharacterSoundManager>().SwapTrack(VictoryMusic);
            HealthBarUI.alpha = 0;
            HasDied = true;
            
            

        }
        }



        if(IsPhase2 == true)
        {
            
            

            

        }

        

    }

    public IEnumerator LerpColor()
    {
        yield return new WaitForSeconds(0);
        Color RoomColor = new Color(255,0, 197);
            float lerpTime = Random.Range(0f, 1f); 
            RoomLight.color = Color.Lerp(RoomLight.color, RoomColor, lerpTime);
    }

    public void TakeDamage(int Damage)
    {
      CurrentHealth -= Damage;
      IsHurt = true;
      
      StartCoroutine(ResetHurtFlag());
    }

    public void Die()
    {
        StopAllCoroutines();
        IsDead = true;
        LichRenderer.materials = new Material[]{
            CapeDeathMat,
             GoldDeathMat,
     GemDeathMat,
    Bone1DeathMat,
    Bone2DeathMat,
     BlackDeathMat
        };

        Pupils.gameObject.SetActive(false); 
        Phalactory1.gameObject.SetActive(false); 
        Phalactory2.gameObject.SetActive(false); 

        DarkParticles.Stop();
        DarkAsh.Stop();
        PurpleLight.enabled = false;
        PurpleRoomLight.gameObject.SetActive(false);
        StartCoroutine(VictoryTextShow());

        
        HasDied = true;

    }

    public IEnumerator VictoryTextShow()
    {
        yield return new WaitForSeconds(5f);
        VictoryText.SetActive(true);
    }
    


    public IEnumerator DeathDisolve()
    {
        

        
        yield return new WaitForSeconds(0.06f);
        LichRenderer.materials[0].SetFloat("_DisolveAmount", DisolveAmount1); 
        LichRenderer.materials[1].SetFloat("_DisolveAmount", DisolveAmount2); 
        LichRenderer.materials[2].SetFloat("_DisolveAmount", DisolveAmount3); 
        LichRenderer.materials[3].SetFloat("_DisolveAmount", DisolveAmount4); 
        LichRenderer.materials[4].SetFloat("_DisolveAmount", DisolveAmount5); 
        LichRenderer.materials[5].SetFloat("_DisolveAmount", DisolveAmount6); 
      
        
        DisolveAmount1 += 1f * Time.deltaTime;
        DisolveAmount2 += 1f * Time.deltaTime;
        DisolveAmount3 += 1f * Time.deltaTime;
        DisolveAmount4 += 1f * Time.deltaTime;
        DisolveAmount5 += 1f * Time.deltaTime;
        DisolveAmount6 += 1f * Time.deltaTime;
        StartCoroutine(DeathDisolve());
        

        
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
        Destroy(GameObject.Find("Mana Potion"));
        Destroy(GameObject.Find("Health Potion"));

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
        SwipeIsActive1 = true;
        LeftHandParticles.Play();
        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);
        
        
        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;
        LeftHandParticles.Stop();


        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }

        IsCastingLeft = false;
        IsCastingRight = true;
        SwipeIsActive2 = true;
        RightHandParticles.Play();


        LeftWalls[Random.Range(0, LeftWalls.Length)].SetActive(true);

        yield return new WaitForSeconds(2.292f);
        SwipeIsActive2 = false;
        RightHandParticles.Stop();


        foreach(GameObject wall in LeftWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = true;
        IsCastingRight = false;
        SwipeIsActive1 = true;
        LeftHandParticles.Play();


        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);

        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;
        LeftHandParticles.Stop();


        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }

        IsCastingLeft = false;
        IsCastingRight = false;
        SwipeIsActive1 = false;

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
        LeftHandParticles.Play();
        RightHandParticles.Play();


        yield return new WaitForSeconds(5.333f);
         LeftHandParticles.Stop();
        RightHandParticles.Stop();
        if(HasSpawned == false)
        {
            SpawnPoint1.gameObject.SetActive(true);
            SpawnPoint2.gameObject.SetActive(true);
            SpawnPoint3.gameObject.SetActive(true);
            SpawnPoint4.gameObject.SetActive(true);
            SpawnPoint5.gameObject.SetActive(true);
            SpawnPoint6.gameObject.SetActive(true);




            GameObject EnemyClone1 = Instantiate(Zombies, SpawnPoint1.position, SpawnPoint1.rotation);
            GameObject EnemyClone2 = Instantiate(Zombies, SpawnPoint2.position, SpawnPoint2.rotation);
            GameObject EnemyClone3 = Instantiate(Zombies, SpawnPoint3.position, SpawnPoint3.rotation);
            GameObject EnemyClone4 = Instantiate(Zombies, SpawnPoint4.position, SpawnPoint4.rotation);
            GameObject EnemyClone5 = Instantiate(Zombies, SpawnPoint5.position, SpawnPoint5.rotation);
            GameObject EnemyClone6 = Instantiate(Zombies, SpawnPoint6.position, SpawnPoint6.rotation);

            GameObject PotionClone1 = Instantiate(ManaPotion, PotionSpawnPoint1.position, PotionSpawnPoint1.rotation);
            GameObject PotionClone2 = Instantiate(HealthPotion, PotionSpawnPoint2.position, PotionSpawnPoint2.rotation);
            GameObject PotionClone3 = Instantiate(ManaPotion, PotionSpawnPoint3.position, PotionSpawnPoint3.rotation);
            GameObject PotionClone4 = Instantiate(HealthPotion, PotionSpawnPoint4.position, PotionSpawnPoint4.rotation);


            HasSpawned = true;

            

        }
        IsSummoning = false;
        yield return new WaitForSeconds(30);
        StartCoroutine(Phase1Idle3());
    }

    public IEnumerator Phase1Idle3()
    {
            
        StopCoroutine(Phase1Spawning1());
        SpawnPoint1.gameObject.SetActive(false);
            SpawnPoint2.gameObject.SetActive(false);
            SpawnPoint3.gameObject.SetActive(false);
            SpawnPoint4.gameObject.SetActive(false);
            SpawnPoint5.gameObject.SetActive(false);
            SpawnPoint6.gameObject.SetActive(false);

        yield return new WaitForSeconds(5);

        StartCoroutine(Phase1Walls2());
    }

    public IEnumerator Phase1Walls2()
    {
        StopCoroutine(Phase1Idle3());

        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = true;
        SwipeIsActive1 = true;
        SwipeIsActive2 = true;
        LeftHandParticles.Play();
        RightHandParticles.Play();




        FrontWalls[Random.Range(0, FrontWalls.Length)].SetActive(true);

        yield return new WaitForSeconds(2.292f);
        LeftHandParticles.Stop();
        LeftHandParticles.Stop();


        SwipeIsActive1 = false;
        SwipeIsActive2 = false;
        foreach(GameObject wall in FrontWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = false;
        IsCastingRight = true;
        IsCastingForward = false;
        SwipeIsActive2 = true;
        RightHandParticles.Play();


        LeftWalls[Random.Range(0, LeftWalls.Length)].SetActive(true);
        RightHandParticles.Stop();
        

        yield return new WaitForSeconds(2.292f);
        SwipeIsActive2 = false;

        foreach(GameObject wall in LeftWalls)
        {
            wall.SetActive(false);
        }
        IsCastingForward = false;
        IsCastingRight = false;
        IsCastingForward = true;
        SwipeIsActive2 = true;
        SwipeIsActive1 = true;
        RightHandParticles.Play();
        LeftHandParticles.Play();




        FrontWalls[Random.Range(0, FrontWalls.Length)].SetActive(true);


        yield return new WaitForSeconds(2.292f);
        RightHandParticles.Stop();
        LeftHandParticles.Stop();

        SwipeIsActive2 = false;
        SwipeIsActive1 = false;
        foreach(GameObject wall in FrontWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;
        SwipeIsActive1 = true;
        LeftHandParticles.Play();

        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);




        yield return new WaitForSeconds(2.292f);
        LeftHandParticles.Stop();

        SwipeIsActive1 = false;

        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }
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
        SwipeIsActive2 = true;
        RightHandParticles.Play();


        LeftWalls[Random.Range(0, LeftWalls.Length)].SetActive(true);

        yield return new WaitForSeconds(2.292f);
        RightHandParticles.Stop();

        SwipeIsActive2 = false;

        foreach(GameObject wall in LeftWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;
        SwipeIsActive1 = true;
        LeftHandParticles.Play();


        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);


        yield return new WaitForSeconds(2.292f);
        LeftHandParticles.Stop();

        SwipeIsActive1 = false;

        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = true;
        SwipeIsActive1 = true;
        SwipeIsActive2 = true;
        LeftHandParticles.Play();
        RightHandParticles.Play();



        FrontWalls[Random.Range(0, FrontWalls.Length)].SetActive(true);


        yield return new WaitForSeconds(2.292f);
        LeftHandParticles.Play();
        RightHandParticles.Play();
        SwipeIsActive1 = false;
        SwipeIsActive2 = false;
        foreach(GameObject wall in FrontWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;
        SwipeIsActive1 = true;
        LeftHandParticles.Play();
        


        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);
        


        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;
        LeftHandParticles.Stop();
        


        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        SwipeIsActive1 = false;
        HasSpawned = false;

        StartCoroutine(Phase1Idle1());
        //yield return new WaitForSeconds(5);
    }














    // ________________PHASE 2________________//


    
    public void Phase2()
    {
        
      StopAllCoroutines();
      IsPhase2 = true;
      IsPhase1 = false;
      DarkParticles.Play();
        DarkAsh.Play();
        PurpleLight.enabled = true;
        PurpleRoomLight.gameObject.SetActive(true);
        
        


      
      //LichAnimator.speed = 2f;
      
      foreach(GameObject wall in RightWalls)
        {
            wall.GetComponent<Animator>().speed = 1.5f;
        }

      foreach(GameObject wall in LeftWalls)
        {
            wall.GetComponent<Animator>().speed = 1.5f;
        }

      foreach(GameObject wall in FrontWalls)
        {
            wall.GetComponent<Animator>().speed = 1.5f;
        } 

        
        StartPhase2();
    }

    public void StartPhase2()
    {
        StartCoroutine(Phase2Idle1());
    }

    
    
public IEnumerator Phase2Idle1()
    {
        StopCoroutine(Phase2Walls4());
        Destroy(GameObject.Find("Mana Potion"));
        Destroy(GameObject.Find("Health Potion"));
        IsDead = false;
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        IsSummoning = false;
        StopCoroutine(Phase1Idle1());
            StopCoroutine(Phase1Idle2());
            StopCoroutine(Phase1Idle3());
            StopCoroutine(Phase1Idle4());
            StopCoroutine(Phase1Spawning1());
            StopCoroutine(Phase1Walls());
            StopCoroutine(Phase1Walls2());
            StopCoroutine(Phase1Walls4());
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Phase2Walls());
    }

    public IEnumerator Phase2Walls()
    {
        StopCoroutine(Phase2Idle1());
        IsCastingLeft = true;
        IsCastingRight = false;
        SwipeIsActive1 = true;

        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);
        
        
        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;

        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }

        IsCastingLeft = false;
        IsCastingRight = true;
        SwipeIsActive2 = true;

        LeftWalls[Random.Range(0, LeftWalls.Length)].SetActive(true);

        yield return new WaitForSeconds(2.292f);
        SwipeIsActive2 = false;

        foreach(GameObject wall in LeftWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = true;
        IsCastingRight = false;
        SwipeIsActive1 = true;

        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);

        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;

        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }

        IsCastingLeft = false;
        IsCastingRight = false;
        StartCoroutine(Phase2Idle2());
        
    }

    public IEnumerator Phase2Idle2()
    {
        StopCoroutine(Phase2Walls());

        yield return new WaitForSeconds(5);

        StartCoroutine(Phase2Spawning1());

    }

    public IEnumerator Phase2Spawning1()
    {
        StopCoroutine(Phase2Idle2());
        IsSummoning = true;
        yield return new WaitForSeconds(5.333f);
        SpawnPoint1.gameObject.SetActive(true);

        if(HasSpawned == false)
        {
            SpawnPoint2.gameObject.SetActive(true);
            SpawnPoint3.gameObject.SetActive(true);
            SpawnPoint4.gameObject.SetActive(true);
            SpawnPoint5.gameObject.SetActive(true);
            SpawnPoint6.gameObject.SetActive(true);




            GameObject EnemyClone1 = Instantiate(Zombies, SpawnPoint1.position, SpawnPoint1.rotation);
            GameObject EnemyClone2 = Instantiate(Zombies, SpawnPoint2.position, SpawnPoint2.rotation);
            GameObject EnemyClone3 = Instantiate(Zombies, SpawnPoint3.position, SpawnPoint3.rotation);
            GameObject EnemyClone4 = Instantiate(Zombies, SpawnPoint4.position, SpawnPoint4.rotation);
            GameObject EnemyClone5 = Instantiate(Zombies, SpawnPoint5.position, SpawnPoint5.rotation);
            GameObject EnemyClone6 = Instantiate(Zombies, SpawnPoint6.position, SpawnPoint6.rotation);

            GameObject EnemyClone7 = Instantiate(Zombies, SpawnPoint1.position, SpawnPoint1.rotation);
            GameObject EnemyClone8 = Instantiate(Zombies, SpawnPoint2.position, SpawnPoint2.rotation);
            GameObject EnemyClone9 = Instantiate(Zombies, SpawnPoint3.position, SpawnPoint3.rotation);
            GameObject EnemyClone10 = Instantiate(Zombies, SpawnPoint4.position, SpawnPoint4.rotation);
            GameObject EnemyClone11 = Instantiate(Zombies, SpawnPoint5.position, SpawnPoint5.rotation);
            GameObject EnemyClone12 = Instantiate(Zombies, SpawnPoint6.position, SpawnPoint6.rotation);

            GameObject EnemyClone13 = Instantiate(DeathKnights, SpawnPoint1.position, SpawnPoint1.rotation);
            GameObject EnemyClone14 = Instantiate(DeathKnights, SpawnPoint2.position, SpawnPoint2.rotation);
            GameObject EnemyClone15 = Instantiate(DeathKnights, SpawnPoint3.position, SpawnPoint3.rotation);
            GameObject EnemyClone16 = Instantiate(DeathKnights, SpawnPoint4.position, SpawnPoint4.rotation);
            GameObject EnemyClone17 = Instantiate(DeathKnights, SpawnPoint5.position, SpawnPoint5.rotation);

            GameObject EnemyClone18 = Instantiate(Imps, SpawnPoint1.position, SpawnPoint1.rotation);
            GameObject EnemyClone19 = Instantiate(Imps, SpawnPoint2.position, SpawnPoint2.rotation);
            GameObject EnemyClone20 = Instantiate(Imps, SpawnPoint3.position, SpawnPoint3.rotation);
            GameObject EnemyClone21 = Instantiate(Imps, SpawnPoint4.position, SpawnPoint4.rotation);

            GameObject PotionClone1 = Instantiate(ManaPotion, PotionSpawnPoint1.position, PotionSpawnPoint1.rotation);
            GameObject PotionClone2 = Instantiate(HealthPotion, PotionSpawnPoint2.position, PotionSpawnPoint2.rotation);
            GameObject PotionClone3 = Instantiate(ManaPotion, PotionSpawnPoint3.position, PotionSpawnPoint3.rotation);
            GameObject PotionClone4 = Instantiate(HealthPotion, PotionSpawnPoint4.position, PotionSpawnPoint4.rotation);

            HasSpawned = true;


        }
        IsSummoning = false;
        yield return new WaitForSeconds(9);
        StartCoroutine(Phase2Idle3());
    }

    public IEnumerator Phase2Idle3()
    {
        StopCoroutine(Phase2Spawning1());
        SpawnPoint1.gameObject.SetActive(false);
            SpawnPoint2.gameObject.SetActive(false);
            SpawnPoint3.gameObject.SetActive(false);
            SpawnPoint4.gameObject.SetActive(false);
            SpawnPoint5.gameObject.SetActive(false);
            SpawnPoint6.gameObject.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        StartCoroutine(Phase2Walls2());
    }

    public IEnumerator Phase2Walls2()
    {
        StopCoroutine(Phase2Idle3());

        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = true;
        SwipeIsActive1 = true;
        SwipeIsActive2 = true;


        FrontWalls[Random.Range(0, FrontWalls.Length)].SetActive(true);

        yield return new WaitForSeconds(1.146f);
        SwipeIsActive1 = false;
        SwipeIsActive2 = false;
        foreach(GameObject wall in FrontWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = false;
        IsCastingRight = true;
        IsCastingForward = false;
        SwipeIsActive2 = true;

        LeftWalls[Random.Range(0, LeftWalls.Length)].SetActive(true);


        yield return new WaitForSeconds(2.292f);
        SwipeIsActive2 = false;

        foreach(GameObject wall in LeftWalls)
        {
            wall.SetActive(false);
        }
        IsCastingForward = false;
        IsCastingRight = false;
        IsCastingForward = true;
        SwipeIsActive2 = true;
        SwipeIsActive1 = true;


        FrontWalls[Random.Range(0, FrontWalls.Length)].SetActive(true);


        yield return new WaitForSeconds(2.292f);
        SwipeIsActive2 = false;
        SwipeIsActive1 = false;
        foreach(GameObject wall in FrontWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;
        SwipeIsActive1 = true;

        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);




        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;

        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        
        StartCoroutine(Phase2Idle4());

        
    }

    public IEnumerator Phase2Idle4()
    {
        StopCoroutine(Phase2Walls2());

        yield return new WaitForSeconds(2);

        StartCoroutine(Phase2Walls4());
    }

    public IEnumerator Phase2Walls4()
    {
        StopCoroutine(Phase2Idle4());

        IsCastingLeft = false;
        IsCastingRight = true;
        IsCastingForward = false;
        SwipeIsActive2 = true;

        LeftWalls[Random.Range(0, LeftWalls.Length)].SetActive(true);

        yield return new WaitForSeconds(2.292f);
        SwipeIsActive2 = false;

        foreach(GameObject wall in LeftWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;
        SwipeIsActive1 = true;

        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);


        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;

        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = true;
        SwipeIsActive1 = true;
        SwipeIsActive2 = true;


        FrontWalls[Random.Range(0, FrontWalls.Length)].SetActive(true);


        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;
        SwipeIsActive2 = false;
        foreach(GameObject wall in FrontWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = true;
        IsCastingRight = false;
        IsCastingForward = false;
        SwipeIsActive1 = true;

        RightWalls[Random.Range(0, RightWalls.Length)].SetActive(true);
        


        yield return new WaitForSeconds(2.292f);
        SwipeIsActive1 = false;

        foreach(GameObject wall in RightWalls)
        {
            wall.SetActive(false);
        }
        IsCastingLeft = false;
        IsCastingRight = false;
        IsCastingForward = false;
        SwipeIsActive1 = false;
        HasSpawned = false;


        StartCoroutine(Phase2Idle1());
        //yield return new WaitForSeconds(5);
    }

    

}
