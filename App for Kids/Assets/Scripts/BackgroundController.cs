using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    //class creation
    public class BG {
        public GameObject go;
        public float x;
        public SpriteRenderer  comp;
        public BG(GameObject got ,float xt, SpriteRenderer  compt ) {
            go = got;
            x = xt;
            comp = compt;
        }
    }

    //private variables
    private float x;
    private List<BG> backgrounds;
    private float[] backgroundBorders;
    private GameObject position;
    private BG test;
    private SpriteRenderer SR;
    //public variables
    public float transition;

   
    // Use this for initialization
    void Start() {
        backgrounds = new List<BG>();
        backgrounds.Add(new BG(GameObject.Find("BackgroundSpring"), GameObject.Find("BorderSummer").transform.position.x,GameObject.Find("BackgroundSpring").GetComponent<SpriteRenderer>()));
        backgrounds.Add(new BG(GameObject.Find("BackgroundSummer"), GameObject.Find("BorderAutumn").transform.position.x,GameObject.Find("BackgroundSummer").GetComponent<SpriteRenderer>()));
        backgrounds.Add(new BG(GameObject.Find("BackgroundAutumn"), GameObject.Find("BorderWinter").transform.position.x,GameObject.Find("BackgroundAutumn").GetComponent<SpriteRenderer>()));
        position = GameObject.Find("PositionObject");
        SR = new SpriteRenderer();
    }
	// Update is called once per frame
	void Update () {
        x = position.transform.position.x;
        foreach(BG bg in backgrounds) {
            bg.comp.color = new Color(bg.comp.color.r,bg.comp.color.g,bg.comp.color.b,2*Mathf.Atan((-x+bg.x)*transition)/Mathf.PI+1);
        }
	}
}
