using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
 
    [SerializeField]
    private List<LevelButton> _levelButtonList;

    [SerializeField]
    private Button _normalModeButton;

    [SerializeField]
    private Button _practiceModeButton;

    
    void Start()
    {

        GameManager.Instance.PracticeMode = false;
        GameManager.Instance.CurrentCheckpoint = new Vector2(0,0);

        _normalModeButton.image.color = Color.green;
        _practiceModeButton.image.color = Color.white;

        for (int i=0;i< _levelButtonList.Count;i++)
        {
            _levelButtonList[i].Setup(i);
        }
    }

    public void ActicateNormalMode()
    {
        GameManager.Instance.PracticeMode = false;
        _normalModeButton.image.color = Color.green;
        _practiceModeButton.image.color = Color.white;
    }

    public void ActicatePracticeMode()
    {
        GameManager.Instance.PracticeMode = true;
        _normalModeButton.image.color = Color.white;
        _practiceModeButton.image.color = Color.green;
    }

    public void OnCLickQuit()
    {
        Application.Quit();
    }
 
}
