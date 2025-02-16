using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

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


    private void Awake()
    {
        //GameManager.Instance.GameUi = this;
    }

    void Start()
    {
        _currentPercentageString = "0 %";
        _levelManager=FindAnyObjectByType<LevelManager>();
    }


    public void OpenEndLevelPanel()
    {
        _currentPercentageText.gameObject.SetActive(false);

        int numFlowers = _levelManager.FlowerNum;

        _flowerNumText.text = numFlowers.ToString();


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
        _currentPercentageString = Mathf.RoundToInt(percentage).ToString()+" %";
        _currentPercentageText.text = _currentPercentageString;
    }

}
