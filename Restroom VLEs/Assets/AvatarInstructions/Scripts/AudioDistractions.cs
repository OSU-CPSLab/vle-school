using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDistractions : MonoBehaviour
{
    //Alarm is inside a gameobject to just active or deactivate object
    public GameObject FireAlarmSound;
    //public GameObject TornadoSirenSound;
    public GameObject FireAlarm;
    public GameObject fireLight;

    public AudioSource policeSiren;
    public AudioSource ambulanceSiren;
    public AudioSource tornadoSiren;
    public AudioSource kidsSound;

    public Animator PoliceSirenAnimator;
    public Animator AmbulanceSirenAnimator;

    float currVolume = 0.0f;
    float maxVolume = 1.0f;
    //public float steadyChangeInVolume;
    bool VolumeIncreasing = false;
    float timer = 0.0f;

    //Light light;

    void Start() {
        //fireLight = FireAlarm.GetComponent<Light>();
    }

    void TurnOnFireAlarm() {
        //Alarm plays on default when it appears on the scene, no need to .Play();\
        Debug.Log("Turning Fire Alarm ON");
        fireLight.SetActive(true);
        //light = fireLight.GetComponent<Light>();
        //light.enabled = true;
        FireAlarmSound.SetActive(true);
    }


    void TurnOffFireAlarm() {
        Debug.Log("Turning Fire Alarm OFF");
        //light.enabled = false;
        //fireLight.SetActive(true);
        //--- --->
        fireLight.SetActive(false);
        FireAlarmSound.SetActive(false);
    }

    void TurnOnPoliceSiren() {
        Debug.Log("Police Siren On");
        PoliceSirenAnimator.SetBool("PoliceSirenOn", true);
        policeSiren.Play();
    }

    void TurnOffPoliceSiren() {
        Debug.Log("Police Siren Off");
        PoliceSirenAnimator.SetBool("PoliceSirenOn", false);
        policeSiren.Stop();
    }

    void TurnOnAmbulanceSiren() {
        Debug.Log("Ambulance Siren On");
        AmbulanceSirenAnimator.SetBool("AmbulanceSirenOn", true);
        ambulanceSiren.Play();
    }

    void TurnOffAmbulanceSiren() {
        Debug.Log("Ambulance Siren Off");
        AmbulanceSirenAnimator.SetBool("AmbulanceSirenOn", false);
        ambulanceSiren.Stop();
    }

    void TurnOnTornadoSiren() {
        Debug.Log("Tornado Siren On");
        tornadoSiren.Play();
    }

    void TurnOffTornadoSiren() {
        Debug.Log("Tornado Siren Off");
        tornadoSiren.Stop();
    }

    void TurnOnKidsSound() {
        Debug.Log("Kids Sound On");
        kidsSound.Play();
    }

    void TurnOffKidsSound() {
        Debug.Log("Kids Sound On");
        kidsSound.Stop();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F1)) {
            TurnOnFireAlarm();
        }

        if (Input.GetKeyUp(KeyCode.F2)) {
            TurnOffFireAlarm();
        }

        if (Input.GetKeyUp(KeyCode.F3)) {
            TurnOnPoliceSiren();
        }

        if (Input.GetKeyUp(KeyCode.F4)) {
            TurnOffPoliceSiren();
        }

        if (Input.GetKeyUp(KeyCode.F5)) {
            TurnOnAmbulanceSiren();
        }

        if (Input.GetKeyUp(KeyCode.F6)) {
            TurnOffAmbulanceSiren();
        }

        if (Input.GetKeyUp(KeyCode.F7)) {
            TurnOnTornadoSiren();
        }

        if (Input.GetKeyUp(KeyCode.F8)) {
            TurnOffTornadoSiren();
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            TurnOnKidsSound();
        }

        if (Input.GetKeyUp(KeyCode.B)) {
            TurnOffKidsSound();
        }
    }
}
