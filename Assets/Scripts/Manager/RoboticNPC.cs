using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class RoboticNPC : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public EconomyManager economyManager;
    public InventoryManager playerInventory;
    public int hungerReductionAmount;     
    public MessageDisplay messageDisplay;
    public int healPrice = 20;  
    public int hungerPrice = 10;


    private List<ItemData> buyableItems = new List<ItemData>();
    private List<ItemData> sellableItems = new List<ItemData>();


    private bool isTalking = false;

    public event Action<ItemData> OnBuy;
    public event Action<ItemData> OnSell;

    public void SetBuyCallback(Action<ItemData> buyCallback)
    {
        OnBuy += buyCallback;
    }

    void Start()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }

        economyManager = EconomyManager.Instance;
    }



    public void SetupDialogue(string text)
    {
        if (!isTalking)
        {
            DisplayDialogue(text);
        }
    }

    private void DisplayDialogue(string text)
    {
        if (dialogueText != null)
        {
            dialogueText.text = text;
        }

        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
        }
        isTalking = true;
    }

    public void BuyItem(int itemCost)
    {
        if (economyManager.CanBuyItem(itemCost))
        {
            economyManager.BuyItem(itemCost);
            // Handle successful purchase logic.
        }
        else
        {
            // Handle not enough money logic.
        }
    }

    public void SellItem(int itemCost)
    {
        economyManager.SellItem(itemCost);
        // Handle item selling logic.
    }

    public void OfferHealService()
    {
        if (economyManager.CanBuyItem(healPrice))
        {
            economyManager.BuyItem(healPrice);
            DisplayMessage("You have been healed!");
        }
        else
        {
            DisplayMessage("You don't have enough money for healing.");
        }
    }

    public void OfferHungerService()
    {
        if (economyManager.CanBuyItem(hungerPrice))
        {
            economyManager.BuyItem(hungerPrice);
            DisplayMessage("Your hunger has been reduced!");
        }
        else
        {
            DisplayMessage("You don't have enough money to reduce hunger.");
        }
    }

    public void DisplayMessage(string message)
    {
        if (messageDisplay != null)
        {
            messageDisplay.DisplayMessage(message);
        }
    }

    public void AddBuyableItems(List<ItemData> items)
    {
        buyableItems.AddRange(items);
        Debug.Log("Buyable items added successfully.");
    }

    public void AddSellableItems(List<ItemData> items)
    {
        sellableItems.AddRange(items);
        Debug.Log("Buyable items added successfully.");

    }

    public int GetBuyValue(ItemData item)
    {
        Dictionary<string, int> itemPrices = new Dictionary<string, int>
    {
        { "BeetrootSeed", 20 },
        { "MagicScroll", 30 },
        { "Sword", 50 },
        // Add more items and their prices here
    };

        if (itemPrices.ContainsKey(item.itemName))
        {
            return itemPrices[item.itemName];
        }
        else
        {
            
            return 0;
        }
    }




}
