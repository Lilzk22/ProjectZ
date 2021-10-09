using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float damage;

    [SerializeField]
    float stoppingDistance;

    float lastAttackTime = 0;
    float attackCoolDown = 2;

    public NavMeshAgent agent;
    public GameObject target;

    [SerializeField]
    private AnimatorControllerList animatorControllerList;

    public Animator anim;

    private void Start()
    {
        agent.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        anim.GetComponent<Animator>();
        GetAnimatorController();
    }

    private void GetAnimatorController(){
        if(this.animatorControllerList){
            if(this.anim){
                this.anim.runtimeAnimatorController = this.animatorControllerList.GetAnimatorController();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GetComponent<PlayerStats>().maxHealth -= damage;
        }
    }

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist < stoppingDistance)
        {
            StopEnemy();
            Attack();
        }
        else
        {
            FindPlayer();
        }
    }
    private void FindPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", true);
    }
    private void StopEnemy()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
    }
    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            lastAttackTime = Time.time;
            target.GetComponent<CharacterStats>().TakeDamage(damage);
            target.GetComponent<CharacterStats>().CheckHealth();
        }
    }
}


/*
Duplicated for safety reasons

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float damage;
    [SerializeField]
    float stoppingDistance;

    float lastAttackTime = 0;
    float attackCoolDown = 2;

    public NavMeshAgent agent;
    public GameObject target;
    public Animator anim;
    private void Start()
    {
        agent.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        anim.GetComponent<Animator>();
    }
    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if(dist < stoppingDistance)
        {
            StopEnemy();
            Attack();
        }
        else
        {
            FindPlayer();
        }
    }
    private void FindPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", true);
    }
    private void StopEnemy()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);
    }
    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            lastAttackTime = Time.time;
            target.GetComponent<CharacterStats>().TakeDamage(damage);
            target.GetComponent<CharacterStats>().CheckHealth();
        }
    }
}
*/