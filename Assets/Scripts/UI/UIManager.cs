using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton

    // Singleton instance
    private static UIManager instance;

    // Get the singleton instance
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("UIManager");
                    instance = obj.AddComponent<UIManager>();
                }
            }

            return instance;
        }
    }

    #endregion

    #region Variables

    // Variables for different UI classes
    public MainMenu mainMenu;
    public LoadingScreen loadingScreen;
    public PauseMenu pauseMenu;
    public HUD hud;
    public DialogManager dialogManager;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        // Ensure there's only one instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        // Find UI classes in the scene if not assigned
        FindUIClassesInScene();
    }

    #endregion

    #region UI Finding Functions

    // Function to find and assign UI classes if not assigned
    public void FindUIClassesInScene()
    {
        if (mainMenu == null)
            mainMenu = FindObjectOfType<MainMenu>();

        if (loadingScreen == null)
            loadingScreen = FindObjectOfType<LoadingScreen>();

        if (pauseMenu == null)
            pauseMenu = FindObjectOfType<PauseMenu>();

        if (hud == null)
            hud = FindObjectOfType<HUD>();

        if (dialogManager == null)
            dialogManager = FindObjectOfType<DialogManager>();
    }

    #endregion

    #region Visibility Functions

    #region Show/Hide Functions

    // Functions to show/hide different UI elements
    public void ShowMainMenu()
    {
        mainMenu.Show();
        loadingScreen.Hide();
        pauseMenu.Hide();
        hud.Hide();
        dialogManager.Hide();
    }

    public void ShowLoadingScreen()
    {
        mainMenu.Hide();
        loadingScreen.Show();
        pauseMenu.Hide();
        hud.Hide();
        dialogManager.Hide();
    }

    public void ShowPauseMenu()
    {
        mainMenu.Hide();
        loadingScreen.Hide();
        pauseMenu.Show();
        hud.Hide();
        dialogManager.Hide();
    }

    public void ShowHUD()
    {
        mainMenu.Hide();
        loadingScreen.Hide();
        pauseMenu.Hide();
        hud.Show();
        dialogManager.Hide();
    }

    public void ShowDialogManager()
    {
        mainMenu.Hide();
        loadingScreen.Hide();
        pauseMenu.Hide();
        hud.Hide();
        dialogManager.Show();
    }

    public void HideAll()
    {
        mainMenu.Hide();
        loadingScreen.Hide();
        pauseMenu.Hide();
        hud.Hide();
        dialogManager.Hide();
    }

    #endregion

    #region Toggle Functions

    // Updated Toggle functions to call ToggleVisibility
    public void ToggleMainMenu()
    {
        mainMenu.ToggleVisibility();
    }

    public void ToggleLoadingScreen()
    {
        loadingScreen.ToggleVisibility();
    }

    public void TogglePauseMenu()
    {
        pauseMenu.ToggleVisibility();
    }

    public void ToggleHUD()
    {
        hud.ToggleVisibility();
    }

    public void ToggleDialogManager()
    {
        dialogManager.ToggleVisibility();
    }

    #endregion

    #endregion
}
