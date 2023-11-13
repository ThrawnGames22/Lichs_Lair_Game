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
    public bool CanUseWeapons;
    public Rigidbody RB;

    public bool HasActivatedGameplay;
    public bool HasActivatedWeapons;

    public bool HasActivatedMagic;

    public bool HasAquiredWeapons;

    public CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    public bool IsInFrontCameraView;
    public bool IsInBackCameraView;
    public bool IsInLeftCameraView;
    public bool IsInRightCameraView;

    public float horizontalInput;
    public float verticalInput;

    public bool isStaticInPlace;

    [Header ("Player Dash")]
    //cooldown
    public float dashSpeed;
    public float TeleportSpeed;

    public float dashTime;

    public float TeleportTime;

    public float dashCD;
    public float maxDashCD;

    public float TeleportCD;
    public float maxTeleportCD;
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

    public Vector3 ScreenPosition;

    [Header("Mouse Aim")]

    public float CameraLookSpeed = 5f;

    public bool IsLocked;

    [Header("Events")]
    public bool HasUnlockedWeaponChest;

    [Header("Mage Type")]
    public bool IsShadowWizard;
    public bool IsFireMage;
    public bool IsPaladin;

    public CombatSoundManager combatSoundManager;

    [Header("Animation")]
    public Animator PlayerAnimator;

   

    
    

    private void Awake()
    {
        Instance = this;
        characterController = GetComponent<CharacterController>();
        characterController.enabled = true;
        HasActivatedGameplay = true;
        RB = this.GetComponent<Rigidbody>();
        //mainCamera = Camera.main;
    }

    

   

    void Start()
    {

        // Set values
        dashCD = maxDashCD;
        IconShow = true;
        
        originalStepOffset = characterController.stepOffset;
        
        IsInFrontCameraView = true;
        

        // Sets weapons as starting weapon based on Mage Class

        if(MageClassData.Class == "Fire")
        {
         CurrentWeaponSlot = Weapons[0];
         //Weapons[0].transform.parent = CurrentSlot.transform;
         Weapons[0].SetActive(true);
         //Weapons[1].SetActive(false);
         //Weapons[2].SetActive(false);
        }
        if(MageClassData.Class == "Shadow")
        {
         CurrentWeaponSlot = Weapons[1];   
         //Weapons[2].transform.parent = CurrentSlot.transform;
         Weapons[0].SetActive(false);
         Weapons[1].SetActive(true);
         Weapons[2].SetActive(false);
        }
        if(MageClassData.Class == "Sun")
        {
         CurrentWeaponSlot = Weapons[2]; 
         //Weapons[1].transform.parent = CurrentSlot.transform;
         Weapons[0].SetActive(false);
         Weapons[1].SetActive(false);
         Weapons[2].SetActive(true);
        }
         
        
    }

    void Update()
     {

        if(speed == 0)
        {
            isStaticInPlace = true;
        }
        else
        {
            isStaticInPlace = false;
        }
        
        //MouseLook Values
      

        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);


        Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.green);
        
        ScreenPosition = Input.mousePosition;
        ScreenPosition.z = Camera.main.nearClipPlane + 1;

        
        /*
        Ray cameraRay = MainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
           Vector3 pointToLook = cameraRay.GetPoint(rayLength);
           Debug.DrawLine(cameraRay.origin, pointToLook, Color.red); 

           transform.LookAt(new Vector3(pointToLook.x, transform.rotation.y, pointToLook.z));
        }
        */



        
//____TUTORIAL LEVEL BASED CODE____

    // If the gameplay has been activated, activate these core attributes
    if(HasActivatedGameplay)
    {

        
      if(HasAquiredWeapons == true)
      {
        if(CanUseWeapons == true)
        {
        /*if(Input.GetKeyDown(KeyCode.Alpha1))
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
        }
      }


// TESTING WITH SAVE SYSTEM (CURRENTLY NOT FUNCTIONAL)
        WeaponSaveSlot = CurrentWeaponSlot;
        CurrentPosition = this.transform.position;
        if(Input.GetKeyDown(KeyCode.U))
        {
            SavePlayerData();
        }

// DASH  

    // Set Values
        dashCD -= Time.deltaTime;
        TeleportCD -= Time.deltaTime;

            
            //if(characterController.isGrounded)
           // {

            // If Player is moving and left shift key is pressed
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

        

// POTION EFFECT

    // If Damage negation Potion is active
        if(DamageNegationActive == true)
        {
          foreach(GameObject enemy in Enemies)
          {
            enemy.GetComponent<EnemyController>().DamageToApply = CurrentDamageNegationAmount;
          }
        }
// DASH CONTINUED

    //If dash cooldown is less than 0, keep it at 0
        if(dashCD < 0)
        {
            dashCD = 0;
            IconShow = true;
        }

        if(TeleportCD < 0)
        {
            TeleportCD = 0;
            //IconShow = true;
        }
        
    }
     }
     
//FIXED UPDATE 
    void FixedUpdate()
    {
        if(IsLocked == false)
        {
        Aim();
        }
        //Find Enemies 
        if(Enemies.Length != null)
        {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }

    //In certain Camera views, change the axis to make movement easier and consistant 
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
        
        // Get Animator component for Weapon
        WeaponAnimator = CurrentWeaponSlot.GetComponent<Animator>();
       
//PLAYER MOVEMENT
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        PlayerAnimator.SetFloat("Y", verticalInput);
        PlayerAnimator.SetFloat("X", horizontalInput);

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
            //Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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
      
        
        
    //Weapon Animations

        
        
     //Sword
       
      
        
        
    }
//MOUSE AIMING 
    private void Aim()
    {
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if(playerplane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            Quaternion targetrotation = Quaternion.LookRotation(targetpoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, CameraLookSpeed * Time.deltaTime);
        }
    }

//DAMAGE NEGATION    
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

//DASH COROUTINE 
      public IEnumerator Dash()
        {
            IconShow = false;
            
            float startTime = Time.time;

        

            while(Time.time < startTime + dashTime)
            {
                
                //RB.constraints = RigidbodyConstraints.FreezeRotationY;
                characterController.Move(velocity * dashSpeed * Time.deltaTime);
                dashCD = maxDashCD;
                yield return null; 
            }

            
           
        }
     
     public IEnumerator Teleport()
     {
        float startTime = Time.time;

        

            while(Time.time < startTime + TeleportTime)
            {
                
                //RB.constraints = RigidbodyConstraints.FreezeRotationY;
                characterController.Move(velocity * TeleportSpeed * Time.deltaTime);
                TeleportCD = maxTeleportCD;
                yield return null; 
            }

     }

     public void TurnOnCombatMusicManager()
     {
       combatSoundManager.gameObject.SetActive(true);
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


