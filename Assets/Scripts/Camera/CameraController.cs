using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    public float firstPersonCameraHeight = 1.5f;
    public float firstPersonFOV = 60f;
    public float thirdPersonCameraHeight = 5f;
    public float thirdPersonFollowDistance = 5f;
    public float thirdPersonFOV = 60f;
    public float topDownAngle = 35.264f;
    public float topDownCameraHeight = 10f;
    float lookSpeed = 2f;

    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private PlayerInputManager playerInputManager;
    private PlayerInputManager.PlayerInputScheme playerInputScheme;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        if (playerInputManager == null)
        {
            playerInputManager = FindObjectOfType<PlayerInputManager>();
        }
    }

    public void HandleMoveAndLook(float horizontal, float vertical, float mouseX, float mouseY)
    {
        // Handle camera movement based on input
        switch (playerInputManager.currentInputScheme)
        {
            case PlayerInputManager.PlayerInputScheme.Menus:
                HandleMenusMoveAndLook(horizontal, vertical, mouseX, mouseY);
                break;
            case PlayerInputManager.PlayerInputScheme.FirstPerson:
                HandleFirstPersonMoveAndLook(horizontal, vertical, mouseX, mouseY);
                break;
            case PlayerInputManager.PlayerInputScheme.ThirdPerson:
                HandleThirdPersonMoveAndLook(horizontal, vertical, mouseX, mouseY);
                break;
            case PlayerInputManager.PlayerInputScheme.TopDown:
                HandleTopDownMoveAndLook(horizontal, vertical, mouseX, mouseY);
                break;
                // Add cases for other input schemes as needed
        }

        //cameraTransform.Rotate(Vector3.left * mouseY * lookSpeed);
    }

    private void HandleMenusMoveAndLook(float horizontal, float vertical, float mouseX, float mouseY)
    {
        // Handle Menus Movement
    }

    private void HandleFirstPersonMoveAndLook(float horizontal, float vertical, float mouseX, float mouseY)
    {
        // Handle first-person camera movement
        //float rotationX = cameraTransform.rotation.eulerAngles.x - mouseY * lookSpeed;

        // Limit the vertical rotation to a specific range (e.g., -80 to 80 degrees)
       // rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        //cameraTransform.rotation = Quaternion.Euler(rotationX, cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
    }


    private void HandleThirdPersonMoveAndLook(float horizontal, float vertical, float mouseX, float mouseY)
    {
        // Handle third-person camera movement
        Vector3 cameraOffset = new Vector3(0f, thirdPersonCameraHeight, -thirdPersonFollowDistance);
        cameraTransform.position = playerTransform.position + cameraOffset;
        cameraTransform.LookAt(playerTransform.position);
    }

    private void HandleTopDownMoveAndLook(float horizontal, float vertical, float mouseX, float mouseY)
    {
        // Handle top-down camera movement
        float rotationSpeed = 5f;

        // Rotate the player based on mouse input
        //playerTransform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // Calculate the desired forward direction in world space
        Vector3 forwardDirection = Quaternion.Euler(0, playerTransform.eulerAngles.y, 0) * Vector3.forward;

        // Calculate the movement direction based on input
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Update the player's position
        //playerTransform.position += moveDirection * Time.deltaTime * playerMovementSpeed;

        // Set the camera position above the player
        Vector3 cameraPosition = playerTransform.position + Vector3.up * topDownCameraHeight;

        // Set the camera rotation to look at the player's position
        cameraTransform.position = cameraPosition;
        cameraTransform.LookAt(playerTransform.position);
    }


    public void SwitchPlayerInputScheme(PlayerInputManager.PlayerInputScheme newInputScheme)
    {
        playerInputScheme = newInputScheme;
        // Perform any other actions or adjustments needed when switching input schemes
    }
}
