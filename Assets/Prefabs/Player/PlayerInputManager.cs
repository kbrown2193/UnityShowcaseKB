using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public enum PlayerInputScheme
    {
        Menus,
        FirstPerson,
        ThirdPerson,
        TopDown,
        Vehicle
    }

    public PlayerInputScheme currentInputScheme = PlayerInputScheme.ThirdPerson; // Set default input scheme
    public PlayerController playerController;
    public CameraController cameraController;

    void Update()
    {
        switch (currentInputScheme)
        {
            case PlayerInputScheme.Menus:
                HandleMenusInput();
                break;
            case PlayerInputScheme.FirstPerson:
                HandleFirstPersonInput();
                break;
            case PlayerInputScheme.ThirdPerson:
                HandleThirdPersonInput();
                break;
            case PlayerInputScheme.TopDown:
                HandleTopDownInput();
                break;
            case PlayerInputScheme.Vehicle:
                HandleVehicleInput();
                break;
        }
    }

    void HandleMenusInput()
    {
        // Get movement inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Get look inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Pass inputs to PlayerController and CameraController
        //playerController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
        //cameraController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
    }

    void HandleFirstPersonInput()
    {
        // Get movement inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Get look inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ... Handle other first person inputs
        if (Input.GetButton("Jump"))
        {
            // Handle jump
        }

        if (Input.GetButtonDown("Interact"))
        {
            // Handle interact
        }

        if (Input.GetButton("Sprint"))
        {
            // Handle sprint
        }

        if (Input.GetButtonDown("Fire1"))
        {
            // Handle primary action (LMB)
        }

        if (Input.GetButtonDown("Fire2"))
        {
            // Handle secondary action (RMB)
        }

        if (Input.GetButtonDown("Fire3"))
        {
            // Handle tertiary action (MMB)
        }

        if (Input.GetButtonDown("Pause"))
        {
            // Handle pause
            UIManager.Instance.TogglePauseMenu();
        }

        if (Input.GetButtonDown("Inventory"))
        {
            // Handle inventory
        }

        if (Input.GetButtonDown("Reload"))
        {
            // Handle reload
        }

        if (Input.GetButtonDown("QualityAction"))
        {
            // Handle quality action (Q)
        }

        for (int i = 1; i <= 9; i++)
        {
            if (Input.GetButtonDown("QuickAction" + i))
            {
                // Handle quick action i (0 to 9)
            }
        }

        // Pass inputs to PlayerController and CameraController
        playerController.HandleMoveAndLook(horizontal, vertical,mouseX, mouseY);
        cameraController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
    }

    void HandleThirdPersonInput()
    {
        // Handle third person inputs
        // Get movement inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Get look inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // TODO: ... Handle other third person inputs
        if (Input.GetButtonDown("Pause"))
        {
            // Handle pause
            UIManager.Instance.TogglePauseMenu();
        }

        playerController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
        cameraController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
    }

    void HandleTopDownInput()
    {
        // Handle top-down inputs
        // Get movement inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Get look inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //  TODO: ... Handle other top-down inputs
        if (Input.GetButtonDown("Pause"))
        {
            // Handle pause
            UIManager.Instance.TogglePauseMenu();
        }

        playerController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
        cameraController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
    }

    void HandleVehicleInput()
    {
        // Handle vehicle inputs
        // Get movement inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Get look inputs
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // TODO: ... Handle other vehicle inputs
        if (Input.GetButtonDown("Pause"))
        {
            // Handle pause
            UIManager.Instance.TogglePauseMenu();
        }

        playerController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
        cameraController.HandleMoveAndLook(horizontal, vertical, mouseX, mouseY);
    }
}
