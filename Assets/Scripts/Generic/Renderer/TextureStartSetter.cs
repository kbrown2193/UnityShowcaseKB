using UnityEngine;

public class TextureStartSetter : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    [Tooltip("The renderer component to modify.")]
    private Renderer targetRenderer;

    [SerializeField]
    [Tooltip("The texture to assign to the material.")]
    private Texture2D texture;

    [SerializeField]
    [Tooltip("The index of the material in the renderer's materials array.")]
    private int materialIndex;

    [SerializeField]
    [Tooltip("The scaling factor for the texture.")]
    private Vector2 textureScale = new Vector2(1f, 1f);
    #endregion

    #region MonoBehaviour Callbacks
    private void Start()
    {
        if (targetRenderer != null)
        {
            Material[] materials = targetRenderer.materials;

            if (materialIndex >= 0 && materialIndex < materials.Length)
            {
                materials[materialIndex].mainTexture = texture;
                materials[materialIndex].mainTextureScale = textureScale;
                targetRenderer.materials = materials;
            }
            else
            {
                Debug.LogError("Invalid material index!");
            }
        }
        else
        {
            Debug.LogError("Renderer component not found!");
        }
    }
    #endregion
}
