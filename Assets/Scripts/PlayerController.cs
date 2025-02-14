using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour  
{
    public PlayerInputActions inputActions;

   
    private LevelManager _levelManager;

    
   

    [SerializeField]
    private Rigidbody2D _rb;

   
    private Vector2 _inputMovement;


    [SerializeField]
    private float minimumSpeed = 3f;

    [SerializeField]
    private float turningSpeed = 100f;

    [SerializeField]
    private float maxBaseSpeed = 6f;

    [SerializeField]
    private float baseAcceleration = 2f;


    private float speed=5;

    private float _verticalAcceleration = 20f;

    private float _verticalDeceleration = 10f;

    private float _maxVerticalSpeed = 20f;
   

    private void Awake()
    {
        _inputMovement = Vector2.zero;
        inputActions = new PlayerInputActions();

        GameManager.Instance.PlayerController = this;
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

    }

    private void ResetMovement(InputAction.CallbackContext context)
    {
        _inputMovement = Vector2.zero;

    }

    void Start()
    {
        _levelManager = GameManager.Instance.LevelManager;
        speed = minimumSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float tmpVerticalSpeed = _rb.velocity.y;

        if (_inputMovement.y > 0)
        {
            tmpVerticalSpeed += _verticalAcceleration*Time.fixedDeltaTime;

            if (tmpVerticalSpeed > _maxVerticalSpeed)
            {
                tmpVerticalSpeed = _maxVerticalSpeed;


            }
        }else if(_inputMovement.y < 0)
        {
            tmpVerticalSpeed -= _verticalAcceleration * Time.fixedDeltaTime;

            if (tmpVerticalSpeed < -_maxVerticalSpeed)
            {
                tmpVerticalSpeed = -_maxVerticalSpeed;


            }
        }


        _rb.velocity = new Vector2(speed, tmpVerticalSpeed);

        RotateByVerticalSpeed(tmpVerticalSpeed, speed);

    }


    private void RotateByVerticalSpeed(float a,float b)
    {

        int direction = a >= 0 ? 1 : -1;


        float c=  Mathf.Sqrt(a*a+ b*b);
        float cosAlfa = b / c;
        float alfa = Mathf.Acos(cosAlfa);
        float angleDegrees = alfa * Mathf.Rad2Deg* direction-90f;

        Debug.Log(angleDegrees);

        _rb.transform.rotation = Quaternion.Euler(0, 0, angleDegrees);
    }


    private void calculateSpeed()
    {
        if (_inputMovement.y > 0)
        {
            speed += baseAcceleration * Time.fixedDeltaTime;

            if(speed > maxBaseSpeed)
            {
                speed = maxBaseSpeed;
            }
        }
        else
        {
            speed -= baseAcceleration * Time.fixedDeltaTime;


            if(speed < minimumSpeed)
            {
                speed = minimumSpeed;
            }

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        
        if (collision.gameObject.tag=="Ground" || collision.gameObject.tag=="Enemy")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }else if(collision.gameObject.tag == "End")
        {
            _levelManager.LevelEnded();

           
           gameObject
                .SetActive(false);

        }
    }

    private void Movement1()
    {
        calculateSpeed();

        _rb.velocity = _rb.transform.up * speed;

        int rotationDirection = _inputMovement.x > 0 ? -1 : _inputMovement.x < 0 ? 1 : 0;

        float rotationAmount = turningSpeed * rotationDirection * Time.fixedDeltaTime;

        _rb.MoveRotation(_rb.rotation + rotationAmount);

    }

}
