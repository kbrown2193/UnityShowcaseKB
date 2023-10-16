using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple display that has two text components for the latitude and longitude.
/// 
/// These values will typically be in degrees.
/// 
/// Latitude will be the North/South angle from the equator
/// Longitude will be the East/West angle from the prime meridian
/// 
/// Latitude
/// Degree Range    Radian Range
/// (-90, 90)       (-pi/2, pi/2)
/// 
/// Longitude
/// Degree Range    Radian Range
/// (-180, 180)     (-pi, pi)
/// </summary>
public class GeographicCoordinatesTextDisplay : MonoBehaviour
{
    [SerializeField, Tooltip("Latitude is from 0 to 90 North or South")]
    private Text latitudeText; // from 0 to 90 North or South
    [SerializeField, Tooltip("Longitude is from 0 to 180 East or West")]
    private Text longitudeText;

    [SerializeField]
    private CoordinatesDisplayFormat coordinateDisplayFormat;

    private string latitudePrecisionFormatStringWithSigns = "+000.00000;-#000.00000";
    private string longitudePrecisionFormatStringWithSigns = "+000.00000;-#000.00000"; // add ;0 ... if dont want zero to have sign'
    private string latitudePrecisionFormatString = "000.00000;#000.00000";
    private string longitudePrecisionFormatString = "000.00000;#000.00000";

    public enum CoordinatesDisplayFormat
    {
        NumbersWithSigns, // with +, -,  use format "+000.00000;-#000.00000";
        NumbersAndLetters, // instead of signs, use N/S and E/W, use format "000.00000;#000.00000";  and append 
    }

    public void SetLatitudeText(string value)
    {
        latitudeText.text = value;
    }
    public void SetLongitudeText(string value)
        => longitudeText.text = value;
    public string FormatLatitudeFromFloat(float value)
    {
        string latitudeString = "";
        if (value >= 0)
        {
            // should be North 
            // check within latitude range limits, could be omitted if known within limits to save a calculation?
            if(value<= 90)
            {
                // valid
                switch(coordinateDisplayFormat)
                {
                    case CoordinatesDisplayFormat.NumbersWithSigns:
                        latitudeString = value.ToString(latitudePrecisionFormatStringWithSigns);
                        break;
                    case CoordinatesDisplayFormat.NumbersAndLetters:
                        latitudeString = value.ToString(latitudePrecisionFormatString) + " N";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Debug.LogWarning("Larger than 90 degree latitude given");
                // could do additional math to find for example for values
                // 91 = 89 N, 92 = 88 N, 120 = 60 N, 180 = 0 N, 181 = 1 S, 269 = 89 S, 271 = 89 S, 300 = 60 S, 359 = 1 S
            }
        }
        else
        {
            // should be South
            // check within latitude range limits, could be omitted if known within limits to save a calculation?
            if (value >= -90)
            {
                // valid
                    
                // valid
                switch (coordinateDisplayFormat)
                {
                    case CoordinatesDisplayFormat.NumbersWithSigns:
                        latitudeString = value.ToString(latitudePrecisionFormatStringWithSigns);
                        break;
                    case CoordinatesDisplayFormat.NumbersAndLetters:
                        latitudeString = value.ToString(latitudePrecisionFormatString) + " S";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Debug.LogWarning("Less than -90 degree latitude given");
            }
        }
        return latitudeString;
    }

    public string FormatLongitudeFromFloat(float value)
    {
        string longitudeString = "";
        if(value >= 0)
        {
            // is EAST
            // check within longitude range limits, could be omitted if known within limits to save a calculation?
            if (value <= 180)
            {
                // valid
                switch (coordinateDisplayFormat)
                {
                    case CoordinatesDisplayFormat.NumbersWithSigns:
                        longitudeString = value.ToString(longitudePrecisionFormatStringWithSigns);
                        break;
                    case CoordinatesDisplayFormat.NumbersAndLetters:
                        longitudeString = value.ToString(longitudePrecisionFormatString) + " E";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Debug.LogWarning("Larger than 180 degree longitude given");
            }
        }
        else
        {
            // is WEST
            // check within longitude range limits, could be omitted if known within limits to save a calculation?
            if (value >= -180)
            {
                // valid
                // valid
                switch (coordinateDisplayFormat)
                {
                    case CoordinatesDisplayFormat.NumbersWithSigns:
                        longitudeString = value.ToString(longitudePrecisionFormatStringWithSigns);
                        break;
                    case CoordinatesDisplayFormat.NumbersAndLetters:
                        longitudeString = value.ToString(longitudePrecisionFormatString) + " W";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Debug.LogWarning("Less than -180 degree longitude given");
            }
        }
        return longitudeString;
    }

    public void FormatAndSetLatitudeFromFloat(float value)
    {
        latitudeText.text = FormatLatitudeFromFloat(value);
    }
    public void FormatAndSetLongitudeFromFloat(float value)
    {
        longitudeText.text = FormatLongitudeFromFloat(value);
    }
}
