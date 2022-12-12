using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    //varibles
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;

    [SerializeField] protected bool isDead;

    private void Start()
    {
        InitVaribles();
    }

    //check health if dead 
    public virtual void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            isDead = true;
            Die();
        }
        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    //if died isdead is true
    public virtual void Die()
    {
        isDead = true;
    }


    public bool IsDead()
    {
        return isDead;
    }


    //sets health
    public void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    //takes damage accordily 
    public void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        SetHealthTo(healthAfterDamage);
    }

    //heal player for certain amount
    public void Heal(int heal)
    {
        int healAfterHeal = health + heal;
        SetHealthTo(healAfterHeal);
    }

    //gets max heath
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    //sets int varibles
    public virtual void InitVaribles()
    {
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;

    }


}
