using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongitudeDirectionImage : MonoBehaviour
{
    [SerializeField]
    private Image directionImage; // Image component representing the direction

    [SerializeField]
    private Sprite eastSprite; // Sprite for East direction
    [SerializeField]
    private Sprite westSprite; // Sprite for West direction

    public void SetDirectionImage(LongitudeDirection direction)
    {
        switch (direction)
        {
            case LongitudeDirection.East:
                directionImage.sprite = eastSprite;
                break;
            case LongitudeDirection.West:
                directionImage.sprite = westSprite;
                break;
        }
    }
}

public enum LongitudeDirection
{
    East,
    West
}
