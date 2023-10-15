using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Gradient healthGradient;
    [SerializeField] Image fillImage;

    private int health;
    public int Health
    {
        get => health;

        set
        {
            UpdateHealthBar();
            health = value;
        }
    }
    public int MaxHealth;

    private void OnEnable()
    {
        GameEvents.OnBirdCollided += GameEvents_OnBirdCollided;
        GameEvents.OnGameStartRequested += GameEvents_OnGameStartRequested;
    }

    private void OnDisable()
    {
        GameEvents.OnBirdCollided -= GameEvents_OnBirdCollided;
        GameEvents.OnGameStartRequested -= GameEvents_OnGameStartRequested;
    }

    private void GameEvents_OnGameStartRequested()
    {
        ResetHealth();
    }

    private void GameEvents_OnBirdCollided()
    {
        Health -= 15;

        if (Health <= 0)
        {
            Health = 0;
            GameEvents.HealthDepleted();
        }
    }

    private void UpdateHealthBar()
    {
        healthSlider.value = Health;
        fillImage.color = healthGradient.Evaluate(Health * 1f / MaxHealth);
    }

    private void ResetHealth()
    {
        Health = MaxHealth = 100;
        healthSlider.value = healthSlider.maxValue = MaxHealth;
        healthSlider.wholeNumbers = true;
        UpdateHealthBar();
    }
}
