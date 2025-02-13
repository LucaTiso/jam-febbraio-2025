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

    
   // private GameUi _gameUi;

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


    private float speed;

    
   

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

        calculateSpeed();

        _rb.velocity = _rb.transform.up * speed;

        int rotationDirection = _inputMovement.x > 0 ? -1 : _inputMovement.x < 0 ? 1 : 0;

        float rotationAmount = turningSpeed * rotationDirection * Time.fixedDeltaTime;

        _rb.MoveRotation(_rb.rotation + rotationAmount);


        //Debug.Log(Mathf.RoundToInt(_rb.transform.eulerAngles.z));

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

}
