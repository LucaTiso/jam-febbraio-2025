using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField]
    private Transform _targetTransform;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("entrato player");
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, _targetTransform.position.y, 0);
        }
    }
}
