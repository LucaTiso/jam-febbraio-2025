using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float xOffset;


   

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x+xOffset, transform.position.y, transform.position.z);
    }
}
