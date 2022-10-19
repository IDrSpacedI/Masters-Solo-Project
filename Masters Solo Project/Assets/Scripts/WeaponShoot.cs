using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{

    private Camera cam;
    


    private void Start()
    {
        GetReferences();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //shoot
        }
    }

    private void Shoot()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

       
    }

    private void GetReferences()
    {
        cam = GetComponentInChildren<Camera>();
    }
}
