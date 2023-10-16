using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerDisplay : MonoBehaviour
{
    [SerializeField]
    private Image needleImage;

    [SerializeField]
    private Image markingsImage;

    [SerializeField]
    private Image numbersImage;

    [SerializeField]
    private Image rimImage;

    [SerializeField]
    [Tooltip("This is the left most rotation (Z)")]
    private float minimumRotationAngle = 0f;

    [SerializeField]
    [Tooltip("This is the right most rotation (Z)")]
    private float maximumRotationAngle = -215f;

    private Vector3 rotationAngleVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        CalculateRotationDirection();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSpeedFromZeroToOne(float value)
    {
        // todo
    }
    public void SetSpeedMPH(float value)
    {

    }
    public void SetSpeedKMH(float value)
    {

    }

    public void SetRotationAngle(float value)
    {
        rotationAngleVector.z = value;
        needleImage.rectTransform.rotation = Quaternion.Euler(rotationAngleVector);
    }

    public void CalculateRotationDirection()
    {
        if(maximumRotationAngle > minimumRotationAngle)
        {
            //Debug.Log("Max rotation angle is > GREATER than minimum...so rotating counter clockwise");
        }
        else
        {

            //Debug.Log("Max rotation angle is < LESS than minimum... so rotating clockwise");
            // i.e. -215 for  max rotation with a 0 min rotation, 
            // so if normalizing from 0 to 1, then 1 would be to apply a - rotation;????

        }
    }
}
