using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour, UIElement
{
    #region Variables

    [SerializeField] private Statbar healthStatBar;
    [SerializeField] private TextMeshProUGUI healthText;

    public float defaultHealthValue = 100; // for TESTING: the health value
    public float defaultHealthMax = 100; // for TESTING: the maximum health

    #endregion

    void Start()
    {
        // TESTING
        RefreshHealthUI(defaultHealthValue, defaultHealthMax);
    }

    #region UIElement Interface Methods
    public void Show()
    {
        gameObject.SetActive(true);

        // Additional logic to show specific health UI elements if needed
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        // Additional logic to hide specific health UI elements if needed
    }

    public void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        // Additional logic to toggle visibility of specific health UI elements if needed
    }

    public bool IsVisible()
    {
        return gameObject.activeSelf;
    }

    #endregion

    #region Health UI Refreshing

    public void RefreshHealthUI(float health)
    {
        healthStatBar.SetFillValue(health / defaultHealthMax);
        healthText.text = health.ToString("##0.##") + " / " + defaultHealthMax.ToString();
    }

    public void RefreshHealthUI(float health, float healthMax)
    {
        healthStatBar.SetFillValue(health / healthMax);
        healthText.text = health.ToString() + " / " + healthMax.ToString();
    }

    #endregion
}
