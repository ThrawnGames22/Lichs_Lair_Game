using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerData playerData;
    public ClassData MageClassData;
    
    [Header ("Player Vairiables")]
    public static PlayerController Instance;
    public PlayerHealth PH;
    public PlayerMagic PM;
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public Vector3 velocity;
    public Vector3 CurrentPosition;

    public CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    public bool IsInFrontCameraView;
    public bool IsInBackCameraView;
    public bool IsInLeftCameraView;
    public bool IsInRightCameraView;

    public float horizontalInput;
    public float verticalInput;

    [Header ("Player Dash")]
    //cooldown
    public float dashSpeed;
    public float dashTime;
    public float dashCD;
    public float maxDashCD;
    //determines if we can use dash
    public bool canUseDash;
    public bool IsMoving;
    public bool CanJump;

    public GameObject PlayerDashReadyIcon;
    public GameObject PlayerDashNotReadyIcon;
    public bool IconShow;


    [Header ("Player Combat")]
    private GameObject WeaponSaveSlot;
    public GameObject CurrentWeaponSlot;
    public GameObject CurrentSlot;
    public GameObject WeaponsBank;

    public GameObject[] Weapons;
    

    public Animator WeaponAnimator;
    public int WeaponNumber = 1;
    public float ChargeAttackTimer;
    public bool AttackBlocked;
    public bool ChargeAttacking;
    public float MeleeWeaponDelay = 0.3f;

    public float ChargedDamageValue;
    public float NormalDamageValue;
    public float AttackValue;

    [Header("PotionEffects")]
    
    public GameObject[] Enemies;
    public bool DamageNegationActive;
    public float DNTime;

    public int CurrentDamageNegationAmount;
    public int NormalDNAmount = 0;

    public bool IsGrounded;

    public float YSpeed;



    
    

    private void Awake()
    {
        Instance = this;
    }

   

    void Start()
    {
        dashCD = maxDashCD;
        IconShow = true;
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        
        IsInFrontCameraView = true;

        if(MageClassData.Class == "Fire")
        {
         CurrentWeaponSlot = Weapons[0];
         Weapons[0].transform.parent = CurrentSlot.transform;
         Weapons[0].SetActive(true);
         Weapons[1].SetActive(false);
         Weapons[2].SetActive(false);
        }
        if(MageClassData.Class == "Shadow")
        {
         CurrentWeaponSlot = Weapons[1];   
         Weapons[2].transform.parent = CurrentSlot.transform;
         Weapons[0].SetActive(false);
         Weapons[1].SetActive(true);
         Weapons[2].SetActive(false);
        }
        if(MageClassData.Class == "Sun")
        {
         CurrentWeaponSlot = Weapons[2]; 
         Weapons[1].transform.parent = CurrentSlot.transform;
         Weapons[0].SetActive(false);
         Weapons[1].SetActive(false);
         Weapons[2].SetActive(true);
        }
         
        
    }

    void Update()
     {
        WeaponSaveSlot = CurrentWeaponSlot;
        CurrentPosition = this.transform.position;
        if(Input.GetKeyDown(KeyCode.U))
        {
            SavePlayerData();
        }
        dashCD -= Time.deltaTime;
            
            //if(characterController.isGrounded)
           // {
              if(Input.GetKeyDown(KeyCode.LeftShift) && IsMoving)
              {
                if(dashCD <= 0)
                {

                
        
                StartCoroutine(Dash());
                }
                
              }
           // }
          
        
        
        if(IconShow)
        {
            PlayerDashReadyIcon.SetActive(true);
            PlayerDashNotReadyIcon.SetActive(false);
        }

        if(!IconShow)
        {
            PlayerDashReadyIcon.SetActive(false);
            PlayerDashNotReadyIcon.SetActive(true);
        }

        

      
        if(DamageNegationActive == true)
        {
          foreach(GameObject enemy in Enemies)
          {
            enemy.GetComponent<EnemyController>().DamageToApply = CurrentDamageNegationAmount;
          }
        }

        if(dashCD < 0)
        {
            dashCD = 0;
            IconShow = true;
        }
        
        
     }

    void FixedUpdate()
    {
        
        

        Enemies = GameObject.FindGameObjectsWithTag("Enemy");


        if(IsInFrontCameraView)
        {
          horizontalInput = Input.GetAxis("Horizontal");
          verticalInput = Input.GetAxis("Vertical");
          
        }

        if(IsInRightCameraView)
        {
            horizontalInput = -Input.GetAxis("Vertical");
            verticalInput = Input.GetAxis("Horizontal");
        }

        if(IsInLeftCameraView)
        {
            horizontalInput = Input.GetAxis("Vertical");
            verticalInput = -Input.GetAxis("Horizontal");
        }

        if(IsInBackCameraView)
        {
          horizontalInput = -Input.GetAxis("Horizontal");
          verticalInput = -Input.GetAxis("Vertical");
        }
        
        
        WeaponAnimator = CurrentWeaponSlot.GetComponent<Animator>();
       

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

       
        ySpeed += Physics.gravity.y * Time.deltaTime;
        YSpeed = ySpeed;
        if (characterController.isGrounded)
        {
            IsGrounded = true;
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.4f;
            CanJump = true;

           
        }
        else
        {
            IsGrounded = false;
            characterController.stepOffset = 0;
            CanJump = false;
        }

        if(IsGrounded)
        {
             if (Input.GetAxis("Jump") > 0)
            {
                
                ySpeed = jumpSpeed;

            }
        }

        velocity = movementDirection * magnitude;

        
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            IsMoving = true;
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
          IsMoving = false;
        }

        //Dash and cooldown settings


        



        //if timer is going we have to wait for it to expire before we can use dash again
        
       //if timer is reset we can use dash
        

       


        //Potion Effects

       

        //Weapon Mechanics
      /*
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeaponSlot = Weapons[0];
            Weapons[0].transform.parent = CurrentSlot.transform;
            Weapons[1].transform.parent = WeaponsBank.transform;
            Weapons[2].transform.parent = WeaponsBank.transform;

            Weapons[0].SetActive(true);
            Weapons[1].SetActive(false);
            Weapons[2].SetActive(false);


        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeaponSlot = Weapons[1];
            Weapons[1].transform.parent = CurrentSlot.transform;
            Weapons[0].transform.parent = WeaponsBank.transform;
            Weapons[2].transform.parent = WeaponsBank.transform;

            Weapons[0].SetActive(false);
            Weapons[1].SetActive(true);
            Weapons[2].SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentWeaponSlot = Weapons[2];
            Weapons[2].transform.parent = CurrentSlot.transform;
            Weapons[1].transform.parent = WeaponsBank.transform;
            Weapons[0].transform.parent = WeaponsBank.transform;

            Weapons[0].SetActive(false);
            Weapons[1].SetActive(false);
            Weapons[2].SetActive(true);
        }
        */
        
    //Weapon Animations

        
        
     //Sword
       
      
        
        
    }
     public IEnumerator DamageNegation()
        {
           DamageNegationActive = true;
           
           yield return new WaitForSeconds(DNTime);
           DamageNegationActive = false;
           ResetDamageNegation();
        }

     public void StopDamageNegation()
     {
        StopCoroutine(DamageNegation());
     }

     public void ResetDamageNegation()
     {
        CurrentDamageNegationAmount = NormalDNAmount;
     }

     public void StartDamageNegation()
     {
        StartCoroutine(DamageNegation());
     }


    //Saving Data
     public void SavePlayerData()
     {
        playerData.CurrentHealth = PH.currentHealth;
        playerData.CurrentMana = PM.currentMana;
        playerData.CurrentPositionInLevel = CurrentPosition;
        
     }


     IEnumerator Dash()
        {
            IconShow = false;
            
            float startTime = Time.time;

        

            while(Time.time < startTime + dashTime)
            {
                
                
                characterController.Move(velocity * dashSpeed * Time.deltaTime);
                dashCD = maxDashCD;
                yield return null; 
            }

            
           
        }
     

    
   
}

/*
[Serializable]
public class CharacterData
{
    public int CurrentHealth;
    public int CurrentMana;
    public float positionX;
    public float positionY;
    public float positionZ;
    public string Name;

    
}

[Serializable]
public class SaveData
{
  public list<CharacterData> characters;
}
*/


