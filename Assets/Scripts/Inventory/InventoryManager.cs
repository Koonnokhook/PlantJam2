using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    public InventorySlot[] inventorySlots;
    public GameObject InventoryItemPrefab;
    private int money;
    private List<Item> items;
    ItemDatabase itemDatabase = new ItemDatabase();

    // Get a specific item
    ItemData Beetroot;

    // Get all items
    List<ItemData> allItems;

    public bool AddItem(ItemData item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {

            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInslot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInslot != null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    private void Start()
    {
        if (itemDatabase == null)
        {
            itemDatabase = new ItemDatabase();
        }
        Beetroot = itemDatabase.GetItemByName("Beetroot");
        allItems = new List<ItemData>();

        allItems.Add(Beetroot);
    }

    void SpawnNewItem(ItemData item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(InventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);

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
    }

    public int CalculateSellValue(Item item)
    {
        // Implement logic to calculate the sell value
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

        ItemData itemToRemove = items.Find(i => i.id == item.id);


        if (itemToRemove != null)
        {

            items.Remove(itemToRemove);
        }
    }

    public bool CanSellItem(ItemData itemCost)
    {
        Debug.Log("Code needed");
        return false;
        
    }

    public void AddPlantToInventory(PlantVariety plant)
    {
        /*ItemData id;
        id.name = plant.varietyName;
        InventoryManager.AddItem(plant);*/
        Debug.Log("Code needed");

        
    }

    
    
}


