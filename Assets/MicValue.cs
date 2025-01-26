using UnityEngine;
using UnityEngine.UI;

public class MicValue : MonoBehaviour
{
    public MicrophoneLoudnessDetector mc;
    float loudness;
    public GameObject CanvasMic;
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
        Slider.value=loudness;
        if(Slider.value>Slider.maxValue)
        {
            print("you gone !");
        }
    
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player")
        {
           mc.gameObject.SetActive(true);
           CanvasMic.SetActive(true);
        }
    }
}
