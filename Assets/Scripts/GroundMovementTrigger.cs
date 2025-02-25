using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovementTrigger : MonoBehaviour
{
    [SerializeField]
    private List<GroundMovement> _groundMovementList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach(GroundMovement groundMovement in _groundMovementList)
            {
                groundMovement.StartMovement(collision.gameObject);
            }

          

        }
    }

}
