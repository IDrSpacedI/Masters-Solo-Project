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


    private void OnTriggerEnter(Collider other)
    {
        pickuptext.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        pickuptext.gameObject.SetActive(false);
    }
}
