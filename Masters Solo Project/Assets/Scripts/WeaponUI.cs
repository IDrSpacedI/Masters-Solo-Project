using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text magazinesizeText;
    [SerializeField] private TMP_Text storedAmmoText;

    public void UpdateInfo(Sprite weaponIcon, int magazineSize, int storedAmmo)
    {
        icon.sprite = weaponIcon;
        magazinesizeText.text = magazineSize.ToString();
        storedAmmoText.text = storedAmmo.ToString();
    }
}


