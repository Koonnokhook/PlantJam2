using System;
using UnityEngine;


[Serializable]
public class PlantVariety
{

    private static PlantVariety _instance;
    public static PlantVariety Instance
    {
        get
        {
            if (_instance == null)
            {
                //instance = new PlantVariety();
            }
            return _instance;
        }
    }

    public string varietyName;
    public float growthTime;
    public GameObject plantPrefab;
    public int needWatered;
    public int plantSellPrice;
    public int FillHunger;
    public int FillHealthPoint;
    public int damagePoint;
    public int defencePoint;
    public int plantHP;
    public string skillName;
    public PlantAbility.PlantSkillType skillType;
    public PlantAbility.PlantStatusEffect StatusEffect;
    public int StatusEffectDuration;

    public PlantVariety(
        string name, float growth, GameObject prefab, int watered, int sellPrice,
        int hunger, int healthPoint, int damage, int defence, int hp, string skill,
        PlantAbility.PlantSkillType skillType, PlantAbility.PlantStatusEffect effect, int effectDuration)
    {
        varietyName = name;
        growthTime = growth;
        plantPrefab = prefab;
        needWatered = watered;
        plantSellPrice = sellPrice;
        FillHunger = hunger;
        FillHealthPoint = healthPoint;
        damagePoint = damage;
        defencePoint = defence;
        plantHP = hp; // Set the plant HP
        skillName = skill;
        this.skillType = skillType;
        StatusEffect = effect;
        StatusEffectDuration = effectDuration;
    }
    public PlantVariety GetSelectedPlantVariety(int index)
    {
        if (index >= 0 && index < PlantAbility.Instance.plantVarieties.Length)
        {
            return PlantAbility.Instance.plantVarieties[index];
        }

        return null;
    }
}

public static class PlantVarietiesGetter
{
    public static PlantVariety GetSelectedPlantVariety(int index)
    {
        if (index >= 0 && index < PlantAbility.Instance.plantVarieties.Length)
        {
            return PlantAbility.Instance.plantVarieties[index];
        }

        return null;
    }
}


[Serializable]
public class PlantAbility
{
    public enum PlantSkillType
    {
        None,
        Damage,
        Status,
    }

    public enum PlantStatusEffect
    {
        None,
        Onfired,
        Paralyze,
        Poison,
    }
    private static PlantAbility _instance;
    public static PlantAbility Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlantAbility();
            }
            return _instance;
        }
    }


    public PlantVariety[] plantVarieties;

    private PlantAbility()
    {
        plantVarieties = new PlantVariety[]
        {
            new PlantVariety("Beety", 10f, null, 1, 40, 20, 10, 5, 2,15, "Paralyze", PlantSkillType.Status, PlantStatusEffect.Paralyze, 1),
            new PlantVariety("Musha", 15f, null, 1, 60, 25, 20, 8, 3,20, "BodySlam", PlantSkillType.Damage, PlantStatusEffect.None, 0),
            new PlantVariety("Rusby", 30f, null, 2, 80, 30, 20, 10, 4,30, "None", PlantSkillType.None, PlantStatusEffect.None, 0),
            new PlantVariety("Sally", 35f, null, 0, 150, 60, 30, 6, 5,40, "Poison", PlantSkillType.Status, PlantStatusEffect.Poison, 2),
            new PlantVariety("Nhomoo", 40f, null, 2, 200, 80, 40, 12, 8,50, "Onfired", PlantSkillType.Status, PlantStatusEffect.Onfired, 3),
            new PlantVariety("Bombasti", 45f, null, 2, 300, 40, 35, 10, 6,45, "Damage", PlantSkillType.Damage, PlantStatusEffect.None, 0)
        };
    }
}