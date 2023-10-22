using UnityEngine;
using TMPro;

public class OIElevationDisplay : MonoBehaviour
{
    [SerializeField]
    private OrientationInformer orientationInformer;

    [SerializeField]
    private TextMeshProUGUI elevationText;

    [SerializeField]
    private bool isOn = true;

    private void Start()
    {
        // Get the TextMeshProUGUI component only if it is null
        if (elevationText == null)
        {
            elevationText = GetComponent<TextMeshProUGUI>();
        }

        if (orientationInformer == null)
        {
            Debug.LogError("OrientationInformer reference not set in OIElevationDisplay script!");
        }
    }

    private void Update()
    {
        // Check if the update loop is enabled
        if (isOn && orientationInformer != null && elevationText != null)
        {
            // Get elevation as float from orientationInformer
            float elevation = orientationInformer.PositionToElevation();

            // Update the TextMeshProUGUI text with elevation
            elevationText.text = "Elevation: " + elevation.ToString("00000.00") + " meters";
        }
        else
        {
            Debug.LogWarning("OrientationInformer or TextMeshProUGUI component is not set, or update loop is disabled!");
        }
    }
}
