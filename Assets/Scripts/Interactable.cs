using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public string message;
    public UnityEvent onInteraction;
    void Start()
    {
        outline=GetComponent<Outline>();
       DisableOutline();
    }
    public void DisableOutline()
    {
        outline.enabled=false;
    }
    public void EnableOutline()
    {
        outline.enabled=true;
    }
    public void Interact()
    {
        onInteraction.Invoke();
    }


    // Update is called once per frame
   
}
