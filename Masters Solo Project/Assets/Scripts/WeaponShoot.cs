using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{

    private float lastShootTime = 0;

    [SerializeField] private bool canShoot = true;
    public bool canReload = true;

    [SerializeField] private int primaryCurrentAmmo;
    [SerializeField] private int primaryCurrentAmmoStorage;

    [SerializeField] private int secondaryCurrentAmmo;
    [SerializeField] private int secondaryCurrentAmmoStorage;

    [SerializeField] private bool primaryMagazineIsEmpty = false;
    [SerializeField] private bool secondaryMagazineIsEmpty = false;

    private Camera cam;
    private Inventory inventory;
    private EquipmentManager manager;

    [SerializeField] private GameObject BloodPS = null;


    private void Start()
    {
        GetReferences();
        canShoot = true;
        canReload = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload(manager.currentlyEquipedWeapon);
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
            if(hit.transform.tag == "Enemy")
            {
                CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();
                enemyStats.TakeDamage(currentWeapon.damage);

                //spawn partical
                SpawnBloodPartical(hit.point);
            }
        }
        
        Instantiate(currentWeapon.MuzzleFlashPartical, manager.currentWeaponBarrel);
    }

    private void shoot()
    {
        CheckCanShoot(manager.currentlyEquipedWeapon);

        if (canShoot)
        {
            Weapon currentWeapon = inventory.GetItem(manager.currentlyEquipedWeapon);

            if (Time.time > lastShootTime + currentWeapon.fireRate)
            {
                lastShootTime = Time.time;

                RaycastShoot(currentWeapon);
                UseAmmo((int)currentWeapon.WeaponStyle, 1, 0);
            }
        }
        else
            Debug.Log("Not enough ammo in mag");
    }

    private void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {
        //primary
        if(slot == 0)
        {
            if (primaryCurrentAmmo <= 0)
            {
                primaryMagazineIsEmpty = true;
                CheckCanShoot(manager.currentlyEquipedWeapon);
            }               
            else
            {
                primaryCurrentAmmo -= currentAmmoUsed;
                primaryCurrentAmmoStorage -= currentStoredAmmoUsed;
            }

        }

        //secondary
        if(slot == 1)
        {
            if (secondaryCurrentAmmo <= 0)
            {
                secondaryMagazineIsEmpty = true;
                CheckCanShoot(manager.currentlyEquipedWeapon);
            }             
            else
            {
                secondaryCurrentAmmo -= currentAmmoUsed;
                secondaryCurrentAmmoStorage -= currentStoredAmmoUsed;
            }
                
        }
    }

    private void Reload(int slot)
    {
        if(canReload && canReload)
        {
            //primary
            if (slot == 0)
            {
                int ammoToReload = inventory.GetItem(0).magazineSize - primaryCurrentAmmo;

                //if we have enough ammo to reload our magazine
                if (primaryCurrentAmmoStorage >= ammoToReload)
                {
                    //if magazine is full
                    if (primaryCurrentAmmo == inventory.GetItem(0).magazineSize)
                        Debug.Log("magazine is already full");

                    primaryCurrentAmmo += ammoToReload;
                    primaryCurrentAmmoStorage -= ammoToReload;

                    primaryMagazineIsEmpty = false;
                    CheckCanShoot(slot);
                }
                else
                    Debug.Log("Not enough ammo to reload");
            }

            //secondary
            if (slot == 1)
            {
                int ammoToReload = inventory.GetItem(0).magazineSize - secondaryCurrentAmmo;

                //if we have enough ammo to reload our magazine
                if (secondaryCurrentAmmoStorage >= ammoToReload)
                {
                    //if magazine is full
                    if (secondaryCurrentAmmo == inventory.GetItem(1).magazineSize)
                        Debug.Log("magazine is already full");

                    secondaryCurrentAmmo += ammoToReload;
                    secondaryCurrentAmmoStorage -= ammoToReload;

                    secondaryMagazineIsEmpty = false;
                    CheckCanShoot(slot);
                }
                else
                    Debug.Log("Not enough ammo to reload");
            }
        }

      

    }

    private void CheckCanShoot(int slot)
    {
        //primary
        if(slot == 0)
        {
            if (primaryMagazineIsEmpty)
                canShoot = false;
            else
                canShoot = true;
        }
        
        //secondary
        if(slot == 1)
        {
            if (secondaryMagazineIsEmpty)
                canShoot = false;
            else
                canShoot = true;
        }
        
    }

    public void InitAmmo(int slot, Weapon weapon)
    {
        //primary
        if(slot == 0)
        {
            primaryCurrentAmmo = weapon.magazineSize;
            primaryCurrentAmmoStorage = weapon.storedAmmo;
        }

        //seconday
        if (slot == 1)
        {
            secondaryCurrentAmmo = weapon.magazineSize;
            secondaryCurrentAmmoStorage = weapon.storedAmmo;
        }
    }

    private void SpawnBloodPartical(Vector3 postion)
    {
        Instantiate(BloodPS, postion, new Quaternion(0, 0, 0, 0));
    }
        
    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
    }
}
