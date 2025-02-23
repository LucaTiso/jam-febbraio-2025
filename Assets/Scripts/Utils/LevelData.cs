using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData 
{
    
    private int _bestPercentage;

    private int _numFlowers;

    public int NumFlowers
    {
        get=>_numFlowers; set => _numFlowers = value;
    }

    public int BestPercentage
    {
        get=>_bestPercentage; set => _bestPercentage = value;
    }
}
