using TMPro;
using UnityEngine;
using static PlantAbility;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int startingMoney = 100;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI availableCurrencyText;
    public GameObject marketplaceUI;
    public TextMeshProUGUI notificationText;
    public HealthManagingSystem player;
    public RoboticNPC roboticNPC;
    public EconomyManager economyManager;
    public InventoryManager playerInventory;



    public int maxHunger = 100;
    public int hungerIncreasePerDay = 10;
    public int hungerThreshold = 80;
    public int hpReductionAmount = 10;

    private int currentDay = 1;
    private int currentMoney;

    public delegate void DayEndEventHandler();
    public event DayEndEventHandler OnDayEnd;

    void Start()
    {
        currentMoney = startingMoney;
        moneyText.text = "Money: $" + currentMoney.ToString();
        availableCurrencyText.text = "Available Currency: " + currentMoney.ToString();
        marketplaceUI.SetActive(false);

        OnDayEnd += HandleDayEnd;
        OnDayEnd += HandleHungerAndHP;

        HandleDayEnd();
    }

    void SpawnRoboticNPC()
    {
        RoboticNPC npc = Instantiate(roboticNPC, transform.position, Quaternion.identity);
        npc.SetupDialogue("What would you like to buy or sell");
        npc.AddSellableItems(playerInventory.GetSellableItems());
        npc.AddBuyableItems(playerInventory.GetBuyableItems());
        npc.SetBuyCallback(HandleBuy);

        npc.OnBuy += HandleBuy;
        npc.OnSell += HandleSell;

        npc.OfferHealService();
        npc.OfferHungerService();

        return;
    }


    void HandleBuy(ItemData item)
    {
        int purchaseValue = roboticNPC.GetBuyValue(item);

        if (economyManager.CanBuyItem(purchaseValue)) // Call the method on the instance
        {
            if (playerInventory.HasEnoughMoney(purchaseValue))
            {
                playerInventory.RemoveMoney(purchaseValue);
                playerInventory.AddItem(item);
            }
        }
    }

    void HandleSell(ItemData item)
    {
        if (playerInventory.CanSellItem(item))
        {
            int sellValue = playerInventory.CalculateSellValue(item);
            playerInventory.RemoveItem(item);
            playerInventory.AddMoney(sellValue);
        }
    }



    void HandleHungerAndHP()
    {
        player.IncreaseHunger(hungerIncreasePerDay);

        if (player.GetHunger() > hungerThreshold)
        {
            player.TakeDamage(hpReductionAmount);
        }
    }

    void HandleDayEnd()
    {
        SpawnRoboticNPC();
    }

    public void StartBattle()
    {
 
        PlantVariety selectedVariety = PlantAbility.Instance.plantVarieties[0];

        int plantHealpoint = selectedVariety.plantHP;
        int plantDamage = selectedVariety.damagePoint;
        int plantDefence = selectedVariety.defencePoint;
        PlantSkillType plantSkill = selectedVariety.skillType;
        PlantStatusEffect plantEffect = selectedVariety.StatusEffect;
        int effectDuration = selectedVariety.StatusEffectDuration;

        BattleData.SetBattleValues(plantHealpoint, plantDamage, plantDefence, plantSkill, plantEffect, effectDuration);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Turnbase");
    }
}
