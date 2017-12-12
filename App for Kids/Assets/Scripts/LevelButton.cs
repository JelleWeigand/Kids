using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour {

    public string levelName;

    void OnMouseUpAsButton()
    {
        if (TouchControl.touchTap)
        {
            Application.LoadLevel(levelName);
        }
    }
}
