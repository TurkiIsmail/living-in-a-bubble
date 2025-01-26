using TMPro;
using UnityEngine;
using System.Collections;

public class AnimGen : MonoBehaviour
{
    public GameObject boycamm;
    public GameObject boy;
    public GameObject boy2;
    public GameObject boycamm2;
    public GameObject momcamm;
    public GameObject pan;
    public TextMeshProUGUI txt;
    int comp=0;
    public GameObject op;
    public Animator anim;
    void Start()
    {
        StartCoroutine(DelayedStartRoutine());
        anim = GetComponent<Animator>();
    }
    IEnumerator DelayedStartRoutine()
    {
        // Wait for 1.5 seconds.
        yield return new WaitForSeconds(1.5f);

        // Execute your original Start logic.
        boycamm.SetActive(true);
        boy.SetActive(true);
        boy2.SetActive(false);
        momcamm.SetActive(false);
        pan.SetActive(true);
        txt.text = "Why can’t I join them mum I want to play?";
        comp++;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && comp==1) {
            boycamm.SetActive(false);
            momcamm.SetActive(true);
            txt.text = "You can’t. Everyone out there is sick. You’re safe here. ";
            comp++;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && comp == 2)
             {
              boycamm2.SetActive(true);
              momcamm.SetActive(false);
            boy.SetActive(false);
            boy2.SetActive(true);
            txt.text = "Why does everyone outside seem fine if they’re sick?";
              comp++;
             }
        else if (Input.GetKeyDown(KeyCode.Space) && comp == 3)
             {
               boycamm2.SetActive(false);
               momcamm.SetActive(true);
               txt.text = "I said you're safe here , now take your pills";
               comp++;
             }
        else if (Input.GetKeyDown(KeyCode.Space) && comp == 4)
        {
            boycamm2.SetActive(false);
            momcamm.SetActive(true);
            boy.SetActive(false);
            boy2.SetActive(true);
            op.SetActive(true);
        }

    }
}
