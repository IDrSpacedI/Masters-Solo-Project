using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject prefab;
    public GameObject MuzzleFlashPartical;
    public int magazineSize;
    public int MagazineCount;
    public float fireRate;
    public float range;
    public WeaponType WeaponType;
    public WeaponStyle WeaponStyle;
}

public enum WeaponType { Melee, Pistol, AR, Shotgun, Sniper}

public enum WeaponStyle { Primary, Secondary, Melee}
