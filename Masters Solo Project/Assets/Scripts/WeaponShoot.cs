using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class WeaponShoot : MonoBehaviour
{
    //weapon varibles
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
    private PlayerHUD Hud;
    private PlayerStats stats;
    //public GameObject DB;
    //public Animator anim;

    [SerializeField] private GameObject BloodPS = null;


    private void Start()
    {
        GetReferences();
        canShoot = true;
        canReload = true;
        //anim = DB.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //anim = DB.gameObject.GetComponent<Animator>();

        if (!stats.IsDead())
        {
            //allows player to shoot 
            if (Input.GetKey(KeyCode.Mouse0))
            {
                shoot();               
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload(manager.currentlyEquipedWeapon);
                //anim.SetBool("reload", true);
                FindObjectOfType<SoundManager>().Play("ShotgunReload");

            }
        }
       
    }

    //raycasts whats infront of player on weapon shoot
    private void RaycastShoot(Weapon currentWeapon)
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        float currentWeaponRange = currentWeapon.range;
        //if player hits enemy target 
        if (Physics.Raycast(ray, out hit, currentWeaponRange))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.tag == "Enemy")
            {
                //deals damage
                CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();
                enemyStats.TakeDamage(currentWeapon.damage);

                //spawn partical
                SpawnBloodPartical(hit.point);
            }
        }
        //spawns weapon flash
        Instantiate(currentWeapon.MuzzleFlashPartical, manager.currentWeaponBarrel);
    }

    //allows the player to shoot
    private void shoot()
    {
        CheckCanShoot(manager.currentlyEquipedWeapon);

        if (canShoot && canReload)
        {
            Weapon currentWeapon = inventory.GetItem(manager.currentlyEquipedWeapon);

            if (Time.time > lastShootTime + currentWeapon.fireRate)
            {
                lastShootTime = Time.time;

                RaycastShoot(currentWeapon);
                UseAmmo((int)currentWeapon.WeaponStyle, 1, 0);
                FindObjectOfType<SoundManager>().Play("ShotgunShoot");
            }
        }
        else
            Debug.Log("Not enough ammo in mag");
    }

    //uses neccessary ammo for weapon
    private void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {
        //primary gun
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
                Hud.UpdateWeaponAmmoUI(primaryCurrentAmmo, primaryCurrentAmmoStorage);
            }

        }

        //secondary gun 
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
                Hud.UpdateWeaponAmmoUI(secondaryCurrentAmmo, secondaryCurrentAmmoStorage);
            }
                
        }
    }

    //allows player to add ammo on item pickup
    public void AddAmmo(int slot, int currentAmmoAdded, int curredStoredAmmoAdded)
    {
        //primary gun
        if (slot == 0)
        {
            primaryCurrentAmmo += currentAmmoAdded;
            primaryCurrentAmmoStorage += curredStoredAmmoAdded;
            Hud.UpdateWeaponAmmoUI(primaryCurrentAmmo, primaryCurrentAmmoStorage);

        }

        //secondary
        if (slot == 1)
        {
            secondaryCurrentAmmo += currentAmmoAdded;
            secondaryCurrentAmmoStorage += curredStoredAmmoAdded;
            Hud.UpdateWeaponAmmoUI(secondaryCurrentAmmo, secondaryCurrentAmmoStorage);
        }
    }

    //reloads gun
    private void Reload(int slot)
    {
        if(canReload )
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
                    {
                        Debug.Log("magazine is already full");
                        return;
                    }


                    AddAmmo(slot, ammoToReload, 0);
                    UseAmmo(slot, 0, ammoToReload);

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
                    {
                        Debug.Log("magazine is already full");
                        return;
                    }


                    AddAmmo(slot, ammoToReload, 0);
                    UseAmmo(slot, 0, ammoToReload);

                    secondaryMagazineIsEmpty = false;
                    CheckCanShoot(slot);
                }
                else
                    Debug.Log("Not enough ammo to reload");
            }
        }

      

    }

    //checks if gun has ammo to shoot
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

    //ammo int varibles
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

    //spawns blood effect on kill
    private void SpawnBloodPartical(Vector3 postion)
    {
        Instantiate(BloodPS, postion, new Quaternion(0, 0, 0, 0));
    }
      
    //refences to certain scripts
    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        manager = GetComponent<EquipmentManager>();
        Hud = GetComponent<PlayerHUD>();
        stats = GetComponent<PlayerStats>();
    }
}
