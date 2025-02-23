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

    

    public void OnClickPlay()
    {
        Debug.Log("cliccato play for Level: "+ _level);

       
        SceneManager.LoadScene(_level);
    }

    
    public void Setup(int levelNum)
    {
        _level = "Level" + (levelNum + 1);
        _levelText.text = _level;
    }

    public string Level
    { 
        get { return _level; }
        set { _level = value; }
    }
}
