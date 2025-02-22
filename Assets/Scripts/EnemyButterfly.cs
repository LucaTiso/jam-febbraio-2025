using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyButterfly : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _changeDirectionAngle;

    [SerializeField]
    private int _direction;

    [SerializeField]
    private float _posX;

    [SerializeField]
    private float _posY;

    [SerializeField]
    private float _delay;

   
    private float _maxAngle;

    
    private float _minAngle;


    private GameObject _player;

    void Start()
    {
       
    }
    

    void FixedUpdate()
    {

        Vector2 leftDirection = transform.up;

        _rb.MovePosition(_rb.position+leftDirection*_speed*Time.fixedDeltaTime);

        if (_rb.transform.rotation.eulerAngles.z> _maxAngle)
        {
            _direction = -1;
        }else if(_rb.transform.rotation.eulerAngles.z<_minAngle)
        {
            _direction = 1;
        }

        float rotationAmount = _rotationSpeed * _direction * Time.fixedDeltaTime;

        _rb.MoveRotation(_rb.rotation + rotationAmount);


        InactivationCheck();
    }


    public void Activate(GameObject player)
    {
        gameObject.SetActive(true);
       
        _rb.transform.position=new Vector2(_posX, _posY);

        _minAngle = _rb.transform.rotation.eulerAngles.z - _changeDirectionAngle;
        _maxAngle = _rb.transform.rotation.eulerAngles.z + _changeDirectionAngle;

        _player = player;
    }


    private void InactivationCheck()
    {
        if( _player.transform.position.x - _rb.transform.position.x > 10f)
        {
            gameObject.SetActive(false);

            //todo put in pool

        }

    }


    public float Delay
    {
        get => _delay; set => _delay = value;
    }

    
}
