using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyButterfly : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    private float _speed=15;

    private float _rotationSpeed=50;

    private float _changeDirectionUpperLimit;

    private float _changeDirectionLowerLimit;

    private float _changeDirectionAmount=3f;

    private float _direction = 1;


    void Start()
    {
        _changeDirectionLowerLimit = transform.position.y - _changeDirectionAmount;
        _changeDirectionUpperLimit = transform.position.y + _changeDirectionAmount;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {

       // Vector2 newPosition = new Vector2(transform.position.x-_speed*Time.fixedDeltaTime, transform.position.y);

        Vector2 leftDirection = transform.up;

        _rb.MovePosition(_rb.position+leftDirection*_speed*Time.fixedDeltaTime);

        Debug.Log(_rb.transform.rotation.eulerAngles.z);

        if (_rb.transform.rotation.eulerAngles.z>120)
        {
            _direction = -1;
        }else if(_rb.transform.rotation.eulerAngles.z<60)
        {
            _direction = 1;
        }


            float rotationAmount = _rotationSpeed * _direction * Time.fixedDeltaTime;


       


        _rb.MoveRotation(_rb.rotation + rotationAmount);
    }


    public void Activate(float speed,float rotationSpeed)
    {
        _speed = speed;
        _rotationSpeed = rotationSpeed;
    }
}
