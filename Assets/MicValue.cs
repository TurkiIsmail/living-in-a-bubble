using UnityEngine;
using UnityEngine.LowLevelPhysics;
using UnityEngine.UI;

public class MicValue : MonoBehaviour
{
    public MicrophoneLoudnessDetector mc;
        public Image FillImage; // Reference to the Fill area of the slider

    float loudness;
    public GameObject CanvasMic;
    public Color MaxColor = Color.red;
   public Slider Slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
         mc.gameObject.SetActive(false);
         CanvasMic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
        loudness=mc.GetLoudnessFromMicrophone()*10000;
     
        if(Slider.value>=Slider.maxValue)
        {
           Slider.value=120;
           FillImage.color = MaxColor;
        }
        else{
               Slider.value=loudness;
        }
    
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
           mc.gameObject.SetActive(true);
           CanvasMic.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        mc.gameObject.SetActive(false);
           CanvasMic.SetActive(false);
    }
}
