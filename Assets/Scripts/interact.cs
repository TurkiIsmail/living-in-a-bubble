using UnityEngine;

public class interact : MonoBehaviour
{
    public float interactRange = 5f; // Range within which you can interact
    public LayerMask interactableLayer; // Layer for interactable objects
    private Transform _cameraTransform;
    private GameObject _currentObject; // Keeps track of the currently outlined object
    public GameObject flashlight;

    [Header("Image Interaction")]
    public Canvas fullScreenCanvas; // Canvas for full-screen display
    public GameObject fullScreenPlane; // Plane or box for full-screen display
    private Material originalMaterial; // Stores the original material of the interacted object
    private GameObject originalObject; // Tracks the original game object

    void Start()
    {
        // Reference the main camera
        _cameraTransform = Camera.main.transform;

        // Ensure the full-screen display is disabled initially
        if (fullScreenPlane != null)
        {
            fullScreenPlane.SetActive(false);
        }
    }

    void Update()
    {
        HighlightObject();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteractWithObject();
            FlashlightPickup();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitFullScreen();
        }
    }

    void HighlightObject()
    {
        // Cast a ray from the camera's position forward
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer))
        {
            GameObject hitObject = hit.collider.gameObject;

            // If the ray hits a new object, update the outline
            if (_currentObject != hitObject)
            {
                ClearOutline(); // Remove outline from the previously hit object
                ApplyOutline(hitObject, true); // Add outline to the newly hit object
                _currentObject = hitObject;
            }
        }
        else
        {
            // Clear the outline if the ray doesn't hit anything
            ClearOutline();
        }
    }

    void TryInteractWithObject()
    {
        // Cast a ray from the camera's position forward
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer) && hit.collider.CompareTag("Image"))
        {
            GameObject hitObject = hit.collider.gameObject;
            Renderer renderer = hitObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                // Store the original material and object
                originalMaterial = renderer.material;
                originalObject = hitObject;

                // Display the full-screen image
                fullScreenPlane.SetActive(true);
                Renderer fullScreenRenderer = fullScreenPlane.GetComponent<Renderer>();
                if (fullScreenRenderer != null)
                {
                    fullScreenRenderer.material = originalMaterial; // Use the material of the clicked object
                }
            }
        }
    }

    void ExitFullScreen()
    {
        if (fullScreenPlane.activeSelf)
        {
            // Hide the full-screen plane
            fullScreenPlane.SetActive(false);

            // Reset original references
            originalMaterial = null;
            originalObject = null;
        }
    }
     void FlashlightPickup()
    {
        // Cast a ray from the camera's position forward
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer) && hit.collider.tag == "flashlight") 
        {
            GameObject hitObject = hit.collider.gameObject;

           Destroy(hitObject);
           flashlight.SetActive(true);
            
        }
        
    }

    void ClearOutline()
    {
        if (_currentObject != null)
        {
            ApplyOutline(_currentObject, false); // Disable outline
            _currentObject = null;
        }
    }

    void ApplyOutline(GameObject obj, bool enable)
    {
        // Assume the object has an Outline component
        Outline outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = enable; // Enable or disable the outline
        }
    }
}
