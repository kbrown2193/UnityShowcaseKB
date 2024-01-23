using System.Collections;
using UnityEngine;
using TMPro;

public class LoadingScreen : MonoBehaviour, UIElement
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI loadingScreenText;

    public void UpdateProgress(float progress)
    {
        // Ensure the loadingScreenText component is not null
        if (loadingScreenText != null)
        {
            // Update the text to show the loading progress as a percentage
            loadingScreenText.text = $"Loading... {Mathf.RoundToInt(progress * 100)}%";
        }
    }

    // Implementing UIElement interface methods

    public void Show()
    {
        gameObject.SetActive(true);
        Debug.LogWarning("TODO: add additional logic here to initialize the loading screen as needed");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Debug.LogWarning("TODO: add additional logic here to initialize the loading screen as needed");
    }

    public void ToggleVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Debug.LogWarning("TODO: add additional logic here to toggle visibility as needed");
    }

    public bool IsVisible()
    {
        return gameObject.activeSelf;
    }
}
