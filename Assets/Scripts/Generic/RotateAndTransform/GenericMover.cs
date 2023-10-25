using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMover : MonoBehaviour
{
    [SerializeField]
    private Transform movedObject;
    [SerializeField]
    private float duration = 1f; // in seconds
    [SerializeField]
    private Vector3 startingPositon;
    [SerializeField]
    private Vector3 targetPosition;

    private Vector3 targetPositionNextIteration;
    private Vector3 targetPositionDifference;
    private Vector3 fixerVector;

    private float timer = 0f;

    [SerializeField]
    private bool isBeginMovementOnStart = true;
    [SerializeField]
    private bool isMovedObjectInitialPositionStartingPostion = false;
    [SerializeField]
    private bool isTargetPositionRelativeToMovedObjectInitialPosition = false;
    [SerializeField]
    private bool isLooping = false;
    [SerializeField]
    private bool isPingPong = false;

    private bool isFowardProgress = true;

    void Start()
    {
        if(isMovedObjectInitialPositionStartingPostion)
        {
            startingPositon = movedObject.position;
        }
        if(isTargetPositionRelativeToMovedObjectInitialPosition)
        {
            targetPosition = targetPosition + movedObject.position; // calculate target position by adding vectors
        }
        if(isBeginMovementOnStart)
        {
            BeginMovement();
        }
    }

    public void BeginMovement()
    {
        targetPositionDifference = targetPosition - startingPositon;
        fixerVector = startingPositon;
        //Debug.Log("targetPositionDifference = " + targetPositionDifference);
        //Debug.Log("fixerVector = " + fixerVector);
        StartCoroutine("MovementCoroutine");
    }

    private IEnumerator MovementCoroutine()
    {
        timer = 0f;
        //Debug.Log("Time has taken for movement corutine duration for " + this.name + " = " + timer);
        float progess = timer / duration; // 0 duration is error

        while (timer < duration)
        {
            timer += Time.deltaTime;
            progess = timer / duration;
            //Debug.Log("timer is " + timer.ToString());
            //Debug.Log("Progess is " + progess.ToString());
            targetPositionNextIteration = (targetPositionDifference * progess) + fixerVector ;

            //Debug.Log("targetPositionNextIteration is " + targetPositionNextIteration.ToString());
            movedObject.position = targetPositionNextIteration;

            yield return null;
        }

        // Start Coroutine again if looping
        if (isLooping)
        {
            if(isPingPong)
            {
                targetPositionDifference = -targetPositionDifference;
                if (isFowardProgress)
                {
                    fixerVector = targetPosition;
                }
                else
                {
                    fixerVector = startingPositon;
                }
                isFowardProgress = !isFowardProgress;
            }
            StartCoroutine("MovementCoroutine");
        }

        yield return null;
    }
}
