using UnityEngine;
using UnityEngine.UI;

public class LatitudeNumbersVerticalScroll : MonoBehaviour
{
    [SerializeField]
    private NumberTextureVerticalScroll wholeNumberOnes; // NumberTextureVerticalScroll component for the ones digit of the latitude
    [SerializeField]
    private NumberTextureVerticalScroll wholeNumberTens; // NumberTextureVerticalScroll component for the tens digit of the latitude
    [SerializeField]
    private NumberTextureVerticalScroll[] fractionalNumbers; // NumberTextureVerticalScroll components for the fractional numbers (5 in total)
    [SerializeField]
    private LatitudeDirectionImage latitudeDirectionImage; // LatitudeDirectionImage component representing the direction of the latitude

    public void SetLatitude(float latitude)
    {
        int latitudeValue = Mathf.FloorToInt(Mathf.Abs(latitude));
        int onesDigit = latitudeValue % 10;
        int tensDigit = latitudeValue / 10;

        wholeNumberOnes.SetNumberRounded(onesDigit);
        wholeNumberTens.SetNumberRounded(tensDigit);

        float fractionalPart = Mathf.Abs(latitude) - latitudeValue;
        SetFractionalNumbers(fractionalPart);

        SetLatitudeDirection(latitude);
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

    private void SetLatitudeDirection(float latitude)
    {
        if (latitude >= 0f)
        {
            latitudeDirectionImage.SetDirectionImage(LatitudeDirection.North);
        }
        else
        {
            latitudeDirectionImage.SetDirectionImage(LatitudeDirection.South);
        }
    }
}
