using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    //weapon item varibles
    public GameObject prefab;
    public GameObject MuzzleFlashPartical;
    public int damage;
    public int magazineSize;
    public int storedAmmo;
    public float fireRate;
    public float range;
    public WeaponType WeaponType;
    public WeaponStyle WeaponStyle;
}

public enum WeaponType { Melee, Pistol, AR, Shotgun, Sniper}

public enum WeaponStyle { Primary, Secondary, Melee}
