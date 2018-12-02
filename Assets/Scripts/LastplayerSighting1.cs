using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastplayerSighting1 : MonoBehaviour {
    public Vector3 position = new Vector3(1000f, 1000f, 1000f);
    public Vector3 resetPosition = new Vector3(1000f, 1000f, 1000f);
    public float lightHighIntensity = 0.25f;
    public float lightLowIntensity = 0.0f;
    public float fadeSpeed = 7f;
    public float musicFadeSpeed = 1f;
    private AlarmLight alarmScript;
    private Light mainLight;
    private AudioSource music;
    private AudioSource panicMusic;
    private AudioSource[] sirens;
    private const float muteVolume = 0f;
    private const float normalVolume = 0.8f;

    private void Awake()
    {
        alarmScript = GameObject.FindWithTag(Tags.Alarmlight).GetComponent<AlarmLight>();
        mainLight = GameObject.FindWithTag(Tags.MainLight).GetComponent<Light>();
        music = GetComponent<AudioSource>();
        panicMusic = transform.Find("secondary_music").GetComponent<AudioSource>();
        GameObject[] sirenGameObjects = GameObject.FindGameObjectsWithTag(Tags.Siren);
        sirens = new AudioSource[sirenGameObjects.Length];
        for (int i = 0; i < sirens.Length; i++)
        {
            sirens[i] = sirenGameObjects[i].GetComponent<AudioSource>();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SwitchAlarms()
    {
        alarmScript.alarmOn = (position != resetPosition);
        float newIntensity;
        if (position != resetPosition)
            newIntensity = lightLowIntensity;
        else
            newIntensity = lightHighIntensity;
        mainLight.intensity = Mathf.Lerp(mainLight.intensity, newIntensity, fadeSpeed * Time.deltaTime);
        for (int i = 0; i < sirens.Length; i++)
        {
            if (position != resetPosition && !sirens[i].isPlaying)
                sirens[i].Play();
            else if (position == resetPosition)
                sirens[i].Stop();
        }
    }
}
