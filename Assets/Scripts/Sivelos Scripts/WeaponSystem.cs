using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    //Change this to change how many weapons you can carry
    private const int weaponCount = 2; 
    public WeaponInstance[] weapons = new WeaponInstance[weaponCount];

    private int weaponIndex;

    public WeaponInstance currentWeapon{
        get{
            return weapons[weaponIndex];
        }
    }

    public int currentAmmo{
        get{
            return weapons[weaponIndex].ammoCount;
        }
    }

    public void SetWeaponIndex(int index){
        index = Mathf.Clamp(index, 0, weaponCount - 1);
        weaponIndex = index;
        OnWeaponChange(weapons[index].weaponType);
    }
    
    public void SetWeapon(int index, WeaponType weapon){
        try
        {
             weapons[index] = new WeaponInstance(weapon);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Debug.LogErrorFormat("WeaponSystem: index {0} is out of range (weapon array capacity is {1}).", new object[]{
                index,
                weapons.Length
            });
            throw;
        }
    }
    public void SetWeapon(int index, WeaponType weapon, int ammo){
        try
        {
             weapons[index] = new WeaponInstance(weapon, ammo);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Debug.LogErrorFormat("WeaponSystem: index {0} is out of range (weapon array capacity is {1}).", new object[]{
                index,
                weapons.Length
            });
            throw;
        }
    }
    //Returns true if successfully fired. Returns false otherwise (out of ammo)
    public bool OnFire(WeaponInstance weapon){
        if(!weapon.weaponType){
            return false;
        }
        if(weapon.ammoCount > 0){
            //==============================//
            string weaponName = weapon.weaponType.displayName.ToUpper();
            switch (weaponName)
            {
                //firing logic goes here
                case "GUN":
                //spawn bullet or w/e you know what to do here
                weapon.ammoCount -= 1; //deduct ammo
                return true; //make sure to end with return true
                default:
                return true;
            }
            //=============================//
        }
        return false;
    }
    
    private void OnWeaponChange(WeaponType weapon){
        if(!weapon){
            return;
        }
        string weaponName = weapon.displayName.ToUpper();
        switch (weaponName)
        {
            //firing logic goes here
            case "GUN":
            //spawn bullet or w/e you know what to do here
            break;
            default:
            break;
        }
    }

    public struct WeaponInstance{
        public WeaponType weaponType {get; private set;}
        public int ammoCount;
        
        public WeaponInstance(WeaponType type){
            this.weaponType = type;
            ammoCount = type.maxAmmo;
        }
        public WeaponInstance(WeaponType type, int startingAmmo){
            this.weaponType = type;
            ammoCount = Mathf.Min(startingAmmo, type.maxAmmo);
        }
    }
}
