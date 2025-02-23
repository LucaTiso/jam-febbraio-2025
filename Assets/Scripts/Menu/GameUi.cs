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



    private void Awake()
    {
        //GameManager.Instance.GameUi = this;
    }

    void Start()
    {
        _currentPercentageString = "0 %";
        _levelManager=FindAnyObjectByType<LevelManager>();
    }


    public void OpenEndLevelPanel(bool practiceMode)
    {
        _currentPercentageText.gameObject.SetActive(false);

        int numFlowers = _levelManager.FlowerNum;

        if (!practiceMode)
        {
            _flowerNumText.text = numFlowers.ToString();
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
        // unavailable in practice mode

        //_deathPercentage.text = "CURRENT : " + _currentPercentageString;

       // _bestPercentage.text = "BEST : " + bestPercentage + " %";

    }


}
