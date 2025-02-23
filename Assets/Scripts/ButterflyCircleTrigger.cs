using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyCircleTrigger : MonoBehaviour
{
    [SerializeField]
    private List<ButterflyCircleGroup> _circleGroupList;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            foreach(ButterflyCircleGroup g in _circleGroupList)
            {

                g.gameObject.SetActive(true);
                g.Activate(collision.gameObject);

            }

        }

    }
}
