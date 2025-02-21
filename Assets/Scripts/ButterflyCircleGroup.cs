using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyCircleGroup : MonoBehaviour
{

    [SerializeField]
    private List<ButterflyCircleMovement> enemyButterflyList;

    [SerializeField]
    private Rigidbody2D _rb;

    private float _rotationSpeed=100;

    private float _distanceFromCentre=9f;


    void Start()
    {
        ButterflyCircleMovement butterfly1 = enemyButterflyList[0];

        butterfly1.Activate(transform.position.x + _distanceFromCentre, transform.position.y + 0, 0);


        ButterflyCircleMovement butterfly2 = enemyButterflyList[1];

        butterfly2.Activate(transform.position.x - _distanceFromCentre, transform.position.y + 0, 180f);

        ButterflyCircleMovement butterfly3 = enemyButterflyList[2];

        butterfly3.Activate(transform.position.x, transform.position.y + _distanceFromCentre, 90f);

        ButterflyCircleMovement butterfly4 = enemyButterflyList[3];

        butterfly4.Activate(transform.position.x , transform.position.y - _distanceFromCentre, 270f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.MoveRotation(_rb.rotation+ _rotationSpeed*Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            ButterflyCircleMovement butterfly1 = enemyButterflyList[0];

            butterfly1.Activate(transform.position.x+3f, transform.position.y+0, 0);


            ButterflyCircleMovement butterfly2 = enemyButterflyList[1];

            butterfly2.Activate(transform.position.x - 3f, transform.position.y+ 0,180f);

            

        }

    }

}
