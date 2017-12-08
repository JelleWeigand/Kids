using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesController : MonoBehaviour {

    //clothes class initialization


    //private variable initialization


    //public variables
    public float pickupScale;
    public static Dictionary<string,GameObject> clothes;
    public float scale;
     

	// Use this for initialization
	void Start () {
        clothes = new Dictionary<string,GameObject> {
            { "hat",null },
            { "nose",null}
        };
    }




    // Update is called once per frame
    void LateUpdate () {
        
	}


    void OnMouseUp() { 
    }
}
