using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour {

    public class Layers {
        public GameObject l;
        public float depth;
        public Layers(GameObject lt, float deptht) {
            depth = deptht;
            l = lt;
        }
    }

    //Private Variables
    private Vector2 initialTap;
    private double moveTrashhold = 20;
    public static List<Layers> layers;
    private float screenRatio;
    private float moveSpeed;
    private float dmove;
    private float borderLeft;
    private float borderRight;
    private GameObject baseLayer;
    private Ray ray;
    private RaycastHit2D hit;
    private Vector2 moveDistance;
    private float moveSpeedOld;


    //Public Variables
    public static bool touchTap = false;
    public float scrollMargin;
    public float marginSpringiness;
    public float marginPressure;
    public float moveSpeedMargin;
    public float slideSlope;
    public float slideSlopeExp;


    // Use this for initialization
    void Start() {
        //Adding layers
        layers = new List<Layers>();
        layers.Add(new Layers(GameObject.Find("PositionObject"), GameObject.Find("PositionObject").transform.position.z));
        layers.Add(new Layers(GameObject.Find("0Layer"), GameObject.Find("0Layer").transform.position.z));
        layers.Add(new Layers(GameObject.Find("1Layer"), GameObject.Find("1Layer").transform.position.z));
        layers.Add(new Layers(GameObject.Find("BackgroundLayer"), 10));
        layers.Add(new Layers(GameObject.Find("SunLayer"), 10));
        baseLayer = layers[0].l;


        foreach (Layers l in layers) {
            foreach (Transform child in l.l.transform) {
                if (child.name[child.name.Length - 1] != 'X') {
                    Vector3 pos = child.transform.position;
                    pos[0] = pos[0] / l.depth;
                    child.transform.position = pos;
                }
            }
        }





        //Initializing Variables
        borderLeft = GameObject.Find("BorderLeft").transform.position.x;
        borderRight = GameObject.Find("BorderRight").transform.position.x;
        screenRatio = 2 * Camera.main.orthographicSize / Screen.height;
        moveDistance = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0) {

            //On first finger start of touch
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                touchTap = true;
                initialTap = Input.GetTouch(0).position;
                moveSpeed = 0;
                moveDistance = new Vector2(0, 0);
            }

            //On the end of the first touch
            if (Input.GetTouch(0).phase == TouchPhase.Ended) {

                //If the touch was a tap
                if (touchTap) {


                }

                //If the touch was not a tap
                else {
                    moveSpeed = (Input.GetTouch(0).deltaPosition.x / Time.deltaTime + moveDistance.x) / 2;
                }
            }

            //If the touch is moving
            if (Input.GetTouch(0).phase == TouchPhase.Moved) {
                //Check if it is out of the margin
                if ((Input.GetTouch(0).position - initialTap).magnitude > moveTrashhold) {
                    touchTap = false;
                    moveDistance = Input.GetTouch(0).deltaPosition;
                }

                //Move the world
                foreach (Layers layer in layers) {
                    layer.l.transform.Translate(moveDistance.x * screenRatio / layer.depth, 0, 0);
                }
            }
        }
        //If there are no touches
        else {
            //if the screen is gliding
            if (moveSpeed != 0) {
                moveSpeedOld = moveSpeed;
                moveSpeed -= (Mathf.Sign(moveSpeed) * slideSlope + moveSpeed * slideSlopeExp) * Time.deltaTime;
                moveSpeed = (Mathf.Clamp(baseLayer.transform.position.x + moveSpeed, (borderLeft - scrollMargin) / screenRatio, (borderRight + scrollMargin) / screenRatio) - baseLayer.transform.position.x);
                if (Mathf.Sign(moveSpeed) * Mathf.Sign(moveSpeedOld) < 0) {
                    moveSpeed = 0;
                }
            }

            //if the screen is out of bounds
            if (baseLayer.transform.position.x > borderRight) {
                moveSpeed = 0;
                marginPressure = Mathf.Clamp(-(Mathf.Lerp(0.0f, 1.0f, Mathf.Abs((Mathf.Abs(baseLayer.transform.position.x) - borderRight) / scrollMargin)) * marginSpringiness * Time.deltaTime), borderRight - baseLayer.transform.position.x, 0);
            }
            else if (baseLayer.transform.position.x < borderLeft) {
                moveSpeed = 0;
                marginPressure = Mathf.Clamp((Mathf.Lerp(0.0f, 1.0f, Mathf.Abs((Mathf.Abs(baseLayer.transform.position.x) - borderLeft) / scrollMargin)) * marginSpringiness * Time.deltaTime), 0, borderLeft - baseLayer.transform.position.x);

            }
            else {
                marginPressure = 0;
            }

            //move the layers
            foreach (Layers layer in layers) {
                layer.l.transform.Translate((moveSpeed * Time.deltaTime - marginPressure) * screenRatio / layer.depth, 0, 0);
            }
        }
    }
}
