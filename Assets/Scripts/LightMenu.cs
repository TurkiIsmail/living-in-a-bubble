using UnityEngine;

public class LightMenu : MonoBehaviour
{
    public Light LM; // Reference to the light component
    private float ran;
    private float timer;

    void Start()
    {
       LM=GetComponent<Light>(); 
    }

    void Update()
    {
        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // Check if 1.5 seconds have passed
        if (timer >= 0.1f)
        {
            // Reset the timer
            timer = 0f;

            // Generate a new random intensity and assign it to the light
            ran = Random.Range(0f, 0.9f);
            LM.intensity = ran;
        }
    }
}
