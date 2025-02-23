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
    private float speed=5;

    [SerializeField]
    private float _verticalAcceleration = 20f;

    private float _verticalDeceleration = 10f;

    private float _maxVerticalSpeed = 20f;

    private bool _alive;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    
   

    private void Awake()
    {
        _inputMovement = Vector2.zero;
        inputActions = new PlayerInputActions();
        _alive = true;

        //GameManager.Instance.PlayerController = this;
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
       // _levelManager = GameManager.Instance.LevelManager;
       _levelManager = FindAnyObjectByType<LevelManager>();

        if (GameManager.Instance.CurrentCheckpoint != null)
        {
            Vector2 currentCheckpoint = GameManager.Instance.CurrentCheckpoint;

            _rb.transform.position = new Vector2(currentCheckpoint.x, currentCheckpoint.y);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_alive)
        {

            float tmpVerticalSpeed = _rb.velocity.y;

            if (_inputMovement.y > 0)
            {
                tmpVerticalSpeed += _verticalAcceleration * Time.fixedDeltaTime;

                if (tmpVerticalSpeed > _maxVerticalSpeed)
                {
                    tmpVerticalSpeed = _maxVerticalSpeed;


                }
            }
            else if (_inputMovement.y < 0)
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

    }


    private void RotateByVerticalSpeed(float a,float b)
    {

        int direction = a >= 0 ? 1 : -1;


        float c=  Mathf.Sqrt(a*a+ b*b);
        float cosAlfa = b / c;
        float alfa = Mathf.Acos(cosAlfa);
        float angleDegrees = alfa * Mathf.Rad2Deg* direction-90f;

        _rb.transform.rotation = Quaternion.Euler(0, 0, angleDegrees);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        
        if (collision.gameObject.tag=="Ground" || collision.gameObject.tag=="Enemy")
        {
            _alive = false;
            _spriteRenderer.enabled = false;
            _rb.velocity=new Vector2(0,0);
            _levelManager.HandleDeath();

        }else if(collision.gameObject.tag == "End")
        {
            _levelManager.LevelEnded();

           
           gameObject
                .SetActive(false);

        }else if (collision.gameObject.tag == "Flower")
        {
            collision.gameObject.SetActive(false);
        }
    }


}
