using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float _deceleration;

    private float _deactivationOffset = 10f;


    void FixedUpdate()
    {

        if (_move)
        {
            if (_speed > 0)
            {
                float currentMovement = _speed * Time.fixedDeltaTime;


                Vector2 direction = transform.up;

                _rb.MovePosition(_rb.position + direction * currentMovement);

                _speed -= _deceleration * Time.fixedDeltaTime;
            }


            if (_player.transform.position.x - transform.position.x > _deactivationOffset)
            {
                gameObject.SetActive(false);
            }
        }
        



    }

    public void StartMovement(GameObject player)
    {
        _move = true;
        _player = player;
    }

  

    
}
