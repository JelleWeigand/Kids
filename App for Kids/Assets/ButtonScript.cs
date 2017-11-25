using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public string level;
    public Color startColor;
    public Color mouseOverColor;
    bool mouseOver = false;

    void OnMouseDown()
    {
        // Application.LoadLevel(level);
    }

    void OnMouseOver()
    {
        mouseOver = true;
        // GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

    void OnMouseExit()
    {
        mouseOver = false;
        //  GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }
    
}
