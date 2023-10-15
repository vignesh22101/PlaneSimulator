using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeStrength = 0.75f, shakeDuration = 0.5f;

    private void OnEnable()
    {
        GameEvents.OnBirdCollided += GameEvents_OnBirdCollided;
    }

    private void OnDisable()
    {
        GameEvents.OnBirdCollided -= GameEvents_OnBirdCollided;
    }

    private void GameEvents_OnBirdCollided()
    {
        Shake();
    }

    void Shake()
    {
        transform.DOShakePosition(shakeDuration, shakeStrength);
    }
}
