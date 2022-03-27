using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElectricPuzzle : MonoBehaviour
{
    Player player;

    public AudioSource circuitSound;
    public bool isInteractable = false;
    bool isUsingPuzzle = false;
    public Transform usePosition;
    public Transform cam;
    public List<GameObject> pieces;
    int timesRotated = 0;

    [Header("Lights")]
    public Light LightUp;
    public Light LightMiddle;
    public Light LightDown;

    [Header("Bars")]
    public GameObject leftBar;
    public GameObject middleBar;
    public GameObject rightBar;
    Door leftB;
    Door middleB;
    Door rightB;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        LightUp.enabled = false;
        LightMiddle.enabled = false;
        LightDown.enabled = false;

        leftB = leftBar.GetComponent<Door>();
        middleB = middleBar.GetComponent<Door>();
        rightB = rightBar.GetComponent<Door>();

        RotatePiece(2);
    }

    // Update is called once per frame
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
        if(isUsingPuzzle)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { RotatePiece(0); circuitSound.Play(); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { RotatePiece(1); circuitSound.Play(); }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { RotatePiece(2); circuitSound.Play(); }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { RotatePiece(3); circuitSound.Play(); }
            if (Input.GetKeyDown(KeyCode.Alpha5)) { RotatePiece(4); circuitSound.Play(); }
            if (Input.GetKeyDown(KeyCode.Alpha6)) { RotatePiece(5); circuitSound.Play(); }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isInteractable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
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

    void RotatePiece(int num)
    {
        if (num == 2)
        {
            if (timesRotated % 2 == 0)
            {
                pieces[2].transform.Rotate(90, 0, 0);
                timesRotated++;
                CheckAnswer();
                Debug.Log(Mathf.RoundToInt(pieces[num].transform.rotation.eulerAngles.x));
            }
            else if (timesRotated % 2 != 0)
            {
                pieces[2].transform.Rotate(270, 0, 0);
                timesRotated++;
                CheckAnswer();
                Debug.Log(Mathf.RoundToInt(pieces[num].transform.rotation.eulerAngles.x));
            }
        }
        else
        {
            pieces[num].transform.Rotate(90, 0, 0);
            CheckAnswer();
            Debug.Log(Mathf.RoundToInt(pieces[num].transform.rotation.eulerAngles.x));
        }
    }

    void CheckAnswer()
    {
        if (Mathf.RoundToInt(pieces[0].transform.rotation.eulerAngles.x) == 89  && Mathf.RoundToInt(pieces[1].transform.rotation.eulerAngles.x) == 1 && pieces[2].transform.rotation.eulerAngles.x == 0 && Mathf.RoundToInt(pieces[4].transform.rotation.eulerAngles.x) == 271 && Mathf.RoundToInt(pieces[5].transform.rotation.eulerAngles.x) == 89)
        {
            Debug.Log("ebin yläs");

            LightUp.enabled = true;
            LightMiddle.enabled = false;
            LightDown.enabled = false;

            //leftB.isOpen = true;
            //middleB.isOpen = false;
            //rightB.isOpen = false;

        }
        else if (Mathf.RoundToInt(pieces[0].transform.rotation.eulerAngles.x) == 359 && Mathf.RoundToInt(pieces[1].transform.rotation.eulerAngles.x) == 271 && pieces[2].transform.rotation.eulerAngles.x == 90 && Mathf.RoundToInt(pieces[3].transform.rotation.eulerAngles.x) == 89 && Mathf.RoundToInt(pieces[4].transform.rotation.eulerAngles.x) == 1 && Mathf.RoundToInt(pieces[5].transform.rotation.eulerAngles.x) == 1)
        {
            Debug.Log("ebin Keksi");

            LightUp.enabled = false;
            LightMiddle.enabled = true;
            LightDown.enabled = false;

            //leftB.isOpen = false;
            //middleB.isOpen = true;
            //rightB.isOpen = false;
        }
        else if (Mathf.RoundToInt(pieces[0].transform.rotation.eulerAngles.x) == 89 && Mathf.RoundToInt(pieces[1].transform.rotation.eulerAngles.x) == 1 && pieces[2].transform.rotation.eulerAngles.x == 90 && Mathf.RoundToInt(pieces[3].transform.rotation.eulerAngles.x) == 359)
        {
            Debug.Log("ebin alas");

            LightUp.enabled = false;
            LightMiddle.enabled = false;
            LightDown.enabled = true;

            //leftB.isOpen = false;
            //middleB.isOpen = false;
            //rightB.isOpen = true;
        }
        else
        {
            LightUp.enabled = false;
            LightMiddle.enabled = false;
            LightDown.enabled = false;

            //leftB.isOpen = false;
            //middleB.isOpen = false;
            //rightB.isOpen = false;
        }
    }
}
