using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    [Range(1, 10)]
    public float SmoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(
            transform.position,
            targetPosition,
            SmoothFactor * Time.fixedDeltaTime
        );
        transform.position = targetPosition;
    }
}
