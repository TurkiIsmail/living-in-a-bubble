using UnityEngine;

public class interact : MonoBehaviour
{
    public float interactRange = 5f; // Range within which you can interact
    public LayerMask interactableLayer; // Layer for interactable objects
    private Transform _cameraTransform;

    void Start()
    {
        // Reference the main camera
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Check for interaction input
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        // Cast a ray from the camera's position forward
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer))
        {
            // If the ray hits something, print "E"
            Debug.Log("E");
        }
    }
}






  
