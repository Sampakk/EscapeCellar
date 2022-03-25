using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    Light light;

    public Vector2 flickerRange = new Vector2(0, 5f);
    public float flickerSpeed = 2f;

    float targetIntensity;
    bool changing;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!changing)
        {
            changing = true;

            targetIntensity = Random.Range(flickerRange.x, flickerRange.y);          
        }
        else
        {
            light.intensity = Mathf.MoveTowards(light.intensity, targetIntensity, flickerSpeed * Time.deltaTime);

            if (light.intensity == targetIntensity)
                changing = false;
        }   
    }
}
