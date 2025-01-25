using UnityEngine;

public class NoiseSystem : MonoBehaviour
{
    public float maxNoiseLevel = 100f; // Maximum noise level before reaching level 3
    public float noiseDecayRate = 5f; // How quickly noise decays over time
    private float currentNoiseLevel = 0f; // Tracks the player's current noise level
    private int currentNoiseStage = 0; // Noise level (1, 2, or 3)

    [Header("Noise Values Per Action")]
    public float walkNoise = 10f;
    public float runNoise = 20f;
    public float crouchNoise = 5f;
    public float flashlightNoise = 3f; // Noise added when the flashlight is on

    [Header("Player State")]
    public PlayerMovement mv; 
    public Flashlight fl; 
    public bool isRunning = false; // Whether the player is running
    public bool isFlashlightOn = false; // Whether the flashlight is on

    private CharacterController _characterController;

    void Start()
    {
        // Get reference to the player's CharacterController
        _characterController = GetComponent<CharacterController>();
         isRunning=mv.isRuning;
         isFlashlightOn=fl.isLighton;
    }

    void Update()
    {
        CalculateNoise();

        // Decay noise over time when no input is given
        if (currentNoiseLevel > 0)
        {
            currentNoiseLevel -= noiseDecayRate * Time.deltaTime;
            currentNoiseLevel = Mathf.Max(currentNoiseLevel, 0f); // Clamp to 0
        }

        UpdateNoiseStage();

        // Print "Dead" when noise level reaches stage 3
        if (currentNoiseStage == 3)
        {
            Debug.Log("Dead");
            // Reset or handle death logic
            currentNoiseLevel = 0f;
            currentNoiseStage = 0;
        }

        // Toggle flashlight on/off with F
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn;
            Debug.Log($"Flashlight is now {(isFlashlightOn ? "ON" : "OFF")}");
        }
    }

    void CalculateNoise()
    {
        // Base noise from flashlight
        if (isFlashlightOn)
        {
            currentNoiseLevel += flashlightNoise * Time.deltaTime;
        }

        // Movement-based noise
        if (_characterController.isGrounded && _characterController.velocity.magnitude > 0)
        {
            if (isRunning) // Running
            {
                currentNoiseLevel += runNoise * Time.deltaTime;
            }
            else // Walking
            {
                currentNoiseLevel += walkNoise * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.C)) // Crouching
        {
            currentNoiseLevel += crouchNoise * Time.deltaTime;
        }
    }

    void UpdateNoiseStage()
    {
        // Calculate noise stage based on noise level
        int newNoiseStage = Mathf.FloorToInt(currentNoiseLevel / (maxNoiseLevel / 3));

        if (newNoiseStage != currentNoiseStage)
        {
            currentNoiseStage = newNoiseStage;
            Debug.Log($"Noise Level: {currentNoiseStage}");
        }

        // Clamp noise stage to a maximum of 3
        currentNoiseStage = Mathf.Clamp(currentNoiseStage, 0, 3);
    }
}
