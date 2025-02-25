using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{

    private string _level;

    [SerializeField]
    private TextMeshProUGUI _levelText;

    [SerializeField]
    private TextMeshProUGUI _bestScore;

    [SerializeField]
    private TextMeshProUGUI _flowers;



    public void OnClickPlay()
    {

        SceneManager.LoadScene(_level);
    }

    
    public void Setup(int levelNum)
    {
        LevelData levelData = GameManager.Instance.SaveManager.GameData.LevelData[levelNum];

        _level = "Level" + (levelNum + 1);
        _levelText.text = _level;
        if (levelData == null)
        {
            _bestScore.text = "Best : 0 %";
            _flowers.text = "Flowers : 0";
        }
        else
        {
            _bestScore.text = "Best : "+levelData.BestPercentage+" %";
            _flowers.text = "Flowers : "+levelData.NumFlowers;
        }

       
    }

    public string Level
    { 
        get { return _level; }
        set { _level = value; }
    }
}
