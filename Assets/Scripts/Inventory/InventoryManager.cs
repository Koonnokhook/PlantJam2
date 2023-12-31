using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public Text moneyText;

    private int money;
    private List<PlantVariety> plantInventory = new List<PlantVariety>();
    private ItemDatabase itemDatabaseEco;

    private Dictionary<string, int> itemPrices = new Dictionary<string, int>
    {
        { "Beetroot", 25 },
        { "Mushroom", 35 },
        { "Raspberry", 50 },
        { "Salmon", 70 },
        { "Beef", 85 },
        { "Cherry", 100 },
    };

    void Start()
    {
        itemDatabaseEco = new ItemDatabase(); // Fix: Initialize itemDatabaseEco
        // Example: Adding a WaterBucket item to the inventory on startup
        ItemData waterBucket = itemDatabaseEco.GetItemByName("WaterBucket");
        AddItem(waterBucket);
    }
    /*
    public bool HasItem(GameObject itemPrefab)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.itemPrefab == itemPrefab)
            {
                return true;
            }
        }
        return false;
    }
    
     */

    public bool CanSellItem(ItemData item)
    {
        // Provide the actual implementation for this method based on your logic
        return false;
    }


    /*
    public void AddPlantToInventory(PlantVariety plant)
    {
        List<ItemData> sellableItems = itemDatabaseEco.GetSellableItems();
        // Fix: Define the 'item' variable before using it
        ItemData item = sellableItems.Find(i => i.itemName == plant.itemName);
        if (item != null)
        {
            plantInventory.Add(plant);
        }
    }

    public void AddPlantToInventory(PlantVariety plant, InventoryManager playerInventory)
    {
        playerInventory.AddPlantToInventory(plant);
    }
    */
    public void AddPlant(PlantVariety plant)
    {
        plantInventory.Add(plant);
    }


    public bool AddItem(ItemData item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(ItemData item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }

    public void RemoveMoney(int purchaseValue)
    {
        if (money >= purchaseValue)
        {
            money -= purchaseValue;
            UpdateMoneyText();
        }
        else
        {
            Debug.Log("Not enough money to make the purchase.");
        }
    }

    public int CalculateSellValue(ItemData item)
    {
        if (item.itemName == "Beetroot")
            return 25;
        else if (item.itemName == "Mushroom")
            return 35;
        else if (item.itemName == "Raspberry")
            return 50;
        else if (item.itemName == "Salmon")
            return 70;
        else if (item.itemName == "Beef")
            return 85;
        else if (item.itemName == "Cherry")
            return 100;
        else
            return 0;
    }

    public List<ItemData> GetBuyableItems()
    {
        return new List<ItemData>();
    }

    public List<ItemData> GetSellableItems()
    {
        return new List<ItemData>();
    }
    /*
    public void RemoveItem(ItemData item)
    {
        items.Remove(item);
    }
    */
    public void AddPlantToInventory(PlantVariety plant)
    {
        plantInventory.Add(plant);
    }

    public int CalculateBuyValue(ItemData itemToBuy)
    {
        string itemName = itemToBuy.itemName;

        if (itemPrices.ContainsKey(itemName))
        {
            int baseValue = itemPrices[itemName];
            return baseValue;
        }
        else
        {
            Debug.LogWarning("Item price not found for " + itemName);
            return 0;
        }
    }

    public bool CanBuyItem(ItemData itemToBuy)
    {
        return HasEnoughMoney(CalculateBuyValue(itemToBuy));
    }

    public bool HasEnoughMoney(int amount)
    {
        return money >= amount;
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "Money: $" + money.ToString();
        }
    }
}
