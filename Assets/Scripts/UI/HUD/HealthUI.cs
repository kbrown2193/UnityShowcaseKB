using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Statbar healthStatBar;
    [SerializeField]
    private TextMeshProUGUI healthText;

    public float defaultHealthValue = 100; // for TESTING: the health value
    public float defaultHealthMax = 100; // for TESTING: the  maximum health

    void Start()
    {
        // TESTING
        RefreshHealthUI(defaultHealthValue, defaultHealthMax);
    }


    public void RefreshHealthUI(float health)
    {
        healthStatBar.SetFillValue(health / defaultHealthMax);
        healthText.text = health.ToString("##0.##") + " / " + defaultHealthMax.ToString();
    }

    public void RefreshHealthUI(float health, float healthMax)
    {
        healthStatBar.SetFillValue(health/healthMax);
        healthText.text = health.ToString() + " / " + healthMax.ToString();
    }
}
