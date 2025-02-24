using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GroundMovement : MonoBehaviour
{


    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _direction;

    [SerializeField]
    private Rigidbody2D _rb;

    private bool _move= false;

    private GameObject _player;

    [SerializeField]
    private float _activationDelay;

    [SerializeField]
    private float _deceleration;

    void Start()
    {
        
    }

    void FixedUpdate()
    {

        if(_speed > 0 && _move)
        {
            float currentMovement = _speed * Time.fixedDeltaTime;

            
            Vector2 direction = transform.up;

            _rb.MovePosition(_rb.position + direction * currentMovement);

            _speed -= _deceleration * Time.fixedDeltaTime;
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
