using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text magazinesize;
    [SerializeField] private TMP_Text magazinecount;

    public void UpdateInfo(Sprite weaponIcon, int magazineSize, int magazineCount)
    {
        icon.sprite = weaponIcon;
        magazinesize.text = magazineSize.ToString();
        int magazineCountAmount = magazineSize * magazineCount;
        magazinecount.text = magazineCountAmount.ToString();
    }
}


