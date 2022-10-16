using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text currentHealthText;
    [SerializeField] private TMP_Text maxHealthText;

    public void UpdateHealth(int currentHeath, int maxHealth)
    {
        currentHealthText.text = currentHeath.ToString();
        maxHealthText.text = maxHealth.ToString();
    }


}
