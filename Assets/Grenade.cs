using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 5f;
    public float explosionForce = 100f;
    public AudioSource explosionSound;

    private float countDown;
    bool hasExploded = false;

    public GameObject explosionEffect;


    void Start()
    {
        countDown = delay;
        explosionSound = GetComponent<AudioSource>();
    }

 
    void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach(Collider nearObject in colliders)
        {
           Rigidbody rb = nearObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
                explosionSound.Play();
            }
        }

        Destroy(gameObject);
    }
}
