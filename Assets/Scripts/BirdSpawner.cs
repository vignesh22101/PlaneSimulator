using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnOrigin, exit;
    [SerializeField] Transform plane;
    [SerializeField] float maxXOffset, maxYOffset;
    [SerializeField] Bird birdPrefab;

    Vector3 originPos;
    GameManager gameManager;
    Coroutine spawingCor;
    float spawnInterval;
    float minSpawnInterval = 2.5f, maxSpawnInterval = 5f;
    float difficultyLevel = 1f;

    private void Awake()
    {
        originPos = spawnOrigin.position;
        spawnInterval = maxSpawnInterval;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        GameEvents.OnGameStartRequested += GameEvents_OnGameStartRequested;
        GameEvents.OnHealthDepleted += GameEvents_OnHealthDepleted;
    }

    private void OnDisable()
    {
        GameEvents.OnGameStartRequested -= GameEvents_OnGameStartRequested;
        GameEvents.OnHealthDepleted -= GameEvents_OnHealthDepleted;
    }

    private void GameEvents_OnHealthDepleted()
    {
        StopSpawingRoutine();
    }

    private void StopSpawingRoutine()
    {
        if (spawingCor != null)
            StopCoroutine(spawingCor);
    }

    private void GameEvents_OnGameStartRequested()
    {
        StopSpawingRoutine();
        spawingCor = StartCoroutine(SpawingRoutine());
    }

    IEnumerator SpawingRoutine()
    {
        while (true)
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval -= 0.1f;
            difficultyLevel += 0.1f;
            spawnInterval = Mathf.Clamp(spawnInterval, minSpawnInterval, maxSpawnInterval);
        }
    }

    public void SpawnBird()
    {
        Vector3 targetPos = originPos;
        targetPos.x = plane.position.x;
        targetPos.y = plane.position.y;
        targetPos.x += Random.Range(-maxXOffset, maxXOffset);
        targetPos.y += Random.Range(-maxYOffset, maxYOffset);
        Bird spawnedBird = Instantiate(birdPrefab).GetComponent<Bird>();
        spawnedBird.transform.position = targetPos;
        spawnedBird.SetParms(difficultyLevel, exit);
    }
}