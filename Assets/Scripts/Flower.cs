using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    


    private LevelManager _levelManager;


    private void Start()
    {
        _levelManager = GameManager.Instance.LevelManager;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            _levelManager.AddFlower();
            gameObject.SetActive(false);
        }
    }

}
