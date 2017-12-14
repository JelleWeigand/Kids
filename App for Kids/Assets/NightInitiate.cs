using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightInitiate : MonoBehaviour {
    private GameObject nighty;
    private SpriteRenderer nightySr;
    // Use this for initialization
    void Awake() {
            
    }
    void Start () {
        nighty = Instantiate(this.gameObject);
        nightySr = nighty.GetComponent<SpriteRenderer>();
        Sprite test = Resources.Load("Sprites and Textures/SnowMan/Background.png",typeof(Sprite)) as Sprite;
        nightySr.sprite = test;
    }
	
	// Update is called once per frame
	void Update () {
        nighty.transform.position = transform.position;
        nightySr.color= new Color(1f,1f,1f,SunScript.nightFac);
	}
}
