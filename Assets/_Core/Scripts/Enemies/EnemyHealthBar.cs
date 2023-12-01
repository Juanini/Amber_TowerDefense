using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform healthBarSprite;
    private float maxHealth = 100f;
    private float currentHealth;

    public void Init(float _health)
    {
        maxHealth = _health;
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
        healthBarSprite.localScale = new Vector3(healthPercentage, 1f, 1f);
    }
}