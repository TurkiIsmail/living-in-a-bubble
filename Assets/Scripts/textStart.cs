using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textStart : MonoBehaviour
{
    public AudioSource audioSource; // Assign your AudioSource here
    public GameObject word;        // Assign the GameObject "word" here

    private bool hasActivated = false; // To ensure the word activates only once

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
        }

        if (word == null)
        {
            Debug.LogError("GameObject 'word' is not assigned.");
        }

        // Make sure the "word" GameObject is initially inactive
        if (word != null)
        {
            word.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the audio has finished playing
        if (audioSource != null && !audioSource.isPlaying && !hasActivated)
        {
            ActivateWord();
        }
    }

    void ActivateWord()
    {
        if (word != null)
        {
            word.SetActive(true);
            hasActivated = true;
            Invoke("LoadScene4", 3f);
        }
    }
    void LoadScene4()
    {
        SceneManager.LoadScene("Scene4"); // Load scene with index 4
    }
}
