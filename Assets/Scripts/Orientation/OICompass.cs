using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OICompass : MonoBehaviour
{
    [SerializeField]
    private OrientationInformer orientationInformer;
    [SerializeField]
    private CompassDisplayTextureScroller compassDisplayTextureScroller;

    [SerializeField]
    private bool isUpdating = true;

    private void Update()
    {
        compassDisplayTextureScroller.SetCompassByDegree(orientationInformer.DirectionLookingToCompassDegrees());
    }
}
