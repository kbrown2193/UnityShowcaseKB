using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericScaler : MonoBehaviour
{
    [SerializeField]
    private Transform scaledObject;
    [SerializeField]
    private float duration = 1f; // in seconds
    [SerializeField]
    private Vector3 startingScale = Vector3.one;
    [SerializeField]
    private Vector3 targetScale = Vector3.one;

    private Vector3 initialStartingScale = Vector3.one;
    private Vector3 initialTargetScale = Vector3.one;
    private Vector3 nextIterationScale = Vector3.one;

    [SerializeField]
    private bool isPlayingOnStart = true;
    [SerializeField]
    private bool isLooping = false;
    [SerializeField]
    private bool isPingPong = false;

    private bool isFowardProgress = true;

    void Start()
    {
        initialStartingScale = startingScale;
        initialTargetScale = targetScale;

        if (isPlayingOnStart)
        {
            BeginScaling();
        }
    }

    public void BeginScaling()
    {
        StartCoroutine("ScalingCoroutine");
    }

    private IEnumerator ScalingCoroutine()
    {
        // INITIAL ACTIONS
        float progress = 0f;
        float timer = 0f;

        // LOOPING ACTIONS
        while (progress < 1)
        {
            timer += Time.deltaTime;
            progress = timer / duration;
            //Debug.Log("Progress = " + progress);
            nextIterationScale = ((targetScale - startingScale) * progress) + startingScale;
            scaledObject.localScale = nextIterationScale;

            //Debug.Log("Next Iteration Scaler = " + nextIterationScale);

            yield return null;
        }

        // Start Coroutine again if looping
        if (isLooping)
        {
            if(isPingPong)
            {
                if(isFowardProgress)
                {
                    startingScale = initialTargetScale;
                    targetScale = initialStartingScale;
                }
                else
                {
                    startingScale = initialStartingScale;
                    targetScale = initialTargetScale;
                }
                isFowardProgress = !isFowardProgress;
            }

            StartCoroutine("ScalingCoroutine");
        }

        yield return null;
    }
}
