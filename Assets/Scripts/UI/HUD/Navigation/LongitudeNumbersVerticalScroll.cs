using UnityEngine;
using UnityEngine.UI;

public class LongitudeNumbersVerticalScroll : MonoBehaviour
{
    [SerializeField]
    private NumberTextureVerticalScroll wholeNumberOnes; // NumberTextureVerticalScroll component for the ones digit of the longitude
    [SerializeField]
    private NumberTextureVerticalScroll wholeNumberTens; // NumberTextureVerticalScroll component for the tens digit of the longitude
    [SerializeField]
    private NumberTextureVerticalScroll wholeNumberHundreds; // NumberTextureVerticalScroll component for the hundreds digit of the longitude
    [SerializeField]
    private NumberTextureVerticalScroll[] fractionalNumbers; // NumberTextureVerticalScroll components for the fractional numbers (5 in total)
    [SerializeField]
    private LongitudeDirectionImage longitudeDirectionImage; // LongitudeDirectionImage component representing the direction of the longitude

    public void SetLongitude(float longitude)
    {
        int longitudeValue = Mathf.FloorToInt(Mathf.Abs(longitude));
        int onesDigit = longitudeValue % 10;
        int tensDigit = (longitudeValue / 10) % 10;
        int hundredsDigit = longitudeValue / 100;

        wholeNumberOnes.SetNumberRounded(onesDigit);
        wholeNumberTens.SetNumberRounded(tensDigit);
        wholeNumberHundreds.SetNumberRounded(hundredsDigit);

        float fractionalPart = Mathf.Abs(longitude) - longitudeValue;
        SetFractionalNumbers(fractionalPart);

        SetLongitudeDirection(longitude);
    }

    private void SetFractionalNumbers(float fractionalPart)
    {
        for (int i = 0; i < fractionalNumbers.Length; i++)
        {
            fractionalPart *= 10f;
            int digit = Mathf.FloorToInt(fractionalPart) % 10;
            fractionalPart -= digit;
            fractionalNumbers[i].SetNumberRounded(digit);
        }
    }

    private void SetLongitudeDirection(float longitude)
    {
        if (longitude >= 0f)
        {
            longitudeDirectionImage.SetDirectionImage(LongitudeDirection.East);
        }
        else
        {
            longitudeDirectionImage.SetDirectionImage(LongitudeDirection.West);
        }
    }
}
