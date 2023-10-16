using UnityEngine;
using UnityEngine.UI;

public class NumberTextureVerticalScroll : MonoBehaviour
{
    [SerializeField]
    private Image numberImage; // the image representing the number
    [SerializeField]
    private float yOffsetStep = 0.1f; // the vertical offset increment for each number

    private Image imageComponent;
    private Material numberMaterial;

    private void Start()
    {
        imageComponent = numberImage.GetComponent<Image>();
        numberMaterial = Instantiate(imageComponent.material);
        imageComponent.material = numberMaterial;
    }

    public void SetNumber(float number)
    {
        float yOffset = number * yOffsetStep;
        Vector2 numberVector = new Vector2(0f, yOffset);

        numberMaterial.mainTextureOffset = numberVector;
    }

    public void SetNumberRounded(float number)
    {
        int truncatedNumber = Mathf.Clamp(Mathf.RoundToInt(number), 0, 9);
        SetNumber(truncatedNumber);
    }
}
