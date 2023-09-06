using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartupLauncherUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image logoImage;
    [SerializeField] private Image overlayImage;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private TextMeshProUGUI titleText;

    public void InitUI()
    {
        // Initialize your UI elements here
    }

    public void UpdateProgress(string stepName, float progressPercentage)
    {
        progressText.text = $"Step {progressPercentage:F0}% = {stepName}";
    }

    public void TransitionToMainMenu()
    {
        animator.SetBool("IsToMainMenu", true);
    }

    public void DisableStartupLauncherUI()
    {
        gameObject.SetActive(false);
    }
}
