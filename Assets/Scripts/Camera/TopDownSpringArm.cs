using UnityEngine;

public class TopDownSpringArm : MonoBehaviour
{
    [Tooltip("The transform to follow.")]
    public Transform target; // The transform to follow

    [Tooltip("Distance above the target in +Y axis. (e.g., 5 for default height)")]
    public float followDistance = 5f; // Distance above the target in +Y axis

    [Tooltip("Damping factor for smooth camera movement. (e.g., 10 for slow, 1 for fast)")]
    public float damping = 5f; // Damping factor for smooth camera movement

    [Tooltip("If true, the camera will rotate with the target. If false, the camera will maintain a fixed rotation.")]
    public bool rotateWithTarget = true; // Controls if the camera rotates with the target or maintains fixed rotation

    private Vector3 offset; // Offset between the target and the camera
    private Quaternion initialRotation; // Initial rotation of the camera

    void Start()
    {
        // Calculate the initial offset between camera and target
        offset = transform.position - target.position;

        // Store the initial rotation of the camera
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Calculate the desired camera position based on the target's position and follow distance
        Vector3 targetPosition = target.position + Vector3.up * followDistance;

        // Smoothly interpolate between current position and target position using damping
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition + offset, 1 - Mathf.Exp(-damping * Time.deltaTime));

        // Update the camera's position
        transform.position = newPosition;

        // Rotate the camera to match the target's rotation if rotateWithTarget is true
        if (rotateWithTarget)
        {
            transform.LookAt(target);
        }
        else
        {
            // Maintain fixed rotation if rotateWithTarget is false
            transform.rotation = initialRotation;
        }
    }
}
