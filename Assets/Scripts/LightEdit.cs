using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LightEdit : MonoBehaviour
{
    [SerializeField] [Range(1, 200)] int frequency = 100; 
    [SerializeField] float waitingTime = 1f; 
    [SerializeField] float minRange = 1f; 
    [SerializeField] float maxRange = 10f; 

    private Light _light;
    private bool isScaling;

    void Start()
    {
        _light = GetComponent<Light>(); 
        isScaling = false; 
    }

    void Update()
    {
        if (!isScaling)
        {
            StartCoroutine(ScaleLight());
        }
    }

    IEnumerator ScaleLight()
    {
        isScaling = true; 
        float elapsedTime = 0f;

        while (true)
        {
            elapsedTime += Time.deltaTime;
            float sineValue = Mathf.Sin(elapsedTime * frequency * Mathf.PI * 2 / waitingTime);
            
            _light.range = Mathf.Lerp(minRange, maxRange, (sineValue + 1) / 2);

            
            yield return null; 
        }
    }
}