using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    

    Player player;
    Interactables interactables;

    [Header("HUD")]
    public TextMeshProUGUI noteText;
    public Image noteImage;
    public TextMeshProUGUI interactText;
    public TextMeshProUGUI puzzleText;

    [Header("Subtitles")]
    public TextMeshProUGUI subtitleText;
    float subtitleDuration = 5f;
    float subtitleShowTime;


    // Start is called before the first frame update
    void Start()
    {
        interactables = FindObjectOfType<Interactables>();
        player = FindObjectOfType<Player>();



        noteText.enabled = false;
        noteImage.enabled = false;
        interactText.enabled = false;      
    }

    // Update is called once per frame
    void Update()
    {
        HandleSubtitles();

        PuzzleText();
    }

    public void EnableNote(string text)
    {
        player.enabled = false;

        interactText.enabled = false;
        noteText.enabled = true;
        noteText.text = text;
    }

    public void EnableNotePicture(string text, Sprite image)
    {
        player.enabled = false;

        interactText.enabled = false;
        noteText.enabled = true;
        noteImage.enabled = true;
        noteText.text = text;
        noteImage.sprite = image;
    }

    public void CloseNote()
    {
        player.enabled = true;

        noteText.enabled = false;
        noteImage.enabled = false;

    }

    public void EnableUsePrompt()
    {
        interactText.enabled = true;
    }

    public void DisableUsePrompt()
    {
        interactText.enabled = false;
    }

    public void ShowSubtitle(Subtitle subtitle)
    {
        subtitleText.text = subtitle.text;
        subtitleShowTime = Time.time;
        subtitleDuration = subtitle.clip.length * 1.2f;
    }

    void HandleSubtitles()
    {
        if (Time.time >= subtitleShowTime + subtitleDuration)
        {
            subtitleText.text = "";
        }
    }

    void PuzzleText()
    {
        if(LockControl.isUsingPuzzle)
        {
            puzzleText.text = "1 = Left, 2 = Middle, 3 = Right, ESC = quit";
            return;
        }
        else if (PianoControl.isUsingPuzzle)
        {
            puzzleText.text = "1 = C#, 2 = D, 3 = E, 4 = F, ESC = quit";
            return;
        }
        else if (ElectricPuzzle.isUsingPuzzle)
        {
            puzzleText.text = "Rotate with 1 - 6, ESC = quit";
            return;
        }
        else if (ClockScript.isUsingPuzzle)
        {
            puzzleText.text = "1 = Turn Clockwise, 2 = Turn Counter-Clockwise, ESC = quit";
            return;
        }
        puzzleText.text = "";
    }


}
