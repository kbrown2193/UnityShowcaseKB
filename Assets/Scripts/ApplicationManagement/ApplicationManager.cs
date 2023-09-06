using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public enum ApplicationState
    {
        Startup,
        MainMenu,
        Cinematic,
        Game,
        Paused
    }

    private ApplicationState currentState = ApplicationState.Startup;

    public ApplicationState CurrentState
    {
        get { return currentState; }
        set
        {
            Debug.Log("Changing application state from " + currentState.ToString() + " to " + value.ToString());
            currentState = value;
            // Handle state change logic here
        }
    }

    #region Singleton
    private static ApplicationManager instance;

    public static ApplicationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ApplicationManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("ApplicationManager");
                    instance = go.AddComponent<ApplicationManager>();
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

    private void Start()
    {
        // Initialize your game here
        CurrentState = ApplicationState.Startup;
    }
}
