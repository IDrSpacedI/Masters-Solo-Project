using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;
    private UIManager UI;

    private void Start()
    {
        GetReferences();
        InitVaribles();
    }

    private void GetReferences()
    {
        hud = GetComponent<PlayerHUD>();
        UI = GetComponent<UIManager>();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        hud.UpdateHealth(health, maxHealth);
    }

    public override void Die()
    {
        base.Die();
        UI.SetActiveHud(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }




}
