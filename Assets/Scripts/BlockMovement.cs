using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    [SerializeField]
    private float _distance;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private Vector2 _direction;

    [SerializeField]
    private Rigidbody2D _rb;


    [SerializeField]
    private float _activationDelay;

    private GameObject _player;

    private bool _move=false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_distance > 0 && _move)
        {
            float currentMovement = _speed * Time.fixedDeltaTime;

            if (currentMovement >= _distance)
            {
                currentMovement = _distance;
                _distance = 0;
            }
            else
            {
                _distance -= currentMovement;
            }

          
            _rb.MovePosition(_rb.position + _direction * currentMovement);
        }

        if (_player.transform.position.x - transform.position.x > 10f)
        {
            gameObject.SetActive(false);
        }
    }

    public float ActivationDelay
    {
        get => _activationDelay;
        set => _activationDelay = value;
    }


    public void Activate(GameObject player)
    {
        _player = player;
        gameObject.SetActive(true);
    }


    public void StartMovement()
    {
        _move = true;
    }
}
