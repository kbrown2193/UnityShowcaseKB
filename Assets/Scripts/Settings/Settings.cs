using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private VideoSettings videoSettings;
    [SerializeField] private AudioSettings audioSettings;
    [SerializeField] private ControlSettings controlSettings;
    [SerializeField] private GameSettings gameSettings;

    private void Awake()
    {
        // Ensure that this GameObject persists across scene changes
        DontDestroyOnLoad(this.gameObject);
    }
}
