using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaName : MonoBehaviour
{
    [SerializeField]
    private string areaName;

    public Text regionText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            regionText.text = areaName;
        }
    }
}
