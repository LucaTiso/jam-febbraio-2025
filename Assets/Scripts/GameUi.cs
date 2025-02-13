using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentTimeText;

    [SerializeField]
    private TextMeshProUGUI currentTimeEndLevelText;

    [SerializeField]
    private GameObject _endLevelPanel;

    private string currentTimeString;


    private void Awake()
    {
        GameManager.Instance.GameUi = this;
    }

    void Start()
    {
        currentTimeString = "0.00";
    }


    public void OpenEndLevelPanel()
    {
        currentTimeText.gameObject.SetActive(false);

        currentTimeEndLevelText.text = currentTimeString;

        _endLevelPanel.SetActive(true);

    }

    public void UpdateTimeText(float time)
    {
        currentTimeString = time.ToString("0.00", CultureInfo.InvariantCulture);
        currentTimeText.text = currentTimeString;
    }

}
