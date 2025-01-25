using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool isEnabled = true;
    private Light light;
     public bool isLighton; // Tracks whether the light is on

    void Start()
    {
        light = gameObject.GetComponent<Light>(); // Initialize the Light component

        // Synchronize isEnabled with the initial state of the Light component
        isEnabled = light.enabled;
        isLighton = isEnabled; // Also synchronize the isLighton variable
    }

    void Update()
    {
        // Check if F is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            isEnabled = !isEnabled; // Toggle the enabled state
            light.enabled = isEnabled; // Apply the state to the Light component
            isLighton = isEnabled; // Update isLighton to reflect the current state
        }
    }
}
