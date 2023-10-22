using UnityEngine;
using TMPro;

public class OIPitchDisplay : MonoBehaviour
{
    [SerializeField]
    private OrientationInformer orientationInformer;

    [SerializeField]
    private TextMeshProUGUI pitchText;

    [SerializeField]
    private bool isOn = true;

    private void Start()
    {
        // Get the TextMeshProUGUI component only if it is null
        if (pitchText == null)
        {
            pitchText = GetComponent<TextMeshProUGUI>();
        }

        if (orientationInformer == null)
        {
            Debug.LogError("OrientationInformer reference not set in OIPitchDisplay script!");
        }
    }

    private void Update()
    {
        // Check if the update loop is enabled
        if (isOn && orientationInformer != null && pitchText != null)
        {
            // Get pitch angle as float from orientationInformer
            float pitchAngle = orientationInformer.GetPitchAngle();

            // Update the TextMeshProUGUI text with pitch angle
            pitchText.text = "Pitch Angle: " + pitchAngle.ToString("+00.000;-00.000") + " degrees";
        }
        else
        {
            Debug.LogWarning("OrientationInformer or TextMeshProUGUI component is not set, or update loop is disabled!");
        }
    }
}
