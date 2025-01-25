using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText; // UI Text for dialog
    public string[] lines; // Array of dialog lines
    public float textSpeed; // Speed of typing effect
    public int index; // Current line index
    public bool taskCompleted = false; // Task condition
    public GameObject fadeout;
    public int stopAtLine = -1; // Line index where dialog stops if the task is incomplete

    // Start is called before the first frame update
    void Start()
    {
        dialogText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (dialogText.text == lines[index]) // Ensure current line is fully displayed
            {
                if (index == stopAtLine && !taskCompleted)
                {
                    Debug.Log("Task not completed. Closing dialog.");
                    CloseDialog();
                }
                else
                {
                    NextLine();
                }
            }
            else
            {
                StopAllCoroutines();
                dialogText.text = lines[index]; // Skip typing effect
            }
        }
       if (Keyboard.current.qKey.wasPressedThisFrame){
         CloseDialog();
       }

    }

    public void StartDialog()
    {
        // Reset index only if it is out of bounds (default or invalid value)
        if (index < 0 || index >= lines.Length)
        {
            index = 0; 
        }

    
        dialogText.text = string.Empty; 
        gameObject.SetActive(true); // Ensure dialog is active
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Type each character one by one for the typing effect
        foreach (char c in lines[index].ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

public void NextLine()
{
    if (index < lines.Length - 1)
    {
        index++; // Advance to the next line
        dialogText.text = string.Empty;
        StartCoroutine(TypeLine());
    }
    else if (index == lines.Length - 1)
    {
        // If on the last line, start transitioning to the next scene
        StartCoroutine(LoadNextScene());
         SceneManager.LoadScene("Scene3");
    }
}

IEnumerator LoadNextScene()
{
    fadeout.SetActive(true); // Activate fadeout animation
    print("Fadeout activated.");
    CloseDialog();

    yield return new WaitForSeconds(5f); // Wait for fadeout animation to complete

    print("Loading next scene...");
    // Load the next scene
}

    private void CloseDialog()
    {
        dialogText.text = string.Empty; // Clear dialog text
        gameObject.SetActive(false); // Hide dialog object
    }

}
