using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private void Start()
    {
        if (!GameManager.Instance.PracticeMode)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.CurrentCheckpoint = new Vector2(transform.position.x, transform.position.y);
        }
    }

}
