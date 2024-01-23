using UnityEngine;

public class OrientationInformer : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;

    public Vector2 WorldCenterGeographicCoordinates = new Vector2(0, 0);
    public float UnityDistancePerGeographicCoordinatesDegree = 1f; // 111139 for one to one
    public float UnityDistancePerElevation = 1f; // 1 for 1 to one

    private float direction;
    private Vector2 geoCoordinates;
    private float elevation;
    private float pitchAngle;

    private void Start()
    {
        // Assign the transform component if it's not already assigned
        if (_transform == null)
        {
            _transform = transform;
        }
    }

    public float DirectionLookingToCompassDegrees()
    {
        Vector3 forward = _transform.forward;

        if (Mathf.Approximately(pitchAngle, 90f))
        {
            forward = -_transform.up;
        }
        else if (Mathf.Approximately(pitchAngle, -90f))
        {
            forward = _transform.up;
        }

        float angleRadians = Mathf.Atan2(forward.z, -forward.x);
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        if (angleDegrees < 0)
        {
            angleDegrees += 360f;
        }

        float compassDegrees = (angleDegrees - 90f) % 360f;
        if (compassDegrees < 0)
        {
            compassDegrees += 360f;
        }

        return compassDegrees;
    }

    public Vector2 PositionToGeographicCoordinates()
    {
        float latitude = WorldCenterGeographicCoordinates.x + (_transform.position.z / UnityDistancePerGeographicCoordinatesDegree);
        float longitude = WorldCenterGeographicCoordinates.y + (_transform.position.x / UnityDistancePerGeographicCoordinatesDegree);

        return new Vector2(latitude, longitude);
    }

    public float PositionToElevation()
    {
        float elevation = _transform.position.y / UnityDistancePerElevation;
        return elevation;
    }

    /// <summary>
    /// X Rotation is on the main camera, currently use that OrientationInformer to GetPitchAngle
    /// </summary>
    /// <returns></returns>
    public float GetPitchAngle()
    {
        float xRotation = _transform.rotation.eulerAngles.x;

        // Adjust the angle to be in the range of -180 to 180 degrees
        if (xRotation > 180f)
        {
            xRotation -= 360f;
        }

        // Clamp the angle between -90 and 90 degrees
        pitchAngle = -Mathf.Clamp(xRotation, -90f, 90f);

        return pitchAngle;
    }

    void Update()
    {
        direction = DirectionLookingToCompassDegrees();
        geoCoordinates = PositionToGeographicCoordinates();
        elevation = PositionToElevation();
        pitchAngle = GetPitchAngle();
        //Debug.Log("Direction Looking: " + direction + " degrees");
        //Debug.Log("Geographic Coordinates: Latitude " + geoCoordinates.x + ", Longitude " + geoCoordinates.y);
        //Debug.Log("Elevation: " + elevation + " units");
        //Debug.Log("Pitch Angle: " + pitchAngle + " degrees");
    }
}
