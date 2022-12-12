using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    //varibles
    [SerializeField] private int damage;
    public float attackSpeed;

    [SerializeField] private bool canAttack;

    private void Start()
    {
        InitVaribles();
    }

    //deal damage to target
    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(damage);
    }

    //updates score and destroys enemie
    public override void Die()
    {
        base.Die();
        PlayerHUD.instance.UpdateScoreAmount();
        Destroy(gameObject);
    }

    //overrides int varibles 
    public override void InitVaribles()
    {
        maxHealth = 25;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;

    }
}
