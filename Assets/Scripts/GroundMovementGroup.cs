using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovementGroup : MonoBehaviour
{

    [SerializeField]
    List<BlockMovement> blockMovementList;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (BlockMovement block in blockMovementList)
            {
                block.Activate(collision.gameObject);

                StartCoroutine(StartMovement(block));
            }

        }
    }

    IEnumerator StartMovement(BlockMovement block)
    {
        yield return new WaitForSeconds(block.ActivationDelay);
        block.StartMovement();

    }



}
