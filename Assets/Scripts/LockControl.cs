using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    void Start()
    {
        result = new int[] { 0, 0, 0 };
        correctCombination = new int[] { 3, 7, 9 };
        LockWheelRotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "wheel1":
                result[0] = number;
                break;
            case "wheel2":
                result[1] = number;
                break;
            case "wheel3":
                result[2] = number;
                break;
        }
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination [2])
        {
            Debug.Log("Opened!");
            //open chest code
        }
    }

    private void OnDestroy()
    {
        LockWheelRotate.Rotated -= CheckResults;
    }

}
