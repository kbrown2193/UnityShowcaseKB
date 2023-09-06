using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupLauncher : MonoBehaviour
{
    [SerializeField] private StartupLauncherUI startupLauncherUI;
    [SerializeField] private string[] startupInstructions;
    private int currentStep = 0;

    private void Start()
    {
        // Start the startup process
        startupLauncherUI.InitUI();
        ExecuteNextStep();
    }

    private void ExecuteNextStep()
    {
        if (currentStep < startupInstructions.Length)
        {
            string stepName = startupInstructions[currentStep];
            float progressPercentage = (float)(currentStep + 1) / startupInstructions.Length * 100f;
            startupLauncherUI.UpdateProgress(stepName, progressPercentage);

            // Execute the current step's task here

            // Simulate a delay (replace this with your actual task)
            StartCoroutine(SimulateTaskCompletion());
        }
        else
        {
            // Startup completed
            startupLauncherUI.TransitionToMainMenu();
        }
    }

    private System.Collections.IEnumerator SimulateTaskCompletion()
    {
        Debug.Log("Task[" + currentStep + "] = " + startupInstructions[currentStep] + " started at " + Time.time.ToString());
        // Simulate a task completion
        yield return new WaitForSeconds(2f);

        Debug.Log("Task[" + currentStep + "] = " + startupInstructions[currentStep] + " finished at " + Time.time.ToString());
        // Move to the next step
        currentStep++;
        ExecuteNextStep();
    }

    public void DestroyStartupLauncher()
    {
        Debug.Log("Destroying Startup Launcher at " + Time.time.ToString());
        ApplicationManager.Instance.CurrentState = (ApplicationManager.ApplicationState.MainMenu);   // CurrentState (ApplicationManager.ApplicationState.MainMenu));
        // Safely destroy the StartupLauncher and StartupLauncherUI
        Destroy(gameObject);
        Destroy(startupLauncherUI.gameObject);
    }
}
