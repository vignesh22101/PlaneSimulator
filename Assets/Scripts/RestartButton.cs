using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI visualInfo;

    private void Awake()
    {
        UpdateVisualInfo("Start");
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(RestartRequested);
        
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(RestartRequested);
        GameEvents.OnHealthDepleted += GameEvents_OnHealthDepleted;
    }

    private void GameEvents_OnHealthDepleted()
    {
        UpdateVisualInfo("Restart");
    }

    private void UpdateVisualInfo(string info)
    {
        visualInfo.text = info;
    }

    private void RestartRequested()
    {
        GameEvents.RequestGameStart();
    }
}
