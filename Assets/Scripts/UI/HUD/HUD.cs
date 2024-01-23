using UnityEngine;

public class HUD : MonoBehaviour, UIElement
{
    [SerializeField] private Crosshair crosshair;
    [SerializeField] private Minimap minimap;
    [SerializeField] private PlayerStatusUI playerStatusUI;

    #region UIElement Interface Methods
    public void Show()
    {
        gameObject.SetActive(true);

        // Additional logic to show specific HUD elements if needed
        if (crosshair != null)
        {
            crosshair.Show();
        }

        if (minimap != null)
        {
            minimap.Show();
        }

        if (playerStatusUI != null)
        {
            playerStatusUI.Show();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        // Additional logic to hide specific HUD elements if needed
        if (crosshair != null)
        {
            crosshair.Hide();
        }

        if (minimap != null)
        {
            minimap.Hide();
        }

        if (playerStatusUI != null)
        {
            playerStatusUI.Hide();
        }
    }

    public void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        // Additional logic to toggle visibility of specific HUD elements if needed
        if (crosshair != null)
        {
            crosshair.ToggleVisibility();
        }

        if (minimap != null)
        {
            minimap.ToggleVisibility();
        }

        if (playerStatusUI != null)
        {
            playerStatusUI.ToggleVisibility();
        }
    }

    public bool IsVisible()
    {
        return gameObject.activeSelf;
    }

    #endregion
}
