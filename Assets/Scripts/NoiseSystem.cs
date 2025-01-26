using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NoiseSystem : MonoBehaviour
{ public float maxNoiseLevel = 100f;
    public float noiseDecayRate = 10f;
    private float currentNoiseLevel = 0f;
    private int currentNoiseStage = 0;


    [Header("Noise Values Per Action")]
   
    public float runNoise = 20f;
   
    public float flashlightNoise = 20f;

    
    public PlayerMovement mv; 
    public Flashlight fl; 
    public bool isRunning = false;
    public bool isFlashlightOn = false;
  public Image image1;
    public Image image2;
    public Image image3;
    public GameObject mom;
    void Start()
    {
        mv = mv.GetComponent<PlayerMovement>();
        fl = fl.GetComponent<Flashlight>();
    }

    void Update()
    {
        isRunning = mv.IsRuning;
        isFlashlightOn = fl.isLighton; 
        
        CalculateNoise();
        
        if (currentNoiseLevel > 0)
        {
            currentNoiseLevel -= noiseDecayRate * Time.deltaTime;
            currentNoiseLevel = Mathf.Max(currentNoiseLevel, 0f);
        }

        UpdateNoiseStage();
    
       
        switch (currentNoiseStage)
        {
            case 0:
               
                SetImageProperties(image1, 0.3f, Color.white);
                SetImageProperties(image2, 0.3f, Color.white);
                SetImageProperties(image3, 0.3f, Color.white);
                break;

            case 1:
              
                SetImageProperties(image1, 1f, Color.white);
                SetImageProperties(image2, 0.3f, Color.white);
                SetImageProperties(image3, 0.3f, Color.white);
                break;

            case 2:
               
                SetImageProperties(image1, 1f, Color.white);
                SetImageProperties(image2, 1f, Color.white);
                SetImageProperties(image3, 0.3f, Color.white);
                break;

            case 3:
              
                Color redColor = Color.red;
                SetImageProperties(image1, 1f, redColor);
                SetImageProperties(image2, 1f, redColor);
                SetImageProperties(image3, 1f, redColor);
                GameOver();
                break;
        } 

        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn;
            
        }
    }

    void CalculateNoise()
    {
        if (isFlashlightOn)
        {
            currentNoiseLevel += flashlightNoise * Time.deltaTime;
            
        }
        if (isRunning)
            {
                currentNoiseLevel += runNoise * Time.deltaTime;
            
            }

           
            

      
    }

    void UpdateNoiseStage()
    {
        int newNoiseStage = Mathf.FloorToInt(currentNoiseLevel / (maxNoiseLevel / 3));
        currentNoiseStage = Mathf.Clamp(newNoiseStage, 0, 3);
    }

    void GameOver()
    {

        // Add game over logic here
        mom.GetComponent<AISIMPLE>().enabled = true;
        mom.GetComponent<NavMeshAgent>().enabled = true;
        currentNoiseLevel = 0f;
        currentNoiseStage = 0;
    }
     public void SetImageProperties(float opacity, Color color)
    {
        // Clamp opacity between 0 and 1
        opacity = Mathf.Clamp(opacity, 0f, 1f);

        // Set properties for each image
        if (image1 != null)
        {
            SetImageProperties(image1, opacity, color);
        }

        if (image2 != null)
        {
            SetImageProperties(image2, opacity, color);
        }

        if (image3 != null)
        {
            SetImageProperties(image3, opacity, color);
        }
    }

    private void SetImageProperties(Image img, float opacity, Color color)
    {
        // Update the color with the new opacity
        Color newColor = color;
        newColor.a = opacity;
        img.color = newColor;
    }
}
