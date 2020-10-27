using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    
    public TextMeshProUGUI textMesh;
    public int secondsLeft = 30;
    public bool takingAway = false;
 
    void Start()
    {
        
        textMesh.GetComponent<TextMeshProUGUI>().text = "00:" + secondsLeft;
    }
    
        void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }
    
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textMesh.GetComponent<TextMeshProUGUI>().text = "00:0" + secondsLeft;
        }
        else 
        {
            textMesh.GetComponent<TextMeshProUGUI>().text = "00:" + secondsLeft;
        }
        takingAway = false;
    }


}
