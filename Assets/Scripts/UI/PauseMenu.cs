using UnityEngine;

public class PauseMenu : MonoBehaviour, UIElement
{
    #region Private Variables
    [SerializeField] private GameObject pauseMenuPanel;
    #endregion

    private void Start()
    {
        Hide();
    }

    #region UIElement Interface Methods

    public void Show()
    {
        GameTimeManager.Instance.PauseGameTime();
        pauseMenuPanel.SetActive(true); // Show the pause menu panel
    }

    public void Hide()
    {
        GameTimeManager.Instance.ResumeGameTime();
        pauseMenuPanel.SetActive(false); // Hide the pause menu panel
    }

    public void ToggleVisibility()
    {
        if (pauseMenuPanel.activeSelf)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public bool IsVisible()
    {
        return pauseMenuPanel.activeSelf;
    }

    #endregion

    #region Additional Functions

    // Additional functions for the PauseMenu class

    #endregion
}
