using DG.Tweening;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private float difficultyLevel;
    [SerializeField] private float minDuration, maxDuration;
    [SerializeField] private float minAnimSpeed = 0.5f, maxAnimSpeed = 1.5f;
    [SerializeField] Animator animator;
    Transform exit;


    private void Start()
    {
        Invoke(nameof(Initialize), 0.1f);
    }

    private void Initialize()
    {
        float duration = (1 / difficultyLevel) * 10;
        float distanceToExit = Vector3.Distance(transform.position, exit.position);
        duration = Mathf.Clamp(duration, minDuration, maxDuration);
        Vector3 targetPos = transform.position + (transform.forward * (distanceToExit + 1));
        transform.DOMove(targetPos, duration);
        animator.speed = Mathf.Clamp(difficultyLevel / 2, minAnimSpeed, maxAnimSpeed);
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
        SelfTerminate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagNames.BirdExitTrigger))
        {
            GameEvents.BirdCollisionAvoided();
            SelfTerminate();
        }
        else if (other.CompareTag(TagNames.PlaneTrigger))
        {
            GameEvents.BirdCollided();
            SelfTerminate();
        }
    }

    private void SelfTerminate()
    {
        Destroy(gameObject);
    }

    internal void SetParms(float difficultyLevel, Transform exit)
    {
        this.difficultyLevel = difficultyLevel;
        this.exit = exit;
    }
}
