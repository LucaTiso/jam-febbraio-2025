using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlower : MonoBehaviour
{

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameManager.Instance.LevelManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelManager.addPauseTime(2);
            gameObject.SetActive(false);
            
        }
        
        
    }

}
