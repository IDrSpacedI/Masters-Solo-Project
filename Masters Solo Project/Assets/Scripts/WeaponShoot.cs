using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{

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
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("pew pew");
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        float currentWeaponRange = inventory.GetItem(manager.currentlyEquipedWeapon).range;

        if (Physics.Raycast(ray, out hit, currentWeaponRange))
        {
            Debug.Log(hit.transform.name);
        }

       
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
    }
}
