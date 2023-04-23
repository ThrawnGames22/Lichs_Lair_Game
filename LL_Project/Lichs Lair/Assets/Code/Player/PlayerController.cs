using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ClassData MageClassData;
    [Header ("Player Vairiables")]
    public static PlayerController Instance;
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    [Header ("Player Dash")]
    //cooldown
    public float dashSpeed;
    public float dashTime;
    public float dashCoolDown = 1;
    public float dashCoolDownTimer;
    //determines if we can use dash
    public bool canUseDash;
    public bool IsMoving;
    public bool CanJump;

    [Header ("Player Combat")]
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

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        


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

    void FixedUpdate()
    {

        
        WeaponAnimator = CurrentWeaponSlot.GetComponent<Animator>();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

       
        ySpeed += Physics.gravity.y * Time.fixedDeltaTime;
        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            CanJump = true;

           
        }
        else
        {
            characterController.stepOffset = 0;
            CanJump = false;
        }

        if(CanJump)
        {
             if (Input.GetButtonDown("Jump"))
            {
                
                ySpeed = jumpSpeed;

            }
        }

        Vector3 velocity = movementDirection * magnitude;
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


        if(canUseDash && IsMoving)
        {
            //if(characterController.isGrounded)
           // {
              if(Input.GetKeyDown(KeyCode.LeftShift))
              {
        
                StartCoroutine(Dash());
              }
           // }
          
        }
        else
        {
          StopCoroutine(Dash());
        }
        

        IEnumerator Dash()
        {
            float startTime = Time.time;

        

            while(Time.time < startTime + dashTime)
            {
                characterController.Move(velocity * dashSpeed * Time.deltaTime);
                yield return null; 
            }
           
        }



        //if timer is going we have to wait for it to expire before we can use dash again
        if(dashCoolDownTimer > 0)
        {
            dashCoolDownTimer -= Time.deltaTime;
            canUseDash = false;
        }

        if(dashCoolDownTimer < 0)
        {
            dashCoolDownTimer = 0;
        }
       //if timer is reset we can use dash
        if(dashCoolDownTimer == 0)
        {
            canUseDash = true;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && dashCoolDownTimer == 0)
        {
            Debug.Log("Dashed!");
            dashCoolDownTimer = dashCoolDown;
        }

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

    
   
}

