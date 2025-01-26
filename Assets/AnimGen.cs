using TMPro;
using UnityEngine;

public class AnimGen : MonoBehaviour
{
    public GameObject boycamm;
    public GameObject momcamm;
    public GameObject pan;
    public TextMeshProUGUI txt;
    int comp=0;
    public GameObject op;
    void Start()
    {
        boycamm.SetActive(true);
        momcamm.SetActive(false);
        pan.SetActive(true);
        txt.text = "Why can’t I join them mum i want to play ? ";
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
              boycamm.SetActive(true);
              momcamm.SetActive(false);
              txt.text = "Why does everyone outside seem fine if they’re sick?";
              comp++;
             }
        else if (Input.GetKeyDown(KeyCode.Space) && comp == 3)
             {
               boycamm.SetActive(false);
               momcamm.SetActive(true);
               txt.text = "I said you're safe here , know take your pills";
               comp++;
             }
        else if (Input.GetKeyDown(KeyCode.Space) && comp == 4)
        {
            boycamm.SetActive(false);
            momcamm.SetActive(true);
            op.SetActive(true);
        }

    }
}
