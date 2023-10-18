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


    private bool isTalking = false;

   /* public event Action<Item> OnBuy;
    public event Action<Item> OnSell;*/

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
        Debug.Log("Code needed");
    }

    public void AddSellableItems(List<ItemData> items)
    {
        Debug.Log("Code needed");
        
    }

}
