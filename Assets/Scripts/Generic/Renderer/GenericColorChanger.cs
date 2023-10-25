using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericUnityUtilityKB
{
    public class GenericColorChanger : MonoBehaviour
    {
        [SerializeField]
        private Renderer changedRenderer;

        [SerializeField]
        private float duration;

        [SerializeField]
        private Color startingColor = Color.black;
        [SerializeField]
        private Color targetColor = Color.white;

        private Color initialStartingColor = Color.black;
        private Color initialTargetColor = Color.white;

        [SerializeField]
        private string materialColorName = "_Color";

        private Color nextIterationColor = Color.white;

        [SerializeField]
        private bool isPlayingOnStart = true;
        [SerializeField]
        private bool isLooping = false;
        [SerializeField]
        private bool isPingPong = false;

        private bool isFowardProgress = true;

        void Start()
        {
            initialStartingColor = startingColor;
            initialTargetColor = targetColor;
            if (isPlayingOnStart)
            {
                BeginColorChange();
            }
        }

        public void BeginColorChange()
        {
            StartCoroutine("ColorChangingCoroutine");
        }

        private IEnumerator ColorChangingCoroutine()
        {
            float progress = 0f;
            float timer = 0f;
            timer = 0f;
            if(duration <= 0f)
            {
                progress = 1f;
                nextIterationColor = targetColor;
                changedRenderer.material.SetColor(materialColorName, nextIterationColor);
            }

            while (progress < 1)
            {
                timer += Time.deltaTime;
                progress = timer / duration;
                //Debug.Log("Progress = " + progress);
                nextIterationColor = ((targetColor - startingColor) * progress) + startingColor;
                changedRenderer.material.SetColor(materialColorName, nextIterationColor);

                //Debug.Log("Next Iteration Color = " + nextIterationColor);

                yield return null;
            }
            // Start Coroutine again if looping
            if (isLooping)
            {
                if (isPingPong)
                {
                    if (isFowardProgress)
                    {
                        startingColor = initialTargetColor;
                        targetColor = initialStartingColor;
                    }
                    else
                    {
                        startingColor = initialStartingColor;
                        targetColor = initialTargetColor;
                    }
                    isFowardProgress = !isFowardProgress;
                }

                StartCoroutine("ColorChangingCoroutine");
            }

            yield return null;
        }
    }
}
