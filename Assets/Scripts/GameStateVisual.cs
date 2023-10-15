using TMPro;
using UnityEngine;

public class GameStateVisual : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI visualInfo;

    private void Awake()
    {
        UpdateVisualInfo("Press start...");
    }

    private void OnEnable()
    {
        GameEvents.OnHealthDepleted += GameEvents_OnHealthDepleted;
    }

    private void OnDisable()
    {
        GameEvents.OnHealthDepleted -= GameEvents_OnHealthDepleted;
    }

    private void GameEvents_OnHealthDepleted()
    {
        UpdateVisualInfo("Game Over!");
    }

    private void UpdateVisualInfo(string info)
    {
        visualInfo.text = info;
    }
}
