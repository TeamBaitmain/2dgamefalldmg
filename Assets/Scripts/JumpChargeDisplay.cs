using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class JumpChargeDisplay : MonoBehaviour
{

    public TMP_Text jumpChargeText;
    public Image jumpChargeBar;

    public PlayerMovement playerMovement;

    float jumpCharge = 0f;
    float maxJumpCharge = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpChargeText.text = "Charge: " + Math.Floor(jumpCharge * 50) + "%";


        jumpCharge = playerMovement.jumpCharge;

        BarFiller();

    }

    void BarFiller()
    {
        jumpChargeBar.fillAmount = jumpCharge / maxJumpCharge;
    }


}
