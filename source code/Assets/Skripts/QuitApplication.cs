using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour {

    // Use this for initialization
    public Texture image;
    public GUIStyle style;

    bool pressed = false;

	void Start () {
		
	}

    private void OnGUI()
    {
        pressed = GUI.Button(new Rect(20, 20, Screen.width * 0.02f, Screen.width * 0.02f), new GUIContent("", "Schliessen"), style);
        GUI.color = Color.black;
        GUI.Label(new Rect(50, 20, 100, Screen.width * 0.02f), GUI.tooltip);
    }

    // Update is called once per frame
    void Update () {
        if (pressed)
        {
            Debug.Log("exit");
            Application.Quit();
        }
	}
}
