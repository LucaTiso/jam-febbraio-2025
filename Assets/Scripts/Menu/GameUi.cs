using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _currentPercentageText;

    [SerializeField]
    private TextMeshProUGUI _flowerNumText;

    [SerializeField]
    private GameObject _endLevelPanel;

    private string _currentPercentageString;

    private LevelManager _levelManager;

    [SerializeField]
    private GameObject _deathPanel;

    [SerializeField]
    private TextMeshProUGUI _bestPercentage;

    [SerializeField]
    private TextMeshProUGUI _deathPercentage;

    [SerializeField]
    private TextMeshProUGUI _endLevelTitle;



    private void Awake()
    {
        GameManager.Instance.GameUi = this;
    }

    void Start()
    {
        if (!GameManager.Instance.PracticeMode)
        {
            _currentPercentageString = "0 %";
        }
        else
        {
            _currentPercentageString = "PRACTICE MODE";
            _currentPercentageText.fontSize = 16;
            _currentPercentageText.transform.position = new Vector2(_currentPercentageText.transform.position.x+20, _currentPercentageText.transform.position.y);


        }

        _currentPercentageText.text = _currentPercentageString;
        _levelManager =GameManager.Instance.LevelManager;
    }


    public void OpenEndLevelPanel(bool practiceMode)
    {
        _currentPercentageText.gameObject.SetActive(false);

        if (!practiceMode)
        {
            int numFlowers = _levelManager.FlowerNum;
            _flowerNumText.text = "Flowers : "+numFlowers.ToString(); 
           
            _endLevelTitle.text = "LEVEL COMLETE!";
        }
        else
        {
            _endLevelTitle.text = "PRACTICE COMLETE!";
            _flowerNumText.gameObject.SetActive(false);
        }

        _endLevelPanel.SetActive(true);

    }


    public void ToMenu()
    {
        _levelManager.ToMainMenu();
    }

    public void Restart()
    {
        Debug.Log("restart");
        _levelManager.RestartLevel();
    }

    public void UpdatePercentageText(float percentage)
    {
        _currentPercentageString = ((int)percentage).ToString()+" %";
        _currentPercentageText.text = _currentPercentageString;
    }


    public void OpenDeathPanel(int bestPercentage)
    {
        _currentPercentageText.gameObject.SetActive(false);

        _deathPanel.SetActive(true);

        _deathPercentage.text  = "CURRENT : "+_currentPercentageString;

        _bestPercentage.text = "BEST : " + bestPercentage + " %";

    }

    public void OpenDeathPanel()
    {
        _currentPercentageText.gameObject.SetActive(false);

        _deathPanel.SetActive(true);
        

        _deathPercentage.gameObject.SetActive(false);
        _bestPercentage.gameObject.SetActive(false);

    }


}
