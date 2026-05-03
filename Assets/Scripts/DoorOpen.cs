using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float openAngle = 90f;   // how much it opens
    public float openSpeed = 2f;    // speed of opening

    private Quaternion startRotation;
    private Quaternion targetRotation;

    void Start()
    {
        startRotation = transform.rotation;

        // Rotate to the RIGHT (Y axis)
        targetRotation = startRotation * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        // Smoothly rotate toward target
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * openSpeed
        );
    }
}