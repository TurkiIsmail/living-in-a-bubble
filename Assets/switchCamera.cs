using UnityEngine;

public class DialogueCameraController : MonoBehaviour
{
    public Transform character1; // Transform of character 1
    public Transform character2; // Transform of character 2
    public float smoothSpeed = 0.125f; // Speed of camera movement
    public Vector3 offset = new Vector3(0, 2, -3); // Camera offset (position relative to the character)

    private Transform currentTarget; // Current character the camera is focusing on

    void Start()
    {
        // Start by focusing on character1
        currentTarget = character1;
    }

    void LateUpdate()
    {
        if (currentTarget != null)
        {
            // Calculate the desired position behind the character's face based on their rotation
            Vector3 desiredPosition = currentTarget.position
                                      + currentTarget.right * offset.x   // Horizontal offset (left/right)
                                      + currentTarget.up * offset.y      // Vertical offset (above character)
                                      + currentTarget.forward * offset.z; // Depth offset (in front/behind)

            // Smoothly move the camera to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Rotate the camera to look at the character's face
            transform.LookAt(currentTarget.position + currentTarget.up * 1.5f); // Look slightly above to target their face
        }

        // Switch target on Space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTarget();
        }
    }

    void SwitchTarget()
    {
        // Toggle between character1 and character2
        currentTarget = (currentTarget == character1) ? character2 : character1;
    }
}
