using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    Player player;

    public GameObject HourFinger;
    public GameObject MinuteFinger;

    private bool coroutineAllowed = true;

    int minuteRotation = 0;
    int hourRotation = 3;
    public int hourSolution;
    public int minuteSolution;

    public bool isInteractable = false;
    bool isUsingPuzzle = false;

    public Transform usePosition;
    public Transform cam;

    void Start()
    {
        player = FindObjectOfType<Player>();

    }
    void Update()
    {

        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            UsePuzzle();
            
        }

        if (isUsingPuzzle && Input.GetKeyDown(KeyCode.Escape))
        {
            StopPuzzle();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && isUsingPuzzle)
        {
            if (coroutineAllowed) StartCoroutine("RotateMinuteHand");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInteractable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInteractable = false;
        }
    }

    void UsePuzzle()
    {
        player.transform.parent = usePosition;
        player.transform.localPosition = Vector3.zero;
        player.GetComponent<Player>().enabled = false;


        player.transform.LookAt(gameObject.transform.position);
        cam.localRotation = Quaternion.identity;

        isUsingPuzzle = true;
    }

    void StopPuzzle()
    {
        player.transform.parent = null;
        player.GetComponent<Player>().enabled = true;

        player.transform.rotation = Quaternion.identity;
        player.transform.rotation = Quaternion.Euler(0f, 270, 0);

        isUsingPuzzle = false;
    }

    private IEnumerator RotateMinuteHand()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 9; i++)
        {          
            MinuteFinger.transform.Rotate(0f, 0f, 3f);
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
            HourFinger.transform.Rotate(0f, 0f, 3f);
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
