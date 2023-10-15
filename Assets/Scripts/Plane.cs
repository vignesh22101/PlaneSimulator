using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] Transform viewCentre;
    [SerializeField] float xOffset, yOffset;
    float xBound, yBound;

    private void Awake()
    {
        xBound = viewCentre.position.x + xOffset;
        yBound = viewCentre.position.y + yOffset;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * 50f;
        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * 50f;

        MovePlane(horizontalInput, verticalInput);
    }

    void MovePlane(float horizontal, float vertical)
    {
        Vector3 targetPos = transform.position + new Vector3(horizontal, vertical, 0f);
        targetPos.x = Mathf.Clamp(targetPos.x, -xBound, xBound);
        targetPos.y = Mathf.Clamp(targetPos.y, -yBound, yBound);
        transform.position = targetPos;
    }
}
