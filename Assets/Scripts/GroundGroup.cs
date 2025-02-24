using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGroup : MonoBehaviour
{
    [SerializeField]
    private List<GroundMovement> _groundMovementList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (GroundMovement block in _groundMovementList)
            {
                block.Activate(collision.gameObject);

                StartCoroutine(StartMovement(block));
            }

        }
    }

    IEnumerator StartMovement(GroundMovement block)
    {
        yield return new WaitForSeconds(block.ActivationDelay);
        block.StartMovement();

    }
}
