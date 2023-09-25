using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class GameSaveManager : MonoBehaviour
{
    #region Singleton
    private static GameSaveManager instance;

    public static GameSaveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameSaveManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameSaveManagerSingleton");
                    instance = singleton.AddComponent<GameSaveManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        saveFolderPath = Path.Combine(Application.persistentDataPath, saveFolderName);

        // Create the save folder if it doesn't exist
        if (!Directory.Exists(saveFolderPath))
        {
            Directory.CreateDirectory(saveFolderPath);
        }
    }
    #endregion

    private string saveFolderName = "GameSaves";
    private string saveFolderPath;

    // Constant value for the file extension
    private const string fileExtension = ".json";

    // Check if any game save file exists
    public bool AnySaveExists()
    {
        string[] saveFiles = Directory.GetFiles(saveFolderPath);
        return saveFiles.Length > 0;
    }

    // Check if a specific game save file exists
    public bool SaveExists(string saveFileName)
    {
        string saveFilePath = Path.Combine(saveFolderPath, saveFileName + fileExtension);
        return File.Exists(saveFilePath);
    }

    // Get the names of all game save files
    public string[] GetAllSaveNames()
    {
        string[] saveFiles = Directory.GetFiles(saveFolderPath, "*" + fileExtension);
        List<string> saveNames = new List<string>();

        foreach (string saveFile in saveFiles)
        {
            saveNames.Add(Path.GetFileNameWithoutExtension(saveFile));
        }

        return saveNames.ToArray();
    }

    // Create a new game save
    public void CreateSave(string saveFileName, GameData gameData)
    {
        string fullSaveFileName = saveFileName + fileExtension;
        string saveFilePath = Path.Combine(saveFolderPath, fullSaveFileName);

        // Serialize the game data to JSON
        string json = JsonUtility.ToJson(gameData);

        // Write the JSON data to the file
        File.WriteAllText(saveFilePath, json);
    }

    // Load a game save
    public GameData LoadSave(string saveFileName)
    {
        string fullSaveFileName = saveFileName + fileExtension;
        string saveFilePath = Path.Combine(saveFolderPath, fullSaveFileName);

        // Check if the save file exists before attempting to load it
        if (File.Exists(saveFilePath))
        {
            // Read the JSON data from the file
            string json = File.ReadAllText(saveFilePath);

            // Deserialize the JSON data to GameData object
            GameData gameData = JsonUtility.FromJson<GameData>(json);
            return gameData;
        }
        else
        {
            Debug.LogError("Save file does not exist: " + fullSaveFileName);
            return null;
        }
    }

    // Update an existing game save
    public void Save(string saveFileName, GameData gameData)
    {
        string fullSaveFileName = saveFileName + fileExtension;
        string saveFilePath = Path.Combine(saveFolderPath, fullSaveFileName);

        // Serialize the updated game data to JSON
        string json = JsonUtility.ToJson(gameData);

        // Overwrite the existing save file with the updated data
        File.WriteAllText(saveFilePath, json);
    }

    // Delete a game save
    public void DeleteSave(string saveFileName)
    {
        string fullSaveFileName = saveFileName + fileExtension;
        string saveFilePath = Path.Combine(saveFolderPath, fullSaveFileName);

        // Check if the save file exists before attempting to delete it
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
        else
        {
            Debug.LogError("Cannot delete save file as it does not exist: " + fullSaveFileName);
        }
    }
}
