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

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    void Update()
    {
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
    }
}

