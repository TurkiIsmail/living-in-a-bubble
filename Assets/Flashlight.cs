using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool isEnabled = true;
    private Light light; // Declare the Light as a class-level variable

    void Start()
    {
        light = gameObject.GetComponent<Light>(); // Initialize the Light component
    }

    void Update()
    {
        // Check if F is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            isEnabled = !isEnabled; // Toggle the enabled state
            light.enabled = isEnabled; // Apply the state to the light
        }
    }
}
