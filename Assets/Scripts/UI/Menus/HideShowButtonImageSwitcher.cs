using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))] // This implementation is getting whatever image component this script is attached to
public class HideShowButtonImageSwitcher : MonoBehaviour
{
    [SerializeField]
    private Sprite hideMenuSprite;

    [SerializeField]
    private Sprite showMenuSprite;

    [SerializeField] // Expose for initial awake set
    private bool isHideMenuSprite = true;

    private Image image;        // Cache component

    void Awake()
    {
        image = GetComponent<Image>();
        SetImageBasedOnCurrentLogic();  // If needs to be controlled via other script, can disable this...
    }

    /// <summary>
    /// Sets the image to whatever the opposite bool value for what isHideMenuSprite is
    /// </summary>
    public void ToggleHideShowButtonImage()
    {
        if(isHideMenuSprite)
        {
            image.sprite = showMenuSprite;
            isHideMenuSprite = false;
        }
        else
        {
            image.sprite = hideMenuSprite;
            isHideMenuSprite = true;
        }
    }

    /// <summary>
    /// Sets the image to whatever the current bool value for what isHideMenuSprite is
    /// </summary>
    public void SetImageBasedOnCurrentLogic()
    {
        if (isHideMenuSprite)
        {
            image.sprite = hideMenuSprite;
        }
        else
        {
            image.sprite = showMenuSprite;
        }
    }
}
