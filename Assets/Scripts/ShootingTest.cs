using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTest : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            var instance = Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            instance.GetComponent<Rigidbody>().AddForce((bulletSpawn.transform.forward) * speed);
        }
    }
}
