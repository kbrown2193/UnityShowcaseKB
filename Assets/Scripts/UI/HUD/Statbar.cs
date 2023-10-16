using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statbar : MonoBehaviour
{
    [SerializeField]
    private Image fillImage; // the fill of the statbar

    [SerializeField]
    private DisplayOrientation orientation = DisplayOrientation.Horizontal;
    [SerializeField]
    private FillImplementation fillImplementation;

    public enum DisplayOrientation
    {
        Horizontal, // left is min, right is max
        Vertical, // bottom is min, top is max
        HorizontalReverse, // left is max, right is min
        VerticalReverse, // bottom is max, top is min
    }

    public enum FillImplementation
    {
        Scaling, // scale image from zero to 1
        Masking, // TODO: move a mask
        SpriteSetting, // TODO: Set a sprite for each value
        SpriteFlipbook // TODO: Set a sprite from a flipbook

    }

    /// <summary>
    /// Normalized, should always send a value in range from zero to 1 currently...
    /// </summary>
    /// <param name="value"></param>
    public void SetFillValue(float value)
    {
        switch (fillImplementation)
        {
            case FillImplementation.Scaling:
                switch (orientation)
                {
                    case DisplayOrientation.Horizontal:
                        fillImage.rectTransform.pivot = new Vector2(0f, 0.5f);
                        fillImage.rectTransform.localScale = new Vector2(value, 1);
                        break;
                    case DisplayOrientation.Vertical:
                        fillImage.rectTransform.pivot = new Vector2(0.0f, 0f);
                        fillImage.rectTransform.localScale = new Vector2(1, value);
                        break;
                    case DisplayOrientation.HorizontalReverse:
                        fillImage.rectTransform.pivot = new Vector2(1f, 0.5f);
                        fillImage.rectTransform.localScale = new Vector2(value, 1);
                        break;
                    case DisplayOrientation.VerticalReverse:
                        fillImage.rectTransform.pivot = new Vector2(0.0f, 1f);
                        fillImage.rectTransform.localScale = new Vector2(1, value);
                        break;
                    default:
                        Debug.LogWarning("Should never get here");
                        break;
                }
                break;
            default:
                Debug.LogWarning("No Fill Implementation ...");
                break;
        }
    }
}
