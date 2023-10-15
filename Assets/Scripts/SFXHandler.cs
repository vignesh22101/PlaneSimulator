using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXHandler : MonoBehaviour
{
    [SerializeField] AudioSource planeLoop, birdDeath;

    private void OnEnable()
    {
        GameEvents.OnGameStartRequested += GameEvents_OnGameStartRequested;
        GameEvents.OnBirdCollided += GameEvents_OnBirdCollided;
    }

    private void GameEvents_OnBirdCollided()
    {
        birdDeath.Play();
    }

    private void GameEvents_OnGameStartRequested()
    {
        planeLoop.Play();
    }
}
