using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase
{
    private List<ItemData> items;
    private List<ItemData> buyableItems;
    private List<ItemData> sellableItems;

    public ItemDatabase()
    {
        items = new List<ItemData>();
        buyableItems = new List<ItemData>();
        sellableItems = new List<ItemData>();
        InitializeDatabase();

        List<ItemData> buyableItemsToAdd = new List<ItemData>
        {
            items.Find(item => item.itemName == "BeetrootSeed"),
            items.Find(item => item.itemName == "MushroomSeed"),
            items.Find(item => item.itemName == "RaspberrySeed"),
            items.Find(item => item.itemName == "SalmonSeed"),
            items.Find(item => item.itemName == "BeefSeed"),
            items.Find(item => item.itemName == "CherrySeed")
        };

        List<ItemData> sellableItemsToAdd = new List<ItemData>
        {
            items.Find(item => item.itemName == "Beetroot"),
            items.Find(item => item.itemName == "Mushroom"),
            items.Find(item => item.itemName == "Raspberry"),
            items.Find(item => item.itemName == "Salmon"),
            items.Find(item => item.itemName == "Beef"),
            items.Find(item => item.itemName == "Cherry")
        };

        AddBuyableItems(buyableItemsToAdd);
        AddSellableItems(sellableItemsToAdd);
    }

    public void AddBuyableItems(List<ItemData> itemsToAdd)
    {
        buyableItems.AddRange(itemsToAdd);
    }

    public List<ItemData> GetBuyableItems()
    {
        return buyableItems;
    }

    public void AddSellableItems(List<ItemData> itemsToAdd)
    {
        sellableItems.AddRange(itemsToAdd);
    }

    public List<ItemData> GetSellableItems()
    {
        return sellableItems;
    }


    public void InitializeDatabase()
    {
        // Item 1: Beetroot
        ItemData foodItem1 = new ItemData();
        foodItem1.itemName = "Beetroot";
        foodItem1.itemType = ItemData.ItemType.Food;
        foodItem1.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Heal, ItemData.ItemActionType.Sell };
        items.Add(foodItem1);

        // Item 2: BeetrootSeed
        ItemData seedItem1 = new ItemData();
        seedItem1.itemName = "BeetrootSeed";
        seedItem1.itemType = ItemData.ItemType.Seed;
        seedItem1.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Plant };
        items.Add(seedItem1);

        // Item 3: Mushroom
        ItemData foodItem2 = new ItemData();
        foodItem1.itemName = "Mushroom";
        foodItem1.itemType = ItemData.ItemType.Food;
        foodItem2.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Heal, ItemData.ItemActionType.Sell };
        items.Add(foodItem2);

        // Item 4: MushroomSeed
        ItemData seedItem2 = new ItemData();
        seedItem2.itemName = "MushroomSeed";
        seedItem2.itemType = ItemData.ItemType.Seed;
        seedItem2.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Plant };
        items.Add(seedItem2);

        // Item 5: Raspberry
        ItemData foodItem3 = new ItemData();
        foodItem3.itemName = "Raspberry";
        foodItem3.itemType = ItemData.ItemType.Food;
        foodItem3.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Heal, ItemData.ItemActionType.Sell };
        items.Add(foodItem3);

        // Item 6: RaspberrySeed
        ItemData seedItem3 = new ItemData();
        seedItem3.itemName = "RaspberrySeed";
        seedItem3.itemType = ItemData.ItemType.Seed;
        seedItem3.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Plant };
        items.Add(seedItem3);

        // Item 7: Salmon
        ItemData foodItem4 = new ItemData();
        foodItem4.itemName = "Salmon";
        foodItem4.itemType = ItemData.ItemType.Food;
        foodItem4.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Heal, ItemData.ItemActionType.Sell };
        items.Add(foodItem4);

        // Item 8: SalmonSeed
        ItemData seedItem4 = new ItemData();
        seedItem4.itemName = "SalmonSeed";
        seedItem4.itemType = ItemData.ItemType.Seed;
        seedItem4.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Plant };
        items.Add(seedItem4);

        // Item 9: Beef
        ItemData foodItem5 = new ItemData();
        foodItem5.itemName = "Beef";
        foodItem5.itemType = ItemData.ItemType.Food;
        foodItem5.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Heal, ItemData.ItemActionType.Sell };
        items.Add(foodItem5);

        // Item 10: BeefSeed
        ItemData seedItem5 = new ItemData();
        seedItem5.itemName = "BeefSeed";
        seedItem5.itemType = ItemData.ItemType.Seed;
        seedItem5.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Plant };
        items.Add(seedItem5);

        // Item 11: Cherry
        ItemData foodItem6 = new ItemData();
        foodItem6.itemName = "Cherry";
        foodItem6.itemType = ItemData.ItemType.Food;
        foodItem6.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Heal, ItemData.ItemActionType.Sell };
        items.Add(foodItem6);

        // Item 12: CherrySeed
        ItemData seedItem6 = new ItemData();
        seedItem6.itemName = "CherrySeed";
        seedItem6.itemType = ItemData.ItemType.Seed;
        seedItem6.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Plant };
        items.Add(seedItem6);

        // Item 13: WaterBucket
        ItemData toolItem = new ItemData();
        toolItem.itemName = "WaterBucket";
        toolItem.itemType = ItemData.ItemType.Tool;
        toolItem.itemActionTypes = new List<ItemData.ItemActionType> { ItemData.ItemActionType.Water };
        items.Add(toolItem);
    }

    public ItemData GetItemByName(string itemName)
    {
        return items.Find(item => item.itemName == itemName);
    }

    public List<ItemData> GetAllItems()
    {
        return items;
    }
}
