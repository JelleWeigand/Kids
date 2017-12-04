using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        
    }

    void OnMouseUpAsButton()
    {
        if (TouchControl.touchTap)
        {
            Debug.Log("HALLO MART!");
            Application.LoadLevel("MagneticLeaves");
        }
    }
}
