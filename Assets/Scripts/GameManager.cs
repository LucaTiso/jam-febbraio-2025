using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private LevelManager _levelManager;

    private GameUi _gameUi;

    private PlayerController _playerController;

    private SaveManager _saveManager;

    private Vector2 _currentCheckPoint;

    private bool _practiceMode;

   
    private void Awake()
    {


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _saveManager = new SaveManager(Application.persistentDataPath);

            _saveManager.DoLoad();

            _practiceMode = false;

        }
        else
        {
            Destroy(gameObject);
        }



    }

    public LevelManager LevelManager
    {
        get => _levelManager;
        set => _levelManager = value;
    }

    public GameUi GameUi
    {
        get => _gameUi;
        set => _gameUi = value;
    }

    public PlayerController PlayerController
    {
        get => _playerController;
        set => _playerController = value;
    }
    public SaveManager SaveManager { get { return _saveManager; } }



    public Vector2 CurrentCheckpoint { get { return _currentCheckPoint; } set { _currentCheckPoint = value; } }

    public bool PracticeMode { get { return _practiceMode; } set { _practiceMode = value; } }
}
