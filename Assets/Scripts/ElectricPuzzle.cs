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


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

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
            }
            else if (timesRotated % 2 != 0)
            {
                pieces[2].transform.Rotate(270, 0, 0);
                timesRotated++;
                CheckAnswer();
            }
        }
        else
        {
            pieces[num].transform.Rotate(90, 0, 0);
            CheckAnswer();
        }
    }

    void CheckAnswer()
    {
        if (pieces[0].transform.rotation.eulerAngles.x == 90  && pieces[1].transform.rotation.eulerAngles.x == 0 && pieces[2].transform.rotation.eulerAngles.x == 0 && pieces[4].transform.rotation.eulerAngles.x == 270 && pieces[5].transform.rotation.eulerAngles.x == 90)
        {
            Debug.Log("ebin yläs");
        }
        else if (pieces[0].transform.rotation.eulerAngles.x == 0 && pieces[1].transform.rotation.eulerAngles.x == 270 && pieces[2].transform.rotation.eulerAngles.x == 90 && pieces[3].transform.rotation.eulerAngles.x == 90 && pieces[4].transform.rotation.eulerAngles.x == 0 && pieces[5].transform.rotation.eulerAngles.x == 0)
        {
            Debug.Log("ebin Keksi");
        }
        else if (pieces[0].transform.rotation.eulerAngles.x == 90 && pieces[1].transform.rotation.eulerAngles.x == 0 && pieces[2].transform.rotation.eulerAngles.x == 90 && pieces[3].transform.rotation.eulerAngles.x == 0)
        {
            Debug.Log("ebin alas");
        }
    }
}
