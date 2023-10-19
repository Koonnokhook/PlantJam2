using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;

    [Header("Only gameplay")]
    public List<ItemActionType> itemActionTypes;


    public enum ItemType
    {
        Food,
        Seed,
        Tool
    }

    public enum ItemActionType
    {
        Plant,
        Heal,
        Sell,
        Water
    }

}