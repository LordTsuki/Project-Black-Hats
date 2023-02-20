using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerAttributesObject status;
    private Slider healthBar;
    void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        healthBar.maxValue = status.maxHealth;
        healthBar.value = status.health;
    }
}