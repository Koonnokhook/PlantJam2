using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int minDamage; // Minimum damage
    public int maxDamage; // Maximum damage
    public int minDefense; // Minimum defense
    public int maxDefense; // Maximum defense
    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg)
    {
        // Calculate the actual damage taken after considering defense
        int actualDamage = Mathf.Max(0, dmg - UnityEngine.Random.Range(minDefense, maxDefense + 1));

        currentHP -= actualDamage;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}

public class Enemy : MonoBehaviour
{
    public string unitName;
    public int maxHP;
    public int currentHP;
    public int damage;
    public PlantAbility.PlantSkillType skillType;
    public PlantAbility.PlantStatusEffect statusEffect;
    public int statusEffectDuration;

    public void Setup(string newName, int newMaxHP, int newDamage, PlantVariety selectedVariety)
    {
        unitName = newName;
        maxHP = newMaxHP;
        currentHP = maxHP;
        damage = newDamage;


        skillType = selectedVariety.skillType;
        statusEffect = selectedVariety.StatusEffect;
        statusEffectDuration = selectedVariety.StatusEffectDuration;
    }
}
