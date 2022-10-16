using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVaribles();
    }

    public virtual void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            isDead = true;
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Die()
    {
        isDead = true;
    }

    private void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        SetHealthTo(healthAfterDamage);
    }

    public void Heal(int heal)
    {
        int healAfterHeal = health + heal;
        SetHealthTo(healAfterHeal);
    }

    public void InitVaribles()
    {
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;

    }


}
