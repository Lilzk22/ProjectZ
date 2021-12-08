using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkPopUp : MonoBehaviour
{
    public GameObject perkUi;
    public float perkPrice;
    public bool hasPerk;
    PlayerPoints playerPoints;
    public void Start()
    {
        playerPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPoints>();

        perkUi.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasPerk)
        {
            perkUi.SetActive(true);

            if (playerPoints.currScore >= perkPrice && Input.GetKey(KeyCode.E))
            {
                playerPoints.currScore -= perkPrice;
                hasPerk = true;
                perkUi.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && !hasPerk)
        {
            perkUi.SetActive(false);
        }
    }
}
