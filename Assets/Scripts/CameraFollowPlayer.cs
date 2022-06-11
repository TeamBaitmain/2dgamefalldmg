using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float YOffset = 1.5f; //Hier nur default-Wert, kann direkt in Unity angepasst werden
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,YOffset,-5);
    }
}
