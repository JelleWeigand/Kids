using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesController : MonoBehaviour {

    //clothes class initialization
    public class Clothes {
        public GameObject go;
        public List<Vector2> sL;
        public List<float> dir;
        public Clothes(GameObject got, List<Vector2> sLt, List<float> dirt) {
            go = got;
            sL = sLt;
            dir = dirt;
        }
    }

    //private variable initialization
    private List<Clothes> clothes;
    private List<Vector2> tempList;
    private string tempName;
	// Use this for initialization
	void Start () {
        clothes = new List<Clothes>();


        tempName = "Clothes1";
        GameObject mainC = GameObject.Find(tempName);
        tempList = new List<Vector2>();
        foreach(Transform child in mainC) {
            tempList.Add();
        }
        
        


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
