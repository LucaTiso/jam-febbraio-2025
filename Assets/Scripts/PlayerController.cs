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


    // for hard code

    private Vector2 currentMovement;

    private float speedAcceleration = 2f;

    private float turningSpeed = 2f;

    private float maxSpeed = 5f;

    private float speed = 0f;

   

    private void Awake()
    {
        _inputMovement = Vector2.zero;
        inputActions = new PlayerInputActions();
        currentMovement = new Vector2(1, 0);



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
        easyCode();
    }


    private void hardCode()
    {


        calculateSpeed();


        float tmpVelocityX = currentMovement.x;

        float tmpVelocityY = currentMovement.y;


        // solo a destra
        if (_inputMovement.x > 0 && _inputMovement.y==0)
        {

            if (currentMovement.y > 0 && currentMovement.x >= 0)
            {
                tmpVelocityY -= turningSpeed * Time.fixedDeltaTime;

                if (tmpVelocityY < 0)
                {
                    tmpVelocityY = 0;
                }

            }
            else if (currentMovement.y < 0 && currentMovement.x >= 0)
            {
                tmpVelocityY += turningSpeed * Time.fixedDeltaTime;

                if (tmpVelocityY > 0)
                {
                    tmpVelocityY = 0;
                }
            }else if(currentMovement.y >= 0 && currentMovement.x < 0)
            {

                tmpVelocityY += turningSpeed * Time.fixedDeltaTime;

                if (tmpVelocityY > 1)
                {
                    tmpVelocityY = 1;
                }
            }else if(currentMovement.y < 0 && currentMovement.x < 0)
            {
                tmpVelocityY -= turningSpeed * Time.fixedDeltaTime;
                if (tmpVelocityY < -1)
                {
                    tmpVelocityY = -1;
                }
            }


            tmpVelocityX += turningSpeed * Time.fixedDeltaTime;

            if (tmpVelocityX > 1)
            {
                tmpVelocityX = 1;
                tmpVelocityY = 0;
            }

            

        }






        currentMovement = new Vector2(tmpVelocityX, tmpVelocityY);

        _rb.velocity = toVelocityVector2(currentMovement.x, currentMovement.y);


    }




    private Vector2 toVelocityVector2(float x,float y)
    {


        float magnitude = Mathf.Sqrt(x * x + y * y);

        if (magnitude > 0)
        {
            x = (x / magnitude) * speed;
            y = (y / magnitude) * speed;
        }

        return new Vector2(x, y);
    }


    private void calculateSpeed()
    {
        if(_inputMovement.x!=0 || _inputMovement.y != 0)
        {
            speed += speedAcceleration += Time.fixedDeltaTime;


            if (speed > maxSpeed)
            {
                maxSpeed = speed;
            }

        }
        else
        {
            speed -= speedAcceleration += Time.fixedDeltaTime;

            if(speed<0)
            {
                speed = 0;
            }
        }


    }



   private void easyCode()
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

        }
        else if (_inputMovement.y < 0)
        {

            if (tmpVelocityY <= 0)
            {
                tmpVelocityY -= _verticalAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                tmpVelocityY -= _verticalDeceleration * Time.fixedDeltaTime;
            }

        }
        else
        {

            if (tmpVelocityY > 0)
            {
                tmpVelocityY -= _verticalAcceleration * Time.fixedDeltaTime;

                if (tmpVelocityY < 0)
                {
                    tmpVelocityY = 0;
                }

            }
            else if (tmpVelocityY < 0)
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
        }
        else if (tmpVelocityY < -maxSpeedY)
        {
            tmpVelocityY = -maxSpeedY;
        }

        _rb.velocity = new Vector2(0, tmpVelocityY);
    }


}
