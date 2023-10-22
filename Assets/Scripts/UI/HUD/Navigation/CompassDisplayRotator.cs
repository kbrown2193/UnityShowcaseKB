using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassDisplayRotator : MonoBehaviour
{
    [SerializeField]
    private RectTransform needle;

    [SerializeField]
    private NeedleRotationDirection needleRotationDirection = NeedleRotationDirection.CounterClockwise;

    [SerializeField]
    private float rotationOffsetInitial = 0.0f; // any inital offset for this image?

    private Vector3 rotationVector = Vector3.zero;

    const float DEGREES_TO_ONE_SCALE_DIVIDER = 360f;

    public enum NeedleRotationDirection
    {
        Clockwise,
        CounterClockwise
    }

    public void SetCompassByDegree(float degrees)
    {
        switch(needleRotationDirection)
        {
            case NeedleRotationDirection.Clockwise:
                degrees = -degrees; // degree given is NOT the rotation z, is opposite direction
                rotationVector.z = (degrees - rotationOffsetInitial); // and sutract the offset initial,as is negative direction
                break;
            case NeedleRotationDirection.CounterClockwise:
                //degrees = degrees; // degree given IS the rotation Z
                rotationVector.z = (degrees + rotationOffsetInitial);
                break;
            default:
                break;
        }

        //Debug.Log("SETTING DEGREE ROTATION = " + rotationVector.z);
        needle.rotation = Quaternion.Euler(( rotationVector));
    }
}
