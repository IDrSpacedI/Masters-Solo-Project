using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder = null;

    private Inventory inventory;

    private void Start()
    {
        getReferences();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            setWeaponAnimation(0, WeaponType.Shotgun);
            EquipWeapon(inventory.GetItem(0).prefab, 0);
        }
    }

    private void setWeaponAnimation(int weaponStyle, WeaponType weaponType)
    {
        Weapon weapon = inventory.GetItem(weaponStyle);
    }

    private void EquipWeapon(GameObject weaponObject, int weaponStyle)
    {
        Weapon weapon = inventory.GetItem(weaponStyle);
        if(weapon != null)
        {
            Instantiate(weaponObject, weaponHolder);
        }
        
    }

    private void getReferences()
    {
        inventory = GetComponent<Inventory>();
    }
}
