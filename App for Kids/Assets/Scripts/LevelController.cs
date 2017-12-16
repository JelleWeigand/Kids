using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour {


    public static bool exit = false;
    public float maskSize;
    public float transitionTime;
    public string backButton;

    private float diagonal;
    private float startTime;
    private GameObject mask;
    private float exitTime;
    private bool enter = true;
    private string loadLevelName;
    

    public void Exit(string name) {
        if (name == "BackButton") {
            loadLevelName = backButton;
        }
        else {
            loadLevelName = name;
        }
        exit = true;
        exitTime = Time.time;
        diagonal = Camera.main.orthographicSize * 2 * Mathf.Pow(Mathf.Pow(Camera.main.aspect,2f)+1, 0.5f);
    }

    void Start () {
        startTime = Time.time;
        mask = GameObject.Find("MaskLoadScene");
        mask.transform.localScale = new Vector3(0, 0, 1);
        diagonal = Camera.main.orthographicSize * 2 * Mathf.Pow(Mathf.Pow(Camera.main.aspect, 2f) + 1, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape)) { 
            Exit("BackButton");
            Debug.Log("Back Button Pressed");
        }
        if(enter) {
            float x = (Time.time - startTime) / transitionTime;
            float scale = Mathf.Clamp(diagonal * 1.1f * x, 0, diagonal * 1.1f)/maskSize;
            mask.transform.localScale = new Vector3(scale, scale, 1);
            if (x > 1) {
                enter = false;
            }
        }
        if (exit) {
            float x = (Time.time - exitTime) / transitionTime;
            float scale = Mathf.Clamp(diagonal * 1.1f * (1 - x), 0, diagonal * 1.1f)/maskSize;
            mask.transform.localScale = new Vector3(scale, scale, 1);
            if (x > 1) {
                StartCoroutine(LoadNewScene(loadLevelName));
            }
        }
		
	}
    IEnumerator LoadNewScene(string levelName) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
