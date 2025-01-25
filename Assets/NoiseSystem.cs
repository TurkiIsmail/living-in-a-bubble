using UnityEngine;

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
               print("Noise Level: Low");
                break;
            case 1:
                print("Noise Level: Medium");
                break;
            case 2:
               print("Noise Level: High");
                break;
            case 3:
                GameOver();
                break;
        }  

        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightOn = !isFlashlightOn;
            Debug.Log($"Flashlight is now {(isFlashlightOn ? "ON" : "OFF")}");
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
        Debug.Log("DEAD - Noise Level Too High!");
        // Add game over logic here
        currentNoiseLevel = 0f;
        currentNoiseStage = 0;
    }
}
