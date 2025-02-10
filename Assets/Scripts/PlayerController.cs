using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour  
{
    public PlayerInputActions inputActions;

    [SerializeField]
    private Rigidbody2D _rb;

    

    private float _verticalAcceleration = 15f;

    private float _verticalDeceleration = 30f;


    private float maxSpeedY = 12f;

   
    private Vector2 _inputMovement;

   

    private void Awake()
    {
        _inputMovement = Vector2.zero;
        inputActions = new PlayerInputActions();
       



    }

    private void OnEnable()
    {
        inputActions.Player.Move.performed += DoMovement;
        inputActions.Player.Move.canceled += ResetMovement;
       
      
        inputActions.Player.Move.Enable();
       
        
    }

    private void OnDisable()
    {
        inputActions.Player.Move.Disable();
        
       
    }

    private void DoMovement(InputAction.CallbackContext context)
    {
        _inputMovement = context.ReadValue<Vector2>();

        Debug.Log("DoMovement: ");
        Debug.Log(_inputMovement);
    }

    private void ResetMovement(InputAction.CallbackContext context)
    {
        _inputMovement = Vector2.zero;

        Debug.Log("ResetMovement: ");
        Debug.Log(_inputMovement);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float tmpVelocityY = _rb.velocity.y;


        if (_inputMovement.y > 0)
        {

            if (tmpVelocityY >= 0)
            {
                tmpVelocityY += _verticalAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                tmpVelocityY += _verticalDeceleration * Time.fixedDeltaTime;
            }
           
        }else if (_inputMovement.y<0)
        {

            if (tmpVelocityY <= 0)
            {
                tmpVelocityY -= _verticalAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                tmpVelocityY -= _verticalDeceleration * Time.fixedDeltaTime;
            }
            
        }else 
        {

            if (tmpVelocityY > 0)
            {
                tmpVelocityY -= _verticalAcceleration * Time.fixedDeltaTime;

                if (tmpVelocityY < 0)
                {
                    tmpVelocityY = 0;
                }

            }else if (tmpVelocityY <0)
            {
                tmpVelocityY += _verticalAcceleration * Time.fixedDeltaTime;

                if (tmpVelocityY > 0)
                {
                    tmpVelocityY = 0;
                }
            }


        }



        if (tmpVelocityY > maxSpeedY)
        {
            tmpVelocityY = maxSpeedY;
        }else if (tmpVelocityY < -maxSpeedY)
        {
            tmpVelocityY= -maxSpeedY;
        }

        _rb.velocity = new Vector2(0, tmpVelocityY);
       

    }


   

}
