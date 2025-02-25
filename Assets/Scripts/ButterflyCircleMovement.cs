using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyCircleMovement : MonoBehaviour
{



    [SerializeField]
    private Rigidbody2D _rb;


    public void Activate(float posX, float posY,float rotation) 
    {
        gameObject.SetActive(true);
       


        _rb.transform.position = new Vector2(posX, posY);
        _rb.MoveRotation(_rb.rotation + rotation);


    } 
}
