using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlantAbility;
using static PlantType;

public static class BattleData
{
    public static int HealthPoint;
    public static int damagePoint;
    public static int defencePoint;
    public static PlantSkillType skillType;
    public static PlantStatusEffect StatusEffect;
    public static int StatusEffectDuration;

    public static void SetBattleValues(int plantHealpoint, int damage, int defence, PlantSkillType skill, PlantStatusEffect effect, int effectDuration)
    {
        HealthPoint = plantHealpoint;
        damagePoint = damage;
        defencePoint = defence;
        skillType = skill;
        StatusEffect = effect;
        StatusEffectDuration = effectDuration;
    }
}
