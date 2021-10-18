using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Type")]
public class WeaponType : ScriptableObject
{
    [Tooltip("The weapon's name as displayed in-game.")]
    public string displayName;

    [Tooltip("The weapon's model. Spawned in the player's hand when equipped.")]
    public GameObject modelPrefab;
    
    [Tooltip("The sound played when the weapon is equipped.")]
    public AudioClip equipSound;

    [Tooltip("The amount of ammo the weapon can hold.")]
    public int maxAmmo;
}
