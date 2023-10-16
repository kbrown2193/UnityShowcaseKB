using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassDisplayTextureScroller : MonoBehaviour
{
    [SerializeField]
    private Image compassImage; // the image to scale the offset for X Tiling.   (should be a size of (0.25, 1))
    [SerializeField]
    private Image compassFrame;  // the overlay frame
    [SerializeField]
    private Image compassBackground; // the background image / fill image

    const float DEGREES_TO_ONE_SCALE_DIVIDER = 360f;
    const float OFFSET_INITIAL = -0.125f; // at a tiling of 0.25 and offset of 0, the degree centered on is 45 degrees, to make it 0 would need to offset by - .125

    /// <summary>
    /// Pass in a number from 0 to 360 to set the texture scaling of the compass image display
    /// </summary>
    /// <param name="value"></param>
    public void SetCompassByDegree(float value)
    {
        // should range from 0 to 360 (if is greater or less than, divide it?)
        Vector2 compassVector = new Vector2((value / DEGREES_TO_ONE_SCALE_DIVIDER) + OFFSET_INITIAL, 0f); // convert degree to a zero to one scale... i.e divide by 360, and also add a zeropoint initial offset
        compassImage.material.mainTextureOffset = compassVector;
    }
}
