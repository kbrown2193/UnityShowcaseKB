using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour, UIElement
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;

    #region UIElement Interface Methods

    // Implementing UIElement interface methods

    public void Show()
    {
        if (dialogBox != null)
        {
            ShowDialog(); // Call ShowDialog internally

            // Additional logic to customize the behavior when showing the dialog manager
        }
        else
        {
            Debug.LogError("Dialog box GameObject is not assigned in the inspector!");
        }
    }

    public void Hide()
    {
        if (dialogBox != null)
        {
            HideDialog(); // Call HideDialog internally

            // Additional logic to customize the behavior when hiding the dialog manager
        }
        else
        {
            Debug.LogError("Dialog box GameObject is not assigned in the inspector!");
        }
    }

    public void ToggleVisibility()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(!dialogBox.activeSelf);

            // Additional logic to customize the behavior when toggling the visibility of the dialog manager
        }
        else
        {
            Debug.LogError("Dialog box GameObject is not assigned in the inspector!");
        }
    }

    public bool IsVisible()
    {
        return dialogBox != null && dialogBox.activeSelf;
    }

    #endregion

    // Show the dialog box with an empty text
    private void ShowDialog()
    {
        ShowDialog("");
    }

    // Show the dialog box with the specified text
    private void ShowDialog(string text)
    {
        if (dialogBox != null)
        {
            dialogText.text = text;
            dialogBox.SetActive(true);
        }
        else
        {
            Debug.LogError("Dialog box GameObject is not assigned in the inspector!");
        }
    }

    // Hide the dialog box
    private void HideDialog()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(false);
        }
        else
        {
            Debug.LogError("Dialog box GameObject is not assigned in the inspector!");
        }
    }
}
