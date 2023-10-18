using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantType
{

    public string varietyName;
    public float growthTime;
    public GameObject plantPrefab;
    public int needWatered;
    public int plantSellPrice;
    public int FillHunger;
    public int FillHealthPoint;
    public int damagePoint;
    public int defencePoint;
    public int plantHP; // New field for plant HP
    public string skillName;
    public PlantAbility.PlantSkillType skillType;
    public PlantAbility.PlantStatusEffect StatusEffect;
    public int StatusEffectDuration;

}

