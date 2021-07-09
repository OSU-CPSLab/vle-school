using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaterials : MonoBehaviour
{
    public Material[] randomMat = new Material[4];
    public int index;

    void Start() {
        ChangeMaterial(randomMat);
        //randomNumber = Random.Range(0, 3);
        //Debug.Log(randomNumber + " " + randomMat[randomNumber].name);
    }

    void ChangeMaterial(Material[] newMat) {
        Renderer[] children;
        children = GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in children) {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++) {
                mats[j] = newMat[index];
            }
            rend.materials = mats;
        }
    }
}
