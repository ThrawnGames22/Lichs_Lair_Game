using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Player Vairiables")]

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

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        CurrentWeaponSlot = Weapons[0];
        Weapons[0].transform.parent = CurrentSlot.transform;
        Weapons[0].SetActive(true);
        Weapons[1].SetActive(false);
        Weapons[2].SetActive(false);
        
    }

    void Update()
    {
        WeaponAnimator = CurrentWeaponSlot.GetComponent<Animator>();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //Dash and cooldown settings


        if(canUseDash)
        {
          if(Input.GetKeyDown(KeyCode.LeftShift))
            {
        
              StartCoroutine(Dash());
            }
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
        
    //Weapon Animations

        
        
     //Sword
        WeaponAnimator.SetBool("Charging", ChargeAttacking);
        if(CurrentWeaponSlot.gameObject.tag == "Sword")
        {
        ChargedDamageValue = 15f;
        NormalDamageValue = 5f;
          if(Input.GetKey(KeyCode.X))
          {
            ChargeAttackTimer += Time.deltaTime;
            ChargeAttacking = true;
            CurrentWeaponSlot.GetComponent<SwordController>().CanApplyDamage = true;
          }

          if((Input.GetKeyUp(KeyCode.X)) && ChargeAttackTimer > 1)
          {
            ChargeAttackTimer = 0;
            ChargeAttacking = false;
            //CurrentWeaponSlot.GetComponent<SwordController>().CanApplyDamage = false;
            
          }

          if(Input.GetKeyUp(KeyCode.X))
          {
            ChargeAttacking = false;
            CurrentWeaponSlot.GetComponent<SwordController>().CanApplyDamage = false;
          }

          if((Input.GetKeyUp(KeyCode.X)) && ChargeAttackTimer < 1)
          {
            ChargeAttackTimer = 0;
            ChargeAttacking = false;
            
          }

          if(Input.GetKeyDown(KeyCode.E))
          {
            SwordAttack();
            
          }

          if(ChargeAttackTimer > 1)
          {
            AttackValue = ChargedDamageValue;
          }

          if(ChargeAttackTimer < 1)
          {
            AttackValue = NormalDamageValue;
          }
        }
        
        
    }

    public void ChargeSwordAttack()
    {
        ChargeAttacking = true;
        if(!ChargeAttacking)
        {
            return;
        }
        
        
        //AttackBlocked = true;
        //StartCoroutine(DelayAttack()); 
    }

    public void SwordAttack()
    {

        if(AttackBlocked)
        {
            return;
        }
        WeaponAnimator.SetTrigger("Attack");
        AttackBlocked = true;
        StartCoroutine(DelayAttack());
        
    }

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(MeleeWeaponDelay);
        AttackBlocked = false;
    }

   
}

