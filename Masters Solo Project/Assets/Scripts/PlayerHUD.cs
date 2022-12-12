using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHUD : MonoBehaviour
{
    public static PlayerHUD instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    //player HUD Text varibles
    [SerializeField] private TMP_Text currentHealthText;
    [SerializeField] private TMP_Text maxHealthText;
    [SerializeField] private WeaponUI weaponUI;
    [SerializeField] private Score ScoreUI;

    //updates text UI
    public void UpdateHealth(int currentHeath, int maxHealth)
    {
        currentHealthText.text = currentHeath.ToString();
        maxHealthText.text = maxHealth.ToString();
    }

    //updates weapon UI Text
    public void UpdateWeaponUI(Weapon newWeapon)
    {
        weaponUI.UpdateInfo(newWeapon.icon, newWeapon.magazineSize, newWeapon.storedAmmo);
    }

    //updates weapon UI Text
    public void UpdateWeaponAmmoUI(int currentAmmo, int storedAmmo)
    {
        weaponUI.UpdateAmmoUI(currentAmmo, storedAmmo); 
    }

    //updates UI Score Text
    public void UpdateScoreAmount()
    {
        ScoreUI.AddToScore();
    }

}
