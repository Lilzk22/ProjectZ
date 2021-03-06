using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour
{
    public float health = 50f;
    public float pointsToAdd;
    PlayerPoints playerPoints;

    public void Start()
    {
        playerPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPoints>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        playerPoints.AddScore(pointsToAdd);
        Destroy(gameObject);
    }
}