using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPickUp : MonoBehaviour
{
    //varibles
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;

    public TMP_Text pickuptext;

    private Camera cam;
    private Inventory inventory;
    private PlayerStats stats;
    private WeaponShoot shooting;
    private EquipmentManager equipment;

    private void Start()
    {
        GetReferences();
    }


    private void Update()
    {
        //allows player to pick up object
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            //raycasts object hit to identify it
            if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                Debug.Log("Hit:" + hit.transform.name);
                if (hit.transform.GetComponent<ItemObject>().item as Weapon)
                {
                    //if its weapon adds to inventory
                    Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
                    inventory.AddItem(newItem);
                    pickuptext.gameObject.SetActive(false);
                }
                else
                {
                    //if its a consumable object checks what it is
                    Consumables newItem = hit.transform.GetComponent<ItemObject>().item as Consumables;
                    if(newItem.Type == ConsumableType.Medkit)
                    {
                        //heal if medkit
                        Debug.Log("HEAL ME");
                        stats.Heal(stats.GetMaxHealth());
                    }
                    else
                    {
                        //adds ammo if ammo
                        if (inventory.GetItem(0) != null)
                            shooting.AddAmmo(0, inventory.GetItem(0).magazineSize, inventory.GetItem(0).storedAmmo);
                        if (inventory.GetItem(1) != null)
                            shooting.InitAmmo(1, inventory.GetItem(1));
                    }
                }
                //deletes object after
                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();
        shooting = GetComponent<WeaponShoot>();
        equipment = GetComponent<EquipmentManager>();
    }
}
