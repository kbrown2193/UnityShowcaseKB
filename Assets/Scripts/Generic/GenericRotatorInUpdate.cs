using UnityEngine;

public class GenericRotatorInUpdate : MonoBehaviour
{
    public float rotateSpeed = 50f; // Rotation speed in degrees per second
    public Vector3 rotateAxis = Vector3.up; // Axis around which to rotate
    public bool isClockwise = false; // Rotation direction (clockwise or counterclockwise)
    public bool isActive = true; // Control whether rotation is active or not

    void Update()
    {
        if (isActive)
        {
            // Determine the direction of rotation based on isClockwise variable
            int direction = isClockwise ? -1 : 1;

            // Calculate the rotation amount based on time and speed
            float rotationAmount = rotateSpeed * direction * Time.deltaTime;

            // Apply rotation to the GameObject
            transform.Rotate(rotateAxis, rotationAmount);
        }
    }
}
