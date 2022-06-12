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
    bool jumping = false;
    bool falling = false;

    float fallDuration = 0f;



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

        if (y < 0 )
        {
            falling = true;
        }



        // Landung
        if (y == 0 && falling)
        {
            if (fallDuration > fallTolerance)
            {
                playerHealth -= (fallDuration - fallTolerance);
            }

            fallDuration = 0;
            falling = false;

        }


        BarFiller();
        healthText.text = "Health: " + Math.Floor(playerHealth);

    }

    private void FixedUpdate()
    {
        if ( falling )
        {
            fallDuration += 1;
        }
    }


    void BarFiller()
    {
        healthBar.fillAmount = playerHealth / maxPlayerHealth;
    }
}
