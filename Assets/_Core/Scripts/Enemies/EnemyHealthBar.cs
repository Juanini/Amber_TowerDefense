using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform healthBarSprite;
    private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        float healthPercentage = currentHealth / maxHealth;
        // Ajustar la escala en el eje X para representar la salud restante
        healthBarSprite.localScale = new Vector3(healthPercentage, 1f, 1f);
    }
}