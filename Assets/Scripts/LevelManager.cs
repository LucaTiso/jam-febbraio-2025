using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private float _currentTime;

    private bool stopped = false;

    private float pauseTime;

    private GameUi _gameUi;


    private void Awake()
    {
        GameManager.Instance.LevelManager = this;
    }

    void Start()
    {
        _currentTime = 0;
        _gameUi = GameManager.Instance.GameUi;
    }

    void Update()
    {
        if (pauseTime > 0)
        {
            pauseTime -= Time.deltaTime;
        }
        else
        {
            if (!stopped)
            {
                _currentTime += Time.deltaTime;
                _gameUi.UpdateTimeText(_currentTime);
            }

        }


    }
    public void LevelEnded()
    {
        stopped = true;
        _gameUi.UpdateTimeText(_currentTime);
        _gameUi.OpenEndLevelPanel();
    }

    public void addPauseTime(float toAdd)
    {
        pauseTime += toAdd;
    }


    public float CurrentTime { get => _currentTime; }
}
