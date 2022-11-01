using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public int currentlyEquipedWeapon = 0;
    private GameObject currentWeaponObject = null;

    [SerializeField] private Transform weaponHolder = null;

    private Inventory inventory;

    private void Start()
    {
        getReferences();
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    setWeaponAnimation(0, WeaponType.Shotgun);
        //    InstantiateWeapon(inventory.GetItem(0).prefab, 0);
        //}


        //weapon slot 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UnequipWeapon();
            EquipWeapon(inventory.GetItem(0));
        }


    }

    //private void setWeaponAnimation(int weaponStyle, WeaponType weaponType)
    //{
    //    Weapon weapon = inventory.GetItem(weaponStyle);
    //}

    //private void InstantiateWeapon(GameObject weaponObject, int weaponStyle)
    //{
    //    Weapon weapon = inventory.GetItem(weaponStyle);
    //    if(weapon != null)
    //    {
    //        currentWeaponObject = Instantiate(weaponObject, weaponHolder);
    //    }
        
    //}

    private void EquipWeapon(Weapon weapon)
    {
        currentlyEquipedWeapon = (int)weapon.WeaponStyle;
        Instantiate(weapon.prefab, weaponHolder);
    }

    private void UnequipWeapon()
    {
        Destroy(currentWeaponObject);
    }

    private void getReferences()
    {
        inventory = GetComponent<Inventory>();
    }
}
