using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyGroup : MonoBehaviour
{
    [SerializeField]
    private List<EnemyButterfly> enemyButterflyList;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            foreach(EnemyButterfly butterfly in enemyButterflyList)
            {
              

                StartCoroutine(ActivateButterfly(butterfly,collision.gameObject));
            }

        }
    }

    IEnumerator ActivateButterfly(EnemyButterfly butterfly,GameObject player)
    {
        yield return new WaitForSeconds(butterfly.Delay);
        butterfly.Activate( player);

    }
}
