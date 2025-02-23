using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{

    private List<LevelData> _levelData;

    public List<LevelData> LevelData
    {
        get => _levelData; set => _levelData = value;
    }
   
}
