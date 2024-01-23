using UnityEngine;

public class Minimap : MonoBehaviour, UIElement
{
    #region UIElement Interface Methods
    public void Show()
    {
        gameObject.SetActive(true);
        Debug.LogWarning("TODO: add additional logic to customize the behavior when showing the minimap");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Debug.LogWarning("TODO: add additional logic to customize the behavior when hiding the minimap");
    }

    public void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Debug.LogWarning("TODO: add additional logic to customize the behavior when toggling the visibility of the minimap");
    }

    public bool IsVisible()
    {
        return gameObject.activeSelf;
    }

    #endregion
}
