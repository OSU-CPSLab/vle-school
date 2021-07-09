using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FlashingLight1, FlashingLight2, FlashingLight3;
    GameObject roomLights, currentLight;
    bool StartSimulation = false;
    bool SimulationisPlaying = false;
    int randomLight = 0;

    void Start()
    {
        roomLights = GameObject.Find("RoomLights");
        //randomLight = Random.Range(1, 3);
        //Debug.Log("Random light = " + randomLight);
    }

    void FlashingLightSimulation() {
        StartSimulation = true;
    }

    void TurnFlashingLightsOn() {
        Debug.Log("Turning ligh #"+ randomLight + " ON");
        SimulationisPlaying = true;
        roomLights.SetActive(false);
        // CONTINUE HERE ----> 3 random Lights
        if(randomLight == 1) {
            Debug.Log("FlahingLight 1 On");
            FlashingLight1.SetActive(true);
            currentLight = FlashingLight1;
        }

        if (randomLight == 2) {
            Debug.Log("FlahingLight 2 On");
            FlashingLight2.SetActive(true);
            currentLight = FlashingLight2;
        }

        if (randomLight == 3) {
            Debug.Log("FlahingLight 3 On");
            FlashingLight3.SetActive(true);
            currentLight = FlashingLight3;
        }
        
        //FlashingLight1.SetActive(true);
    }

    void TurnFlashingLightsOff() {
        Debug.Log("Turning FlashingLight OFF");
        roomLights.SetActive(true);
        currentLight.SetActive(false);
        SimulationisPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        randomLight = Random.Range(1, 4);

        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            TurnFlashingLightsOn();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            TurnFlashingLightsOff();
        }
    }
}
