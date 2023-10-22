using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OICompassRotator : MonoBehaviour
{
    [SerializeField]
    private OrientationInformer orientationInformer;
    [SerializeField]
    private CompassDisplayRotator compassDisplayRotator;

    [SerializeField]
    private bool isUpdating = true;

    private void Update()
    {
        if(isUpdating)
        {
            compassDisplayRotator.SetCompassByDegree(orientationInformer.DirectionLookingToCompassDegrees());
        }
    }
}
