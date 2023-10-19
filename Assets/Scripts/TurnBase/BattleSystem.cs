using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using static PlantType;


public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST,
}



public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public HealthManagingSystem healthManager;

    Unit playerUnit;
    Unit enemyUnit;
    public Text dialogueText;
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public BattleState state;

    private int playerHPInBattle; // Separate HP for the battle
    private int defeatPenalty = 10;
    private PlantVariety selectedVariety; // Store the selected variety

    void Start()
    {
        state = BattleState.START;
        playerHPInBattle = 100; // Set player's HP for the battle
        selectedVariety = PlantVarietiesGetter.GetSelectedPlantVariety(0); // Get the selected variety
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " refuses to be harvested!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(UnityEngine.Random.Range(playerUnit.minDamage, playerUnit.maxDamage + 1));
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1f);
        bool isDead = playerUnit.TakeDamage(UnityEngine.Random.Range(enemyUnit.minDamage, enemyUnit.maxDamage + 1));
        playerHUD.SetHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);

        if (selectedVariety.skillType == PlantAbility.PlantSkillType.Damage)
        {
            int normalDamage = UnityEngine.Random.Range(enemyUnit.minDamage, enemyUnit.maxDamage + 1);

            float damageMultiplier = 1.2f;  


            int modifiedDamage = (int)(normalDamage * damageMultiplier);


            playerUnit.TakeDamage(modifiedDamage);
        }

        else if (selectedVariety.skillType == PlantAbility.PlantSkillType.Status)
        {
            if (selectedVariety.StatusEffect == PlantAbility.PlantStatusEffect.Poison)
            {

                int poisonAmount = 5; 
                int poisonDuration = 3;  

               //PlantSkill singleton
               // PlantSkill.ApplyPoisonEffect(poisonDuration, poisonAmount);
            }

            if (selectedVariety.StatusEffect == PlantAbility.PlantStatusEffect.Onfired)
            {
                int fireDamage = 10;  
                int fireDuration = 3;

                // PlantSkill.ApplyOnFireEffect(fireDuration, fireDamage);
            }

            if (selectedVariety.StatusEffect == PlantAbility.PlantStatusEffect.Paralyze)
            {
                dialogueText.text = "You are paralyzed and can't attack!";
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";

            InventoryManager.AddPlantToInventory(selectedVariety);

            // Replace 'plantInPot' with the actual reference to the plant GameObject
            Destroy(plantInPot);
            Debug.Log("Code needed");
        }

        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
            playerHPInBattle -= defeatPenalty;
            if (playerHPInBattle <= 0)
            {
                dialogueText.text += " You have run out of HP.";
            }
            else
            {
                dialogueText.text += " You have " + playerHPInBattle + " HP left. The plant remains in its pot for another battle.";
            }
        }
    }

    void PlayerTurn()
    {
        if (playerHPInBattle <= 0)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            dialogueText.text = "Choose an action:";
        }
    }

    IEnumerator PlayerHeal()
    {
        int minDefense = playerUnit.minDefense;
        int maxDefense = playerUnit.maxDefense;
        int defense = UnityEngine.Random.Range(minDefense, maxDefense + 1);
        int amount = 5 - defense;
        playerUnit.Heal(amount);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel renewed strength!";
        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerHeal());
    }
}
