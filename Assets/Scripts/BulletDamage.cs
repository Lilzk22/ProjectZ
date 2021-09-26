using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int bulletStrength;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zombie")
        {
            GetComponent<EnemyStats>();
            //EnemyStats.maxHealth -= bulletStrength;
        }
    }
}
