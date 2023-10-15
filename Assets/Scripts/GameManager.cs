using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.VirtualTexturing;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    ScoreHandler scoreHandler;
    public int CurrentScore => scoreHandler.Score;

    private void Awake()
    {
        scoreHandler=FindObjectOfType<ScoreHandler>();
        menuPanel.SetActive(true);
    }

    private void OnEnable()
    {
        GameEvents.OnHealthDepleted += GameEvents_OnHealthDepleted;
        GameEvents.OnGameStartRequested += GameEvents_OnGameStartRequested;
    }

    private void OnDisable()
    {
        GameEvents.OnHealthDepleted -= GameEvents_OnHealthDepleted;
        GameEvents.OnGameStartRequested -= GameEvents_OnGameStartRequested;
    }

    private void GameEvents_OnGameStartRequested()
    {
        menuPanel.SetActive(false);
    }

    private void GameEvents_OnHealthDepleted()
    {
        GameOver();
    }

    private void GameOver()
    {
        menuPanel.SetActive(true);
    }
}
