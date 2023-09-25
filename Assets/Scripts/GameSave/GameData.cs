using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Define the data you want to save here
    public string playerName;

    // Add more variables as needed

    // Constructor for GameData
    public GameData(string name)
    {
        playerName = name;
    }
}
