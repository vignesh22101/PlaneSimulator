using UnityEngine;

public class GameSimulation : MonoBehaviour
{
    [SerializeField] private bool birdCollided;
    [SerializeField] private bool birdCollisionAvoided;
    [SerializeField] private bool healthDepleted;
    [SerializeField] private bool gameStartRequested;
    [SerializeField] private bool spawnBird;

    private bool prevBirdCollided;
    private bool prevBirdCollisionAvoided;
    private bool prevHealthDepleted;
    private bool prevGameStartRequested;

    BirdSpawner birdSpawner;

    private void Awake()
    {
        birdSpawner = FindObjectOfType<BirdSpawner>();
    }

    private void OnValidate()
    {
        if (birdCollided != prevBirdCollided)
        {
            GameEvents.BirdCollided();
            prevBirdCollided = birdCollided;
        }

        if (birdCollisionAvoided != prevBirdCollisionAvoided)
        {
            GameEvents.BirdCollisionAvoided();
            prevBirdCollisionAvoided = birdCollisionAvoided;
        }

        if (healthDepleted != prevHealthDepleted)
        {
            GameEvents.HealthDepleted();
            prevHealthDepleted = healthDepleted;
        }

        if (gameStartRequested != prevGameStartRequested)
        {
            GameEvents.RequestGameStart();
            prevGameStartRequested = gameStartRequested;
        }

        if (spawnBird)
        {
            birdSpawner.SpawnBird();
            spawnBird = false;
        }
    }
}
