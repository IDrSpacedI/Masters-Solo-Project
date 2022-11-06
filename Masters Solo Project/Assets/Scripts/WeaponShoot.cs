using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{

    private float lastShootTime = 0;

    private Camera cam;
    private Inventory inventory;
    private EquipmentManager manager;
    


    private void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }
    }

    private void RaycastShoot(Weapon currentWeapon)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        float currentWeaponRange = currentWeapon.range;

        if (Physics.Raycast(ray, out hit, currentWeaponRange))
        {
            Debug.Log(hit.transform.name);
        }

        Instantiate(currentWeapon.MuzzleFlashPartical, manager.currentWeaponBarrel);
    }

    private void shoot()
    {
        Weapon currentWeapon = inventory.GetItem(manager.currentlyEquipedWeapon);

        if(Time.time > lastShootTime + currentWeapon.fireRate)
        {
            lastShootTime = Time.time;

            RaycastShoot(currentWeapon);


        }

    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
    }
}
