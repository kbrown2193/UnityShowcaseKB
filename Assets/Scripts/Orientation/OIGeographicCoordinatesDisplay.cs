using UnityEngine;
using TMPro;

public class OIGeographicCoordinatesDisplay : MonoBehaviour
{
    [SerializeField]
    private OrientationInformer orientationInformer;

    [SerializeField]
    private TextMeshProUGUI geographicCoordinatesText;

    [SerializeField]
    private bool isOn = true;

    [SerializeField]
    private bool useDirectionIndicators = true;

    private void Start()
    {
        // Get the TextMeshProUGUI component only if it is null
        if (geographicCoordinatesText == null)
        {
            geographicCoordinatesText = GetComponent<TextMeshProUGUI>();
        }

        if (orientationInformer == null)
        {
            Debug.LogError("OrientationInformer reference not set in OIGeographicCoordinatesDisplay script!");
        }
    }

    private void Update()
    {
        // Check if the update loop is enabled
        if (isOn && orientationInformer != null && geographicCoordinatesText != null)
        {
            // Get geographic coordinates as Vector2 from orientationInformer
            Vector2 geographicCoordinates = orientationInformer.PositionToGeographicCoordinates();

            // Format the coordinates with specified decimal places
            string latitudeString = string.Format("{0:00.00000}", Mathf.Abs(geographicCoordinates.x)) + (useDirectionIndicators ? (geographicCoordinates.x >= 0 ? "N" : "S") : "");
            string longitudeString = string.Format("{0:000.00000}", Mathf.Abs(geographicCoordinates.y)) + (useDirectionIndicators ? (geographicCoordinates.y >= 0 ? "E" : "W") : "");

            // Update the TextMeshProUGUI text with geographic coordinates
            geographicCoordinatesText.text = "Latitude: " + latitudeString + "\nLongitude: " + longitudeString;
        }
        else
        {
            Debug.LogWarning("OrientationInformer or TextMeshProUGUI component is not set, or update loop is disabled!");
        }
    }
}
