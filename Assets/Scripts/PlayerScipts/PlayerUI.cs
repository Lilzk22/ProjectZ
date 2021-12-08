using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text healthAmount;
    public Text staminaAmount;

    private CharacterStats playerStats;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public void SetStats()
    {
        healthAmount.text = playerStats.currentHealth.ToString();
        staminaAmount.text = playerStats.currStamina.ToString();
    }
}
