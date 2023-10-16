using UnityEngine;

public class OrientationInformer : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;

    public Vector2 WorldCenterGeographicCoordinates = new Vector2(0, 0);
    public float UnityDistancePerGeographicCoordinatesDegree = 1f;
    public float UnityDistancePerElevation = 1f;

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
        float pitchAngle = GetPitchAngle();

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

    public float GetPitchAngle()
    {
        Vector3 localForward = _transform.forward;
        float pitchAngle = Mathf.Rad2Deg * Mathf.Atan2(localForward.y, Mathf.Sqrt(localForward.x * localForward.x + localForward.z * localForward.z));

        return pitchAngle;
    }

    void Update()
    {
        float direction = DirectionLookingToCompassDegrees();
        Vector2 geoCoordinates = PositionToGeographicCoordinates();
        float elevation = PositionToElevation();
        float pitchAngle = GetPitchAngle();
        Debug.Log("Direction Looking: " + direction + " degrees");
        Debug.Log("Geographic Coordinates: Latitude " + geoCoordinates.x + ", Longitude " + geoCoordinates.y);
        Debug.Log("Elevation: " + elevation + " units");
        Debug.Log("Pitch Angle: " + pitchAngle + " degrees");
    }
}
