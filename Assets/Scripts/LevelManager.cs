using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private float _currentPercentage;

    private bool stopped = false;

    private GameUi _gameUi;

    [SerializeField]
    private Transform endObj;

    private PlayerController _playerController;

    private float totalLength;

    private float startingPoint;

    private int _flowerNum = 0;

    private int _levelNum;

   
    private void Awake()
    {
        GameManager.Instance.LevelManager = this;
    }

    void Start()
    {
        _currentPercentage = 0;
        _gameUi = GameManager.Instance.GameUi;

        _playerController = GameManager.Instance.PlayerController;


        totalLength = endObj.position.x - _playerController.transform.position.x;
        startingPoint = _playerController.transform.position.x;

        _levelNum = int.Parse(SceneManager.GetActiveScene().name.Replace("Level", ""));



    }

    void Update()
    {
      
            if (!stopped)
            {
            float currentDistance = _playerController.transform.position.x - startingPoint;

            _currentPercentage = (currentDistance / totalLength) *100;

            if (!GameManager.Instance.PracticeMode)
            {
                _gameUi.UpdatePercentageText(_currentPercentage);
            }

              
            }

        


    }

    public void AddFlower()
    {
        _flowerNum++;
    }

    public void LevelEnded()
    {

        if (!GameManager.Instance.PracticeMode)
        {
            stopped = true;
            _gameUi.UpdatePercentageText(100);


            GameData gameData = GameManager.Instance.SaveManager.GameData;

            LevelData levelData = gameData.LevelData[_levelNum - 1];

            if (levelData == null)
            {
                levelData = new LevelData();
            }

            levelData.BestPercentage = 100;

            if (levelData.NumFlowers<_flowerNum)
            {
                levelData.NumFlowers = _flowerNum;
            }


            gameData.LevelData[_levelNum - 1] = levelData;

            GameManager.Instance.SaveManager.DoSave(gameData);

            _gameUi.OpenEndLevelPanel(false);
        }
        else
        {
            _gameUi.OpenEndLevelPanel(true);
        }

        GameManager.Instance.CurrentCheckpoint = new Vector2(0, 0);


    }

    public void HandleDeath()
    {

        if(!GameManager.Instance.PracticeMode)
        {

            stopped = true;

            bool toSave = false;

            GameData gameData = GameManager.Instance.SaveManager.GameData;

            Debug.Log("Level index : " + (_levelNum - 1));

            LevelData levelData = gameData.LevelData[_levelNum - 1];



            if (levelData == null)
            {
                toSave = true;
                levelData = new LevelData();
                levelData.BestPercentage = 0;
                levelData.NumFlowers = 0;

            }

            if (levelData.BestPercentage < (int)_currentPercentage)
            {
                toSave = true;
                levelData.BestPercentage = (int)_currentPercentage;

            }

            if (toSave)
            {
                gameData.LevelData[_levelNum - 1] = levelData;

                GameManager.Instance.SaveManager.DoSave(gameData);
            }


            _gameUi.UpdatePercentageText(_currentPercentage);
            _gameUi.OpenDeathPanel(levelData.BestPercentage);

        }
        else
        {
            _gameUi.OpenDeathPanel();
        }

        
    }

    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void ToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }


    public int  FlowerNum
    {
        get => _flowerNum;
    }
}
