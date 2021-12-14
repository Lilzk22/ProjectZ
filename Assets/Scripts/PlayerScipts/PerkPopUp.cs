using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkPopUp : MonoBehaviour
{
    public GameObject perkUi;
    public GameObject perkTrigger;
    public float perkPrice;
    public bool hasPerk, isInBounds, isBuyable;

    PlayerPoints playerPoints;
    public void Start()
    {
        playerPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPoints>();
        perkUi.SetActive(false);
        isBuyable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasPerk && isBuyable)
        {
            perkUi.SetActive(true);
            isInBounds = true;    
        }
    }

    private void Update()
    {
        if (isInBounds && Input.GetKeyDown(KeyCode.F) && playerPoints.currScore >= perkPrice)
        {
            playerPoints.currScore -= perkPrice;
            hasPerk = true;
            isBuyable = false;
            isInBounds = false;
            perkUi.SetActive(false);
            perkTrigger.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !hasPerk)
        {
            perkUi.SetActive(false);
            isInBounds = false;
        }
    }
}