using System.Collections;
using System.Collections.Generic;
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


    private void Awake()
    {
       // GameManager.Instance.LevelManager = this;
    }

    void Start()
    {
        _currentPercentage = 0;
        _gameUi = FindAnyObjectByType<GameUi>();

        _playerController=FindObjectOfType<PlayerController>();


        totalLength = endObj.position.x - _playerController.transform.position.x;
        startingPoint = _playerController.transform.position.x;

    }

    void Update()
    {
      
            if (!stopped)
            {
            float currentDistance = _playerController.transform.position.x - startingPoint;

            _currentPercentage = (currentDistance / totalLength) *100;

               // _currentTime += Time.deltaTime;

               _gameUi.UpdatePercentageText(_currentPercentage);
            }

        


    }

    public void AddFlower()
    {
        _flowerNum++;
    }

    public void LevelEnded()
    {
        stopped = true;
        _gameUi.UpdatePercentageText(100);
        _gameUi.OpenEndLevelPanel();
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
