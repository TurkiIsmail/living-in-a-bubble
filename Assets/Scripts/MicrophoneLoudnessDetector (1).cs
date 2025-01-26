using UnityEngine;

public class MicrophoneLoudnessDetector : MonoBehaviour
{
    public float loudnessThreshold = 0.1f; // Threshold for loudness to trigger action
    public string microphoneName = "";    // Leave empty for the default microphone
    public GameObject actionObject;       // Object to trigger action on

    private AudioSource audioSource;

    void Start()
    {
        // Initialize AudioSource and Microphone
        audioSource = gameObject.AddComponent<AudioSource>();
        if (Microphone.devices.Length > 0)
        {
            microphoneName = Microphone.devices[0]; // Use the first available microphone
            audioSource.clip = Microphone.Start(microphoneName, true, 10, 44100);
            audioSource.loop = true;

            // Wait until the microphone starts recording
            while (!(Microphone.GetPosition(microphoneName) > 0)) { }

            audioSource.Play();
        }
        else
        {
            Debug.LogError("No microphone detected!");
        }
    }

    void Update()
    {
        if (audioSource.clip != null)
        {
            float loudness = GetLoudnessFromMicrophone()*10000;
       

            if (loudness > loudnessThreshold)
            {
                TriggerAction();
            }
        }
    }

    float GetLoudnessFromMicrophone()
    {
        // Get audio data from the microphone
        float[] data = new float[256];
        audioSource.GetOutputData(data, 0);

        // Calculate loudness (RMS value)
        float sum = 0f;
        foreach (float sample in data)
        {
            sum += sample * sample;
        }

        return Mathf.Sqrt(sum / data.Length);
    }

    void TriggerAction()
    {
        Debug.Log("Loudness exceeded! Action triggered.");

        // Example action: Enable or disable a GameObject
        if (actionObject != null)
        {
            actionObject.SetActive(!actionObject.activeSelf);
        }
    }
}