using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Increases the width of this highlight back and forth for emphasis.
 */
public class HighlightBob : MonoBehaviour
{
    public float bobSpeed = 0.01f;
    private float maxWidth = 0.013f;
    private float minWidth = 0.005f;

    private bool isShrinking = true;

    private Material highlightMaterial;
    // Start is called before the first frame update
    void Start()
    {
        highlightMaterial = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
       float currentWidth = highlightMaterial.GetFloat("g_flOutlineWidth");

        if (isShrinking)
        {
            if (currentWidth <= minWidth)
            {
                isShrinking = false;
            }
            else
            {
                highlightMaterial.SetFloat("g_flOutlineWidth", currentWidth - bobSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (currentWidth >= maxWidth)
            {
                isShrinking = true;
            }
            else
            {
                highlightMaterial.SetFloat("g_flOutlineWidth", currentWidth + bobSpeed * Time.deltaTime);
            }
        }

        GetComponent<Renderer>().material = highlightMaterial;
    }
}
