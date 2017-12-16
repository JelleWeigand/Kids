using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    public string levelName;

    void OnMouseUpAsButton()
    {
        if (TouchControl.touchTap)
        {
            GameObject.Find("LevelController").GetComponent<LevelControllerMain>().LoadLevel(this.gameObject,levelName);
        }
    }
}
