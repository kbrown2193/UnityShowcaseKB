using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    #region Singleton Implementation
    private static GameTimeManager instance;

    public static GameTimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameTimeManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameTimeManager");
                    instance = singleton.AddComponent<GameTimeManager>();
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
            Destroy(gameObject);
        }
    }
    #endregion

    #region Private Variables
    private bool isGamePaused = false;
    private float gameTimeElapsed = 0f;
    private float applicationTimeElapsed = 0f;
    private float cumulativeGameTime = 0f;
    private float cumulativeApplicationTime = 0f;
    #endregion

    #region Update Loop
    private void Update()
    {
        // Update game time only if not paused
        if (!isGamePaused)
        {
            gameTimeElapsed += Time.deltaTime;
            cumulativeGameTime += Time.deltaTime;
        }

        // Update application time regardless of pause state
        applicationTimeElapsed += Time.deltaTime;
        cumulativeApplicationTime += Time.deltaTime;
    }
    #endregion

    #region Game Time Control Functions
    // Properties to get the elapsed game time and cumulative game time
    public float GameTimeElapsed => gameTimeElapsed;
    public float CumulativeGameTime => cumulativeGameTime;

    // Properties to get the elapsed application time and cumulative application time
    public float ApplicationTimeElapsed => applicationTimeElapsed;
    public float CumulativeApplicationTime => cumulativeApplicationTime;

    // Function to pause the game time
    public void PauseGameTime()
    {
        if (!isGamePaused)
        {
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }

    // Function to resume the game time
    public void ResumeGameTime()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }

    // Function to reset game time
    public void ResetGameTime()
    {
        gameTimeElapsed = 0f;
    }

    // Function to reset application time
    public void ResetApplicationTime()
    {
        applicationTimeElapsed = 0f;
    }

    // Function to reset session time (both game time and application time)
    public void ResetSessionTime()
    {
        gameTimeElapsed = 0f;
        applicationTimeElapsed = 0f;
    }
    #endregion
}
