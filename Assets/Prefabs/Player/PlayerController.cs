using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMovementSpeed = 5f;
    public float playerSprintSpeed = 10f;
    public float playerJumpHeight = 2f;

    public float lookSpeed = 1f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void HandleMoveAndLook(float horizontal, float vertical, float mouseX, float mouseY)
    {
        // Handle movement
        Vector3 moveInput = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveInput.magnitude >= 0.1f)
        {
            float speed = Input.GetButtonDown("Sprint") ? playerSprintSpeed : playerMovementSpeed;

            // Convert the input direction from local to world space
            Vector3 moveDirection = transform.TransformDirection(moveInput);

            characterController.Move(moveDirection * speed * Time.deltaTime);
        }

        // Handle look (horizontal)
        transform.Rotate(Vector3.up * mouseX);

        // Handle look (vertical)
        float verticalRotation = -mouseY * lookSpeed; // Adjust the sign based on player preference.InvertLookVertical TODO:
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f); // Limit vertical rotation to a certain range

        Camera mainCamera = Camera.main;
        mainCamera.transform.Rotate(verticalRotation, 0, 0);
    }


}
