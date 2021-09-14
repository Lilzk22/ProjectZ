using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth;
    public float  currentHealth;

    public float currStamina;
    public float maxStamina;

    public bool isDead = false;

    public virtual void CheckHealth()
    {
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            Die();
        }
    }

    public virtual void CheckStamina()
    {
        if(currStamina >= maxStamina)
        {
            currStamina = maxStamina;
        }
        
        if(currStamina <= 0)
        {
            currStamina = 0;
        }
    }
    public virtual void Die()
    {

    }
    public void TakeDamage(float damage)
    {
       currentHealth -= damage;
    }
}