using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar_Pointing_Objects : MonoBehaviour
{
    public int currentState = 0;
    private bool complete = false;
    public Animator _anim;
    public Transform _root;
    public GameObject[] importantObjects;
    GameObject currentText;

    public AudioClip[] clips;
    public AudioSource _as;
    Vector3 targetPosition;

    public Material highlightedMaterial;
    Material oldMaterial;
    MeshRenderer meshRend;
    public GameObject ArrowPointing;
    Vector3 currentObjectLocation;


    void Start()
    {
        importantObjects = GameObject.FindGameObjectsWithTag("objectsOfInterest");
        StartCoroutine(introductionCoroutine());
        /*
        _as.clip = clips[currentState];
        _as.Play();
        targetPosition = new Vector3(importantObjects[currentState].transform.position.x, _root.transform.position.y, importantObjects[currentState].transform.position.z);
        _root.LookAt(targetPosition);
        importantObjects[currentState].transform.GetChild(0).gameObject.SetActive(true);

        ArrowPointing.transform.position = new Vector3(importantObjects[currentState].transform.position.x, importantObjects[currentState].transform.position.y + 1, importantObjects[currentState].transform.position.z);

        meshRend = importantObjects[currentState].GetComponent<MeshRenderer>();
        oldMaterial = meshRend.material;
        meshRend.material = highlightedMaterial;
        */
    }

    void Update()
    {
            try
            {
            if (!_as.isPlaying && !complete)
            {
                meshRend.material = oldMaterial;
                importantObjects[currentState].transform.GetChild(0).gameObject.SetActive(false);
                currentState++;
                _as.clip = clips[currentState];
                _as.Play();

                targetPosition = new Vector3(importantObjects[currentState].transform.position.x, _root.transform.position.y, importantObjects[currentState].transform.position.z);
                _root.LookAt(targetPosition);
                ArrowPointing.transform.position = new Vector3(importantObjects[currentState].transform.position.x, importantObjects[currentState].transform.position.y + 1.3f, importantObjects[currentState].transform.position.z);
                importantObjects[currentState].transform.GetChild(0).gameObject.SetActive(true);

                meshRend = importantObjects[currentState].GetComponent<MeshRenderer>();
                oldMaterial = meshRend.material;
                meshRend.material = highlightedMaterial;

                if (currentState > importantObjects.Length)
                {
                    complete = true;
                    currentState = 0;
                }
            }
        }
        catch (System.IndexOutOfRangeException e)
        {
            _anim.SetBool("isDone", true);
            ArrowPointing.SetActive(false);
            currentState = 0;
            complete = true;
        }
    }

    IEnumerator waitForSound()
    {
        while (_as.isPlaying)
        {
            yield return null;
        }
        meshRend.material = oldMaterial;
        currentState++;
        if (currentState > importantObjects.Length)
        {
            _anim.SetBool("isDone", true);
            currentState = 0;
            ArrowPointing.SetActive(false);
        }
    }

    IEnumerator introductionCoroutine()
    {
        //Number can still change based on how long the introduction audio is, also add as many animations for talking as need since it wont be looping
        yield return new WaitForSeconds(11);
        _as.clip = clips[currentState];
        _as.Play();
        targetPosition = new Vector3(importantObjects[currentState].transform.position.x, _root.transform.position.y, importantObjects[currentState].transform.position.z);
        _root.LookAt(targetPosition);
        importantObjects[currentState].transform.GetChild(0).gameObject.SetActive(true);

        ArrowPointing.transform.position = new Vector3(importantObjects[currentState].transform.position.x, importantObjects[currentState].transform.position.y + 1.25f, importantObjects[currentState].transform.position.z);

        meshRend = importantObjects[currentState].GetComponent<MeshRenderer>();
        oldMaterial = meshRend.material;
        meshRend.material = highlightedMaterial;
    }
}