using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    PlayerUI playerUI;

    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();

        maxHealth = 100;
        currentHealth = maxHealth;

        maxStamina = 100;
        currStamina = maxStamina;
    }

    public override void Die()
    {
        Debug.Log("DEAD");
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
    }

    public override void CheckStamina()
    {
        base.CheckStamina();
    }
}