using UnityEngine;

public class Crosshair : MonoBehaviour, UIElement
{
    public int crosshairTextureIndex; // a range from 0 to ? for crosshair texture;
    public Color crosshairColor = Color.white; // main color
    public Color crosshairSecondaryColor = Color.red; // secondary color
    public int crosshairCustomValue0 = 1;
    public int crosshairCustomValue1 = 1;
    public int crosshairCustomValue2 = 1;
    public int crosshairCustomValue3 = 1;

    #region UIElement Interface Methods
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public bool IsVisible()
    {
        return gameObject.activeSelf;
    }

    #endregion
}
