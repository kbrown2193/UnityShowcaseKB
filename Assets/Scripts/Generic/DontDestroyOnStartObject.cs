using UnityEngine;

public class DontDestroyOnStartObject : MonoBehaviour
{
    // This method is called when the script is initialized
    private void Awake()
    {
        // Ensure that this GameObject persists across scene changes
        DontDestroyOnLoad(this.gameObject);
    }
}
