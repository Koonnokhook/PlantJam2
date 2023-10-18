using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManagingSystem : MonoBehaviour
{
    public Slider hungerSlider;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI hungerText;
    public int maxHealth = 100;

    private int hunger = 0;
    private int health;

    public delegate void OnHealthChanged(int currentHealth, int maxHealth);
    public event OnHealthChanged healthChanged;

    public delegate void OnGameOver();
    public event OnGameOver gameOver;

    public PlantType plantType;

    private void Start()
    {
        hunger = 0;
        health = maxHealth;
        UpdateUI();

        InvokeRepeating("IncreaseHungerMin", 0f, 180f);

        UpdateUI();
    }

    public void HandleGameOver()
    {
        gameOver?.Invoke();
    }

    private void Update()
    {
        if (IsGameOver())
        {
            HandleGameOver();
        }

        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        NotifyHealthChanged();

        if (health <= 0)
        {
            HandleGameOver();
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        NotifyHealthChanged();
    }

    private bool IsGameOver()
    {
        return hunger >= 100 || health <= 0;
    }



    private void UpdateUI()
    {
        if (hungerSlider != null)
        {
            hungerSlider.value = hunger;
        }

        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString();
        }

        if (hungerText != null)
        {
            hungerText.text = "Hunger: " + hunger.ToString("F2");
        }
    }

    private void NotifyHealthChanged()
    {
        healthChanged?.Invoke(health, maxHealth);
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    private void IncreaseHungerMin()  
    {
        IncreaseHunger(1);

        if (hunger >= 100)
        {
            TakeDamage(10);
        }
    }

    public void IncreaseHunger(int amount)
    {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0, 100);
    }

    public float GetHunger()
    {
        return hunger;
    }
}
