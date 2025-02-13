using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlower : MonoBehaviour
{

    [SerializeField]
    private TimeManager timeManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timeManager.addPauseTime(2);
            gameObject.SetActive(false);
            
        }
        
        
    }

}
