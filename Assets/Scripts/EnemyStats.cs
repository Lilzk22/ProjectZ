using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public float scoreAddAmount = 10;

    Spawner spawn;
    //public Animator anim;

    GameController gameController;
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        spawn = gameController.GetComponentInChildren<Spawner>();
       // anim.GetComponent<Animator>();

        maxHealth = 100;
        currentHealth = maxHealth;
    }
    private void Update()
    {
        CheckHealth();
    }
    public override void Die()
    {
        gameController.AddScore(scoreAddAmount);
        spawn.enemiesKilled++;
        //anim.SetBool("isDead", true);
        Destroy(gameObject);    
    }
}