using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text currentHealthText;
    [SerializeField] private TMP_Text maxHealthText;
    [SerializeField] private WeaponUI weaponUI;

    public void UpdateHealth(int currentHeath, int maxHealth)
    {
        currentHealthText.text = currentHeath.ToString();
        maxHealthText.text = maxHealth.ToString();
    }

    public void UpdateWeaponUI(Weapon newWeapon)
    {
        weaponUI.UpdateInfo(newWeapon.icon, newWeapon.magazineSize, newWeapon.storedAmmo);
    }

    public void UpdateWeaponAmmoUI(int currentAmmo, int storedAmmo)
    {
        weaponUI.UpdateAmmoUI(currentAmmo, storedAmmo); 
    }

}
