using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoints : MonoBehaviour
{
    public float pointsToAdd;
    PlayerPoints playerPoints;

    public void Start()
    {
        playerPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPoints>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerPoints.currScore += pointsToAdd;
            Destroy(gameObject);
        }
    }
}
