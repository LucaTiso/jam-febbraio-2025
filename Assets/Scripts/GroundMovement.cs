using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{

    [SerializeField]
    private float _distance;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _direction;

    [SerializeField]
    private Rigidbody2D _rb;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(_distance > 0)
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

            Vector2 direction = transform.up;

            _rb.MovePosition(_rb.position + direction * currentMovement);
        }

       

    }
}
