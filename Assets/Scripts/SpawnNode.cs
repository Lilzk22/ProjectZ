using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour
{
    public static List<SpawnNode> activeNodes = new List<SpawnNode>();

    private void OnEnable(){
        activeNodes.Add(this);
    }
    private void OnDisable(){
        activeNodes.Remove(this);
    }

    [SerializeField, Tooltip("The higher this number, the more likely this node will be chosen to spawn enemies.")]
    public int weight;
}
