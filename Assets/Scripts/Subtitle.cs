using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Subtitle", menuName = "Subtitle")]
public class Subtitle : ScriptableObject
{
    public AudioClip clip;
    public string text;
}
