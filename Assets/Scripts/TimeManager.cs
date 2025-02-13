using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private float _currentTime;

    private bool stopped = false;

    private float pauseTime;
    void Start()
    {
        _currentTime = 0;
    }

    
    void Update()
    {
        if (pauseTime > 0)
        {
            pauseTime -= Time.deltaTime;
        }
        else
        {
            if(!stopped)
            {
                _currentTime += Time.deltaTime;
            }
            
        }

        
    }

    public void StopTime()
    {
        stopped = true;
    }

    public void addPauseTime(float toAdd)
    {
        pauseTime +=toAdd;
    }


    public float CurrentTime { get => _currentTime; }
}
