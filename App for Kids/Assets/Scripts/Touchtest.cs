using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchtest : MonoBehaviour {
    private bool touchTap;
    private Vector2 initialTap;
    private double moveTrashhold = 20;
    public Object[] layers;
    private float screenRatio;
    public float moveSpeed;
    private float dmove;
    private float borderLeft;
    private float borderRight;
    private GameObject baseLayer;
    public float slideSlope;
    public float borderBounce;
    private Ray ray;
    private RaycastHit2D hit;
    public float scrollMargin;
    public float marginSpringiness;
    public float marginPressure;
    public float moveSpeedMargin;
    Vector2 moveDistance;
    // Use this for initialization
    void Start() {
        layers = new Object[3];
        layers[0] = baseLayer = GameObject.Find("PositionObject");
        layers[1] = GameObject.Find("0Layer");
        layers[2] = GameObject.Find("1Layer");
        borderLeft = GameObject.Find("BorderLeft").transform.position.x;
        borderRight = GameObject.Find("BorderRight").transform.position.x;
        screenRatio = 2*Camera.main.orthographicSize/Screen.height;
        touchTap=true;
        moveDistance = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0){

            if(Input.GetTouch(0).phase == TouchPhase.Began) {
                touchTap = true;
                initialTap = Input.GetTouch(0).position;
                moveSpeed = 0;
                moveDistance = new Vector2(0,0);
            }

            if((Input.GetTouch(0).position - initialTap).magnitude > moveTrashhold){
                touchTap = false;
                moveDistance = Input.GetTouch(0).deltaPosition;
            }
            if(Input.GetTouch(0).phase == TouchPhase.Ended) {
                if(touchTap) {
                    
                    //ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    //Debug.DrawRay(ray.origin,ray.direction*20,Color.red);
                    //if (Physics.Raycast(ray,out hit,Mathf.Infinity)) {
                    //    hit.transform.Rotate(0,255,122);
                    //    Debug.Log(hit);
                    //}


                }
                else {
                    moveSpeed = (Input.GetTouch(0).deltaPosition.x/Time.deltaTime + moveDistance.x)/2;
                }
            }

            if(Input.GetTouch(0).phase == TouchPhase.Moved) {
                foreach(GameObject layer in layers) {
                layer.transform.Translate(moveDistance.x*screenRatio/layer.transform.position.z,0,0);
                }
            }
        }
        else {
            if (Mathf.Abs(moveSpeed)>moveSpeedMargin) {
                moveSpeed -= Mathf.Sign(moveSpeed)*slideSlope*Time.deltaTime;
                moveSpeed = Mathf.Clamp(baseLayer.transform.position.x+moveSpeed,borderLeft-scrollMargin,borderRight+scrollMargin) - baseLayer.transform.position.x;
            }
            else {
                moveSpeed = 0;
            }

            if(baseLayer.transform.position.x>borderRight) {
                moveSpeed = 0;
                marginPressure = Mathf.Clamp(-(Mathf.Lerp(0.0f,1.0f,Mathf.Abs((Mathf.Abs(baseLayer.transform.position.x) - borderRight) / scrollMargin)) * marginSpringiness * Time.deltaTime),borderRight - baseLayer.transform.position.x,0);
            }
            else if(baseLayer.transform.position.x<borderLeft) {
                moveSpeed = 0;
                marginPressure = Mathf.Clamp((Mathf.Lerp(0.0f,1.0f,Mathf.Abs((Mathf.Abs(baseLayer.transform.position.x) - borderLeft) / scrollMargin)) * marginSpringiness * Time.deltaTime),0,borderLeft - baseLayer.transform.position.x);
                
            }
            else {
                marginPressure = 0;
            }


            foreach(GameObject layer in layers) {
                layer.transform.Translate((moveSpeed*Time.deltaTime-marginPressure)*screenRatio/layer.transform.position.z,0,0);
            }




        }



        //if(moveSpeed != 0) {
        //    dmove = Time.deltaTime*Screen.height*slideSlope;
        //    if(Mathf.Abs(moveSpeed)<dmove) {
        //        moveSpeed = 0;
        //    }
        //    else {
        //        moveSpeed -= dmove*Mathf.Sign(moveSpeed);
        //    }
        //    if(baseLayer.transform.position.x+moveSpeed*Time.deltaTime*screenRatio > borderRight) {
        //        foreach(GameObject layer in layers) {
        //            layer.transform.Translate(borderRight - baseLayer.transform.position.x,0,0);
        //        }
        //    }
        //    else if(baseLayer.transform.position.x-moveSpeed*Time.deltaTime*screenRatio < borderLeft) {
        //        foreach(GameObject layer in layers) {
        //            layer.transform.position = new Vector3(borderRight,0,0);
        //        }
        //    }
        //}



        //if(moveSpeed != 0) {
        //    dmove = Time.deltaTime * slideSlope*100000*Mathf.Pow(Mathf.Abs(moveSpeed),slideSlope-1);
        //    //dmove = (Mathf.Pow(moveSpeed,2F)*0.00008F+200000)*Time.deltaTime;
        //    if(Mathf.Abs(moveSpeed)<1) {
        //        moveSpeed = 0;
        //    }
        //    else {
        //        moveSpeed -= dmove*Mathf.Sign(moveSpeed);
        //    }
        //}

        //if(borderLeft > baseLayer.transform.position.x) {
        //    moveSpeed = (Screen.height * borderBounce)*Time.deltaTime;
        //}
        //else if(borderRight < baseLayer.transform.position.x) {
        //    moveSpeed = (Screen.height * borderBounce)*Time.deltaTime;
        //}

        //foreach(GameObject layer in layers) {
        //    layer.transform.Translate(moveSpeed*Time.deltaTime*screenRatio/layer.transform.position.z,0,0);
        //}

    }
}
