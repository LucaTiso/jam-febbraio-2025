using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private LevelManager _levelManager;

    private GameUi _gameUi;

    private PlayerController _playerController;

    private void Awake()
    {


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

           // _saveManager = new SaveManager(Application.persistentDataPath);

           // _saveManager.DoLoad();

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
}
