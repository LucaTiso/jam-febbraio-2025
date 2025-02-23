using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButterflyCircleGroup : MonoBehaviour
{

    [SerializeField]
    private List<Rigidbody2D> _enemyButterflyRbList;

    [SerializeField]
    private Rigidbody2D _rb;

    private float _rotationSpeed=100;

    private float _distanceFromCentre=9f;

    private GameObject _player;


    
    void FixedUpdate()
    {
        _rb.MoveRotation(_rb.rotation+ _rotationSpeed*Time.fixedDeltaTime);

        if (_player.transform.position.x - transform.position.x > 15f)
        {
            gameObject.SetActive(false);
        }
    }

    
    public void Activate(GameObject player)
    {
        _player = player;

        Rigidbody2D butterfly1 = _enemyButterflyRbList[0];
        butterfly1.transform.position = new Vector2(transform.position.x + _distanceFromCentre, transform.position.y);

        butterfly1.MoveRotation(butterfly1.rotation + 0);


        Rigidbody2D butterfly2 = _enemyButterflyRbList[1];
        butterfly2.transform.position = new Vector2(transform.position.x - _distanceFromCentre, transform.position.y);

        butterfly2.MoveRotation(butterfly1.rotation + 180f);

        Rigidbody2D butterfly3 = _enemyButterflyRbList[2];
        butterfly3.transform.position = new Vector2(transform.position.x, transform.position.y + _distanceFromCentre);

        butterfly3.MoveRotation(butterfly1.rotation + 90f);

        Rigidbody2D butterfly4 = _enemyButterflyRbList[3];
        butterfly4.transform.position = new Vector2(transform.position.x, transform.position.y - _distanceFromCentre);

        butterfly4.MoveRotation(butterfly1.rotation + 270f);
    }

}
