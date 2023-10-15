using System;

public static class GameEvents
{
    public static event Action OnBirdCollided, OnBirdCollisionAvoided;
    public static event Action OnHealthDepleted;
    public static event Action OnGameStartRequested;

    public static void BirdCollided()
    {
        OnBirdCollided?.Invoke();
    }

    public static void BirdCollisionAvoided()
    {
        OnBirdCollisionAvoided?.Invoke();
    }

    public static void HealthDepleted()
    {
        OnHealthDepleted?.Invoke();
    }

    public static void RequestGameStart()
    {
        OnGameStartRequested?.Invoke();
    }
}
