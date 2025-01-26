using UnityEngine;

public class dooropen : MonoBehaviour
{
    public float openAngle = -90f; // Angle to open the door
    public float closeAngle = 0f; // Angle to close the door
    public float doorSpeed = 2f;  // Speed of door movement

    public bool isOpen = false; // Tracks door state
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        // Save the initial rotation as the closed position
        closedRotation = transform.rotation;
        // Calculate the open rotation
        openRotation = Quaternion.Euler(transform.eulerAngles + Vector3.up * openAngle);
    }

    void Update()
    {
        // Smoothly rotate the door to its target position
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * doorSpeed);
    }

    // Public method to toggle the door state
    public void ToggleDoor()
    {
        isOpen = !isOpen; // Toggle door state
    }
}
