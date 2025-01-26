using TMPro;
using UnityEngine;
using System.Collections;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Gametext : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI txt;
    public GameObject pan;
    void Start()
    {
        txt.text = "I need to know why i eating this pills";
        StartCoroutine(DelayedStartRoutine());
    }
    IEnumerator DelayedStartRoutine()
    {
        // Wait for 1.5 seconds.
        yield return new WaitForSeconds(1.5f);

        // Execute your original Start logic.
        pan.SetActive(false);
        txt.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
