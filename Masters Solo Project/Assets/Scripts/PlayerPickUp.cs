using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private float pickupRange;
    [SerializeField] private LayerMask pickupLayer;

    public TMP_Text pickuptext;

    private Camera cam;
    private Inventory inventory;
    private PlayerStats stats;

    private void Start()
    {
        GetReferences();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                Debug.Log("Hit:" + hit.transform.name);
                if (hit.transform.GetComponent<ItemObject>().item as Weapon)
                {
                    Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
                    inventory.AddItem(newItem);
                    pickuptext.gameObject.SetActive(false);
                }
                else
                {
                    Consumables newItem = hit.transform.GetComponent<ItemObject>().item as Consumables;
                    if(newItem.Type == ConsumableType.Medkit)
                    {
                        //heal
                        Debug.Log("HEAL ME");
                        stats.Heal(stats.GetMaxHealth());
                    }
                    else
                    {
                        //ammo
                    }
                }

                Destroy(hit.transform.gameObject);
            }
        }
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();
    }
}
