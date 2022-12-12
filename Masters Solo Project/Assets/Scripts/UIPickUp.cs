using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPickUp : MonoBehaviour
{
    public TMP_Text pickuptext;

    private void Start()
    {
        pickuptext.gameObject.SetActive(false);
    }

    //sets UI text active when enters trigger
    private void OnTriggerEnter(Collider other)
    {
        pickuptext.gameObject.SetActive(true);
    }

    //sets UI text inactivbe when exits trigger
    private void OnTriggerExit(Collider other)
    {
        pickuptext.gameObject.SetActive(false);
    }
}
