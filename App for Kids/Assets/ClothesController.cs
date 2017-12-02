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


    //public variables
    public static bool hold = false;
    public static GameObject holdObject;
    public static bool snap = false;
    public static GameObject snapObject;
	// Use this for initialization
	void Start () {
        clothes = new List<Clothes>();


        tempName = "Clothes1";
        GameObject mainC = GameObject.Find(tempName);
        tempList = new List<Vector2>();
        foreach(Transform child in mainC.transform) {
            tempList.Add(new Vector2(child.transform.position.x, child.transform.position.y));
        }
        
        


		
	}




    // Update is called once per frame
    void LateUpdate () {
        if(Input.touchCount != 0 && hold) {
            if (snap) {
                holdObject.transform.position = new Vector3(snapObject.transform.position.x, snapObject.transform.position.y, holdObject.transform.position.z);
                holdObject.transform.rotation = snapObject.transform.rotation;
            }
            else {
                holdObject.transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            
        }
        snap = false;
	}

    void OnMouseUp() {
        hold = false;    
    }
}
