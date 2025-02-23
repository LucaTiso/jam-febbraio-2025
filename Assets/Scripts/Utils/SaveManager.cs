using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class SaveManager 
{
    private string _persistentPath;

    private GameData _gameData;

    private int _numLevels=2;

    public SaveManager(string path)
    {

        _persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public bool DoSave(GameData gameData)
    {

        try
        {
            if (File.Exists(_persistentPath))
            {
                Debug.Log("File exists. Deleting old one and writing new one");
                File.Delete(_persistentPath);
            }



            using FileStream stream = File.Create(_persistentPath);
            stream.Close();
            File.WriteAllText(_persistentPath, JsonConvert.SerializeObject(gameData));
            _gameData = gameData;
            return true;

        }
        catch (Exception e)
        {
            Debug.Log("unable to save data");
            Debug.Log(e);
            return false;
        }


    }

    public void DoLoad()
    {


        try
        {
            _gameData = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(_persistentPath));
            if (_gameData == null)
            {
                InitializeGameData();
            }


        }
        catch (Exception e)
        {
            Debug.Log("Error reading LevelData");
            Debug.Log(e);



            InitializeGameData();


        }


    }

    private void InitializeGameData()
    {
        _gameData = new GameData();
        _gameData.LevelData = new List<LevelData>();

        for(int i=0;i< _numLevels; i++)
        {
            LevelData levelData = new LevelData();
            levelData.NumFlowers = 0;
            levelData.BestPercentage = 0;
            _gameData.LevelData.Add(levelData);
        }
    }

    public GameData GameData
    {
        get => _gameData;

    }
}
