using UnityEngine;

public class PlayerStatusUI : MonoBehaviour, UIElement
{
    [SerializeField] private HealthUI healthUI;

    #region UIElement Interface Methods
    public void Show()
    {
        gameObject.SetActive(true);

        // Additional logic to show specific player status UI elements if needed
        if (healthUI != null)
        {
            healthUI.Show();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        // Additional logic to hide specific player status UI elements if needed
        if (healthUI != null)
        {
            healthUI.Hide();
        }
    }

    public void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        // Additional logic to toggle visibility of specific player status UI elements if needed
        if (healthUI != null)
        {
            healthUI.ToggleVisibility();
        }
    }

    public bool IsVisible()
    {
        return gameObject.activeSelf;
    }

    #endregion
}
