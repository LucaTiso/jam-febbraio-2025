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
    private TimeManager _timeManager;

    private bool _updateTime;

    [SerializeField]
    private GameObject _endLevelPanel;

    void Start()
    {
        _updateTime = true;
    }


    public void OpenEndLevelPanel()
    {
        _updateTime = false;
        currentTimeText.gameObject.SetActive(false);

        currentTimeEndLevelText.text= _timeManager.CurrentTime.ToString("0.00", CultureInfo.InvariantCulture);

        _endLevelPanel.SetActive(true);

    }

    void Update()
    {
        if (_updateTime)
        {
            currentTimeText.text = _timeManager.CurrentTime.ToString("0.00", CultureInfo.InvariantCulture);
        }

    }
}
