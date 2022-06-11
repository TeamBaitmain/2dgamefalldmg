using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Slider jumpChargeSlider;


    float horizontalMove = 0f;
    public float runSpeed = 40f;
    
    bool jump = false;

    bool chargingJump = false;

    

    private float jumpForce = 0f;

    public float jumpChargeUnit = 0.1f;

    public float jumpCharge = 0f;  // Sprunghoehe, wird mit delta zw pressed und  released Jump aufgeladen, min und max einbauen!
    public float maxJumpCharge = 5f;
    public float minJumpCharge = 0.25f;
    //float jumpDir = 0f; // (Auskommentiert solange ungenutzt; sonst gibt das ein Warning) Bestimmt die Richtung des Sprunges, vllt ueber horizontal force regeln??


    public float horizontalJumpSpeed = 100f;





    // Start is called before the first frame update
    void Start()
    {
        jumpForce = controller.m_JumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if ( Input.GetButtonDown("Jump"))
        {
            chargingJump = true;

            // Stop the momentum of the player
            controller.Brake();
        }
        if (Input.GetButtonUp("Jump"))
        {
            jump = true;
            
            
        }

    }


    private void FixedUpdate()
    {
        if ( !chargingJump && !jump)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        }

        if (jump)
        {
            Debug.Log("JUMP!!!!!!");

            if ( jumpCharge > maxJumpCharge)
            {
                jumpCharge = maxJumpCharge;
            }
            if (jumpCharge < minJumpCharge)
            {
                jumpCharge = minJumpCharge;
            }
            controller.m_JumpForce = jumpForce * jumpCharge;

            //controller.Move(horizontalMove * Time.fixedDeltaTime * jumpCharge, false, true);
            controller.Move( Input.GetAxisRaw("Horizontal") * horizontalJumpSpeed * Time.fixedDeltaTime * jumpCharge, false, true);

            chargingJump = false;
            jumpCharge = 0f;
        }

        jump = false;

        if (chargingJump && jumpCharge < maxJumpCharge)
        {
            jumpCharge += jumpChargeUnit;


            
            //jumpChargeSlider.value = jumpCharge * 50;

        }
        
    }
}
