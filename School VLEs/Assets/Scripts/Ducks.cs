using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducks : MonoBehaviour
{
    private GameObject[] ducks;
    // Start is called before the first frame update
    void Start()
    {
        ducks = GameObject.FindGameObjectsWithTag("Duck");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < ducks.Length; i++) {
            //changes the value on each animator to reflect the duck ID, flooring in case there are more ducks than variations of duck
            ducks[i].GetComponent<Animator>().SetInteger("DuckID", Mathf.FloorToInt(i));
        }
        
    }
}
