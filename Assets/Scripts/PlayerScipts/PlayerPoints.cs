using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public float currScore;
    public Text pointText;

    private void Start()
    {
        currScore = 0;
    }
    private void Update()
    {
        pointText.text = " " + currScore;
    }

    public void AddScore(float amount)
    {
        currScore += amount;
    }
}
