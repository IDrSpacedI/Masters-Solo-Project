using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable", menuName = "Item/Consumable")]
public class Consumables : Item
{
    public ConsumableType Type;
}

public enum ConsumableType { Medkit, Ammo}
