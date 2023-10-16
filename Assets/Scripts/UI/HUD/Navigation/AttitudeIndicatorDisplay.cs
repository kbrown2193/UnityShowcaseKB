using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttitudeIndicatorDisplay : MonoBehaviour
{
    [SerializeField]
    private RectTransform rotatedObject;

    private Vector3 rotationAngleVector = Vector3.zero;
    private float rotationAngle;

    public void SetRotationAngle(float value)
    {
        rotationAngle = value;
        rotationAngleVector.z = value;
        rotatedObject.rotation = Quaternion.Euler(rotationAngleVector);
    }
}
