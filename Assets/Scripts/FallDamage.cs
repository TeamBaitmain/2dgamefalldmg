using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class FallDamage : MonoBehaviour
{

    public TMP_Text healthText;
    public Image healthBar;
    
    public Rigidbody2D m_Rigidbody2D;

    float x, y;
    //bool jumping = false;
    bool falling = false;

    //float fallDuration = 0f;
    float jumpCeiling = 0f;
    bool jumpCeilingSet = false; 
    public float fallDamageMultiplier = 1;


    public float maxPlayerHealth = 100f;
    private float playerHealth;
    public float fallTolerance = 5f;

    private void Awake()
    {
        //m_Rigidbody2D = GetComponent<Rigidbody2D>();
        playerHealth = maxPlayerHealth;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = m_Rigidbody2D.velocity.x;
        y = m_Rigidbody2D.velocity.y;

        //required to ensure the jumpCeiling is only set once when reaching the peak of the jump
        if (y < 0 && jumpCeilingSet == false)
        {
            falling = true;
            jumpCeilingSet = true;
            jumpCeiling = (float)transform.position.y;
        }

        // Landing
        if (y == 0 && falling)
        {
            /*if (fallDuration > fallTolerance)
            {
                //playerHealth -= (fallDuration - fallTolerance);
                
            }*/
            float fallHeight = jumpCeiling-(float)transform.position.y;
            if (fallHeight > fallTolerance){
                playerHealth -= fallHeight*fallDamageMultiplier;
            }
            Debug.Log(fallHeight);
            //fallDuration = 0;
            falling = false;
            jumpCeilingSet = false;
        }


        BarFiller();
        healthText.text = "Health: " + Math.Floor(playerHealth);

    }

    private void FixedUpdate()
    {
        /*if ( falling )
        {
            fallDuration += 1;
        }*/
    }


    void BarFiller()
    {
        healthBar.fillAmount = playerHealth / maxPlayerHealth;
    }
}
