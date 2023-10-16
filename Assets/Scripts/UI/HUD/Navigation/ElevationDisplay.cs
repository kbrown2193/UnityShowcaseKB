using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevationDisplay : MonoBehaviour
{
    [SerializeField]
    private Text elevationValueText;
    [SerializeField]
    private GameObject elevationIndicator;
    private float elevationMeters = 0f;
    private float elevationFeet = 0f;

    private float zeroElevationYPixels = -75f;
    private float maxElevationYPixels = 75f;
    private float heightOfElevationIndicatorZone;//  ABS (maxElevationYPixels - zeroElevationYPixels)
    private float zeroElevationValue = 0f;
    private float maxElevationValue = 100000f;

    private float percentageFull = 0f;

    private Vector3 indicatorVectorPosition = Vector3.zero;

    private string elevationFormatingString = "#####0";

    void Awake()
    {
        heightOfElevationIndicatorZone = maxElevationYPixels - zeroElevationYPixels;
        //indicatorVectorPosition = elevationIndicator.GetComponent<RectTransform>().position;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetElevationNormalized(float value)
    {
        // from zero to 1 (1 is max elevation for this...
    }
    public void SetElevationMeters(float value)
    {
        elevationValueText.text = value.ToString(elevationFormatingString);
        elevationMeters = value;
        //elevationIndicator. // how to set indicato
        percentageFull = elevationMeters / maxElevationValue;
        indicatorVectorPosition.y = zeroElevationYPixels + (percentageFull * heightOfElevationIndicatorZone);
        Debug.Log("Setting indicator at % = " + percentageFull + ", and zero Y px = " + zeroElevationYPixels + ", and height = " + heightOfElevationIndicatorZone);
        Debug.Log("Indicator Vector = " + indicatorVectorPosition.ToString());
        SetElevationIndicator();
    }
    public void SetElevationFeet(float value)
    {

    }

    public void SetElevationIndicator()
    {
        //elevationIndicator.GetComponent<RectTransform>().position = indicatorVectorPosition; // giving a bad global pos...
        elevationIndicator.GetComponent<RectTransform>().localPosition = indicatorVectorPosition;
    }

    //public void CalculateDirection
}
