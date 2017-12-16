using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelControllerMain : MonoBehaviour {

    private float diagonal;
    private GameObject mask;
    private GameObject maskExit;
    private GameObject positionObject;
    private string loadLevelName;
    private bool fadeOut = false;
    private SpriteRenderer gameIconRenderer;

    public float maskScale;
    public static float startTime;
    public static float exitTime;
    public static Vector3 exitLocation;
    public static bool enter = false;
    public static bool exit = false;
    public static bool loadScreen = false;
    public static bool load = true;
    public static string loadLevel;
    public float transitionTime;
    public float loadTime;
    public string backButton;
    public float fadeTime;

    public void LoadLevel(GameObject GO,string levelName) {
        exit = true;
        fadeOut = true;
        loadLevelName = levelName;
        exitTime = Time.time;
        gameIconRenderer = GO.GetComponent<SpriteRenderer>();
        gameIconRenderer.sortingOrder = 1;
        maskExit.transform.position = new Vector3(GO.transform.position.x, GO.transform.position.y, maskExit.transform.position.z);
        diagonal = 2*Mathf.Pow(Mathf.Pow(Camera.main.orthographicSize* Camera.main.aspect+ Mathf.Abs(GO.transform.position.x), 2)+
            Mathf.Pow(Camera.main.orthographicSize+Mathf.Abs(GO.transform.position.y) , 2), 0.5f);
    }

    public void Exit(string levelName) {
        exit = true;
        fadeOut = false;
        if(levelName == "BackButton") {
            loadLevelName = backButton;
        }
        else {
            loadLevelName = levelName;
        }
        loadLevelName = levelName;
        exitTime = Time.time;
        maskExit.transform.position = new Vector3(0,0, maskExit.transform.position.z);
        diagonal = Camera.main.orthographicSize * 2 * Mathf.Pow(Mathf.Pow(Camera.main.aspect, 2f) + 1, 0.5f);
    }

    // Use this for initialization
    void Start() {
        enter = false;
        exit = false;
        loadScreen = false;
        load = true;
        positionObject = GameObject.Find("PositionObject");
        diagonal = 2 * Camera.main.orthographicSize * Mathf.Pow(Mathf.Pow(Camera.main.aspect, 2) + 1, 0.5f);
        mask = GameObject.Find("MaskLoadScene");
        maskExit = GameObject.Find("MaskUnloadScene");
        maskExit.transform.localScale = new Vector3(0, 0, 1);
        mask.transform.localScale = new Vector3(0, 0, 1);
        startTime = Time.time;
	}


    IEnumerator LoadNewScene(string name) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }

    void Update () {
        if(load) {
            if(Time.time-startTime > loadTime) {
                startTime = Time.time;
                enter = true;
                load = false;
            }
        }
        if(enter) {
            float x = (Time.time - startTime)/transitionTime;
            float scale = x*1.1f*diagonal/maskScale;
            mask.transform.localScale = new Vector3(scale,scale,1);
            if(x>1) {
                enter = false;
            }
        }
        if (exit) {
            float x = (Time.time - exitTime) / transitionTime;
            float scale = x * 1.1f * diagonal/maskScale;
            maskExit.transform.localScale = new Vector3(scale, scale, 1);
            if (x > 1) {
                exit = false;
                if (fadeOut) {
                    loadScreen = true;
                    startTime = Time.time;
                }
                else {
                    StartCoroutine(LoadNewScene(loadLevelName));
                }
            }
        }
        if (loadScreen) {
            float x = (Time.time - startTime) / fadeTime;
            gameIconRenderer.color = new Color(1, 1, 1, 1-x);
            if (x > 1) {
                loadScreen = false;
                StartCoroutine(LoadNewScene(loadLevelName));
            }
        }
		
	}
}
