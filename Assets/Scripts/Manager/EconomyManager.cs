using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class EconomyManager : MonoBehaviour
{
    public RoboticNPC roboticNPC;

    public int startingMoney = 100;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI notificationText;

    private int currentMoney;

    static EconomyManager _instance;
    public static EconomyManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("EconomyManager");
                go.AddComponent<EconomyManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        currentMoney = startingMoney;
        UpdateMoneyUI();
    }

    public void SubtractMoney(int amount)
    {
        currentMoney -= amount;
        UpdateMoneyUI();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }

    public bool CanBuyItem(int itemCost)
    {
        return currentMoney >= itemCost;
    }

    public void BuyItem(int itemCost)
    {
        if (CanBuyItem(itemCost))
        {
            SubtractMoney(itemCost);
            notificationText.text = "Purchase successful!";
        }
        else
        {
            notificationText.text = "Not enough currency to buy this item.";
        }
    }

    public void SellItem(int itemCost)
    {
        AddMoney(itemCost);
    }

    private void UpdateMoneyUI()
    {
        moneyText.text = "Money: $" + currentMoney.ToString();
    }
}
