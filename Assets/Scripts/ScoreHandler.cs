using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValue;

    int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        scoreValue.text = Score.ToString();
    }

    private void OnEnable()
    {
        GameEvents.OnBirdCollisionAvoided += GameEvents_OnBirdCollisionAvoided;
        GameEvents.OnGameStartRequested += GameEvents_OnGameStartRequested;
    }

    private void OnDisable()
    {
        GameEvents.OnBirdCollisionAvoided -= GameEvents_OnBirdCollisionAvoided;
        GameEvents.OnGameStartRequested -= GameEvents_OnGameStartRequested;
    }

    private void GameEvents_OnGameStartRequested()
    {
        ResetScore();
    }

    private void ResetScore()
    {
        Score = 0;
    }

    private void GameEvents_OnBirdCollisionAvoided()
    {
        Score++;
    }
}
