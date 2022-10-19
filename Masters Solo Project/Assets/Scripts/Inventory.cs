using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapon[] Weapons;


    public void Start()
    {
        InitVaibles();
    }

    public void AddItem(Weapon newItem)
    {

        int newItemIndex = (int)newItem.WeaponStyle;

        if (Weapons[(int)newItemIndex] != null)
        {
            RemoveItem((int)newItemIndex);
        }
        Weapons[(int)newItemIndex] = newItem;

    }

    public void RemoveItem(int index)
    {
        Weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return Weapons[index];
    }

    private void InitVaibles()
    {
        Weapons = new Weapon[3];
    }
}
