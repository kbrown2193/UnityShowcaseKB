using UnityEngine;
using UnityEditor;
using System.IO;
using TMPro;

public class GameSaveFileTool : MonoBehaviour
{
    private GameData gameData;

    [MenuItem("Custom Tools/Create Game Save File")]
    private static void CreateGameSaveFile()
    {
        // Create a new instance of GameData with the specified input fields
        GameData gameData = new GameData("NewSave"); // "NewSave" is the default save file name

        // Open the Save File dialog for setting values
        EditorWindow.CreateInstance<GameSaveFileWindow>().ShowDialog(gameData);
    }

    [MenuItem("Custom Tools/Get Save File Path")]
    private static void GetSaveFilePath()
    {
        // Get the path where the save files are stored in the same location as GameSaves
        string saveFolderPath = Path.Combine(Application.persistentDataPath, "GameSaves");
        Debug.Log("Save file path: " + saveFolderPath);
    }
}

// Custom Editor Window to set values for GameData
public class GameSaveFileWindow : EditorWindow
{
    private string gameName;
    private string playerName;
    private int lastCheckpoint;

    public GameData ShowDialog(GameData initialData)
    {
        gameName = initialData.gameName;
        playerName = initialData.playerName;
        lastCheckpoint = initialData.lastCheckpoint;
        ShowUtility();
        return initialData;
    }

    private void OnGUI()
    {
        GUILayout.Label("Game Save File Settings", EditorStyles.boldLabel);

        // Allow setting values for gameData
        gameName = EditorGUILayout.TextField("Save File Name:", gameName);
        playerName = EditorGUILayout.TextField("Player Name:", playerName);
        lastCheckpoint = EditorGUILayout.IntField("Last Checkpoint:", lastCheckpoint);

        EditorGUILayout.Space();

        if (GUILayout.Button("Create Save File"))
        {
            // Create a new instance of GameData with the specified input fields
            GameData newGameData = new GameData(gameName);
            newGameData.playerName = playerName;
            newGameData.lastCheckpoint = lastCheckpoint;

            // Serialize the newGameData and save it to a file using the game name as the save file name
            string json = JsonUtility.ToJson(newGameData);
            string saveFileName = gameName + ".json"; // Use gameName as the save file name

            // Define the path where the save file will be stored in the same location as GameSaves
            string saveFolderPath = Path.Combine(Application.persistentDataPath, "GameSaves");
            string saveFilePath = Path.Combine(saveFolderPath, saveFileName);

            // Create the GameSaves folder if it doesn't exist
            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
            }

            // Write the JSON data to the file
            System.IO.File.WriteAllText(saveFilePath, json);

            // Refresh the Asset Database to make the new save file visible in the Unity Editor
            AssetDatabase.Refresh();

            Debug.Log("Game save file created: " + saveFilePath);

            // Close the editor window
            Close();
        }
    }
}
