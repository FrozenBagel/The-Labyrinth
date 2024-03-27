using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; 
    private float currentHealth;

    public Slider healthSlider; // Reference to the UI slider for the health bar
    public Gradient healthGradient; // Gradient to define the color shift for the health bar

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); 
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; 
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;

        healthSlider.fillRect.GetComponent<Image>().color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}