using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ItemData;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject InventoryItemPrefab;
    private int money;
    private List<ItemData> items; 
    ItemDatabase itemDatabase = new ItemDatabase();
    public Text moneyText; 
    public ItemDatabase itemDatabaseEco;
    private List<PlantVariety> plantInventory = new List<PlantVariety>();


    void Start()
    {
        items = new List<ItemData>();

        if (itemDatabase == null)
        {
            itemDatabase = new ItemDatabase();
        }

        ItemData waterBucket = itemDatabase.GetItemByName("WaterBucket");
        AddItem(waterBucket);
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
        GameObject newItemGo = Instantiate(InventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    public class Item
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public bool IsEssential { get; set; }

        public Item(string name, int cost, bool isEssential)
        {
            Name = name;
            Cost = cost;
            IsEssential = isEssential;
        }
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
        //the item's price are fixed.
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

    public void RemoveItem(ItemData item)
    {
        items.Remove(item);
    }

    public bool CanSellItem(ItemData item)
    {

        List<ItemData> sellableItems = itemDatabaseEco.GetSellableItems();
        return sellableItems.Contains(item);

    }

    public void AddPlantToInventory(PlantVariety plant, InventoryManager playerInventory)
    {
        playerInventory.AddPlant(plant);
    }

    public void AddPlant(PlantVariety plant)
    {
        // Add the plant to your inventory here.
        // You need to define the data structure for your inventory.
        // This could be a list, an array, or any other appropriate data structure.
        // For example, if you're using a List<PlantVariety> for your inventory:
        plantInventory.Add(plant);
    }


    public int CalculateBuyValue(ItemData itemToBuy) //calculate the buy value of the item
    {
        string itemName = itemToBuy.itemName;

        // Check if the item exists in the itemPrices dictionary
        if (itemPrices.ContainsKey(itemName))
        {
            int baseValue = itemPrices[itemName];
            return baseValue;
        }
        else
        {
            // Handle the case where the item is not found in the dictionary
            Debug.LogWarning("Item price not found for " + itemName);
            return 0; // or any default value
        }
    }

    public bool CanBuyItem(ItemData itemToBuy) // check if the player has enough money to buy the item
    {
        
        return false; 
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

    
    private Dictionary<string, int> itemPrices = new Dictionary<string, int>
{
    { "Beetroot", 25 },
    { "Mushroom", 35 },
    { "Raspberry", 50 },
    { "Salmon", 70 },
    { "Beef", 85 },
    { "Cherry", 100 },
};

}
