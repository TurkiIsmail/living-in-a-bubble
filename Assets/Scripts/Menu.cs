using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Menu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void TakePills()
    {
        SceneManager.LoadScene("Scene3");
        
    }

    public void NoPills()
    {
        SceneManager.LoadScene("Scene5");
        
    }
}
