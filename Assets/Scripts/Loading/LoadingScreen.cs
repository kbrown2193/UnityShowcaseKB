using System.Collections;
using UnityEngine;
using TMPro;

public class LoadingScreen : MonoBehaviour
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
}
