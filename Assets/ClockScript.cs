using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    public GameObject HourFinger;
    public GameObject MinuteFinger;

    private bool coroutineAllowed = true;

    int minuteRotation = 0;
    int hourRotation = 3;
    public int hourSolution;
    public int minuteSolution;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            if (coroutineAllowed) StartCoroutine("RotateMinuteHand");
        }

        
    }

    
    private IEnumerator RotateMinuteHand()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 9; i++)
        {
            
            MinuteFinger.transform.Rotate(-3f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
            
        }
        minuteRotation += 1;
        StartCoroutine("AnswerCheck");
        coroutineAllowed = true;
        if(minuteRotation == 12)
        {
            StartCoroutine("RotateHourHand");
            minuteRotation = 0;
        }
        
    }

    private IEnumerator RotateHourHand()
    {
        

        for (int i = 0; i <= 9; i++)
        {

            HourFinger.transform.Rotate(-3f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        hourRotation += 1;
        if (hourRotation == 12)
        {
            
            hourRotation = 0;
        }

    }

    private IEnumerator AnswerCheck()
    {
        yield return new WaitForSeconds(2f);
        if (minuteRotation == minuteSolution && hourRotation == hourSolution)
        {
            coroutineAllowed = false;
            //Win Code
        }
    }
}
