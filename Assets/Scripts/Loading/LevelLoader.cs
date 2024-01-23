using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    #region Singleton
    private static LevelLoader instance;

    public static LevelLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelLoader>();
                if (instance == null)
                {
                    GameObject go = new GameObject("LevelLoader");
                    instance = go.AddComponent<LevelLoader>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    [SerializeField] private LoadingScreen loadingScreen;

    public void BeginLoadingLevel(string levelName)
    {
        // Enable loading screen
        loadingScreen.Show();

        // Start async loading
        StartCoroutine(LoadLevelAsync(levelName));
    }

    private IEnumerator LoadLevelAsync(string levelName)
    {
        // Create an operation to load the level asynchronously
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName);

        // Don't allow scene to activate until we allow it
        asyncOperation.allowSceneActivation = false;

        // Wait until the level is fully loaded
        while (!asyncOperation.isDone)
        {
            // Calculate the progress of loading (0 to 1)
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f); // 0.9 is used because isDone becomes true when progress is 0.9

            // Update loading screen with the progress
            loadingScreen.UpdateProgress(progress);

            
            if (progress >= 0.9f)
            {
                // Manually induce a waiting time
                yield return new WaitForSeconds(1f);  // Comment this out for an amazing loading performance boost!

                // Allow scene activation
                asyncOperation.allowSceneActivation = true;
            }

            yield return null; // Yield to the next frame
        }

        UIManager.Instance.FindUIClassesInScene();

        // Disable loading screen
        loadingScreen.Hide();
    }
}
