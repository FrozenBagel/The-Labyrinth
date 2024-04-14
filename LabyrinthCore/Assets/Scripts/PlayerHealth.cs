using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Slider healthSlider; 
    public Gradient healthGradient;
    public GameObject healthBar;
    public MonoBehaviour movement;


    public ParticleSystem bloodParticles;

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

        EmitBloodParticles();
    }

    void Die()
    {
        Destroy(healthBar);
        movement.enabled = false;
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;

        healthSlider.fillRect.GetComponent<Image>().color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }

    void EmitBloodParticles()
    {
        bloodParticles.transform.position = transform.position;
        bloodParticles.Play();
    }
}