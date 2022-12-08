using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int currentMaxHealth;
    private int currentHealth;

    public float publicCurrentHealth;
    public float publicMaxHealth;
    private void Start()
    {
        currentHealth = currentMaxHealth;
        publicCurrentHealth = currentHealth;
        publicMaxHealth = currentMaxHealth;
    }
    //присваиваем значение хп у юнита
    public HealthSystem(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;
            publicCurrentHealth=currentHealth;
            
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

}
