using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float speed;

    private float rotationSpeed;

    private int direction = 1;

    [SerializeField]
    private Rigidbody2D _rb;


    void Start()
    {
        speed = 10;
        rotationSpeed = 80;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = _rb.transform.up * speed;

        int rotationDirection =direction > 0 ? -1 : direction < 0 ? 1 : 0;

        float rotationAmount = rotationSpeed * rotationDirection * Time.fixedDeltaTime;

        _rb.MoveRotation(_rb.rotation + rotationAmount);
    }


}
