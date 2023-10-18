using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase
{
    [SerializeField]
    private ItemData _data;

    private List<ItemData> items;

    public ItemDatabase()
    {
        items = new List<ItemData>();
        InitializeDatabase(); 
    }

    public void InitializeDatabase()
    {

        items.Add(new ItemData { name = "Beetroot", type = _data.type});
        items.Add(new ItemData { name = "Mushroom", type = _data.type });
        items.Add(new ItemData { name = "Raspberry", type = _data.type });
        items.Add(new ItemData { name = "Salmon", type = _data.type });
        items.Add(new ItemData { name = "Beef", type = _data.type });
        items.Add(new ItemData { name = "Cherry", type = _data.type });

        items.Add(new ItemData { name = "BeetrootSeed", type = _data.type });
        items.Add(new ItemData { name = "MushroomSeed", type = _data.type });
        items.Add(new ItemData { name = "RaspberrySeed", type = _data.type });
        items.Add(new ItemData { name = "SalmonSeed", type = _data.type });
        items.Add(new ItemData { name = "BeefSeed", type = _data.type });
        items.Add(new ItemData { name = "CherrySeed", type = _data.type });

        items.Add(new ItemData { name = "WaterBucket", type = _data.type });

    }

    public ItemData GetItemByName(string itemName)
    {

        return items.Find(item => item.name == itemName);
    }

    public List<ItemData> GetAllItems()
    {

        return items;
    }
}
