﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour {
    public float fadeSpeed = 2.0f;
    public float highIntensity = 4.0f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;
    public bool alarmOn;
    private float targetIntensity;
    private Light alarmLight;
    // Use this for initialization
    private void Awake()
    {
        alarmLight = GetComponent<Light>();
        alarmLight.intensity = 0f;
        targetIntensity = highIntensity;
    }

    void CheckTargetIntensity()
    {
        if (Mathf.Abs(targetIntensity - alarmLight.intensity) < changeMargin)
        {
            if (targetIntensity == highIntensity)
            {
                targetIntensity = lowIntensity;
            } else
            {
                targetIntensity = highIntensity;
            }
        }
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (alarmOn)
        {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity();
        } else
        {
            alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, 0, fadeSpeed * Time.deltaTime);
        }
	}
}
