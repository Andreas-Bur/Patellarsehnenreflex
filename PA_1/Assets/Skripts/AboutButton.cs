using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButton : MonoBehaviour {

	public Texture image;
    public GUIStyle style;

    bool pressed = false;

	void Start () {
		
	}

    private void OnGUI()
    {
        pressed = GUI.Button(new Rect(Screen.width - 0.067f * Screen.height, 0.933f * Screen.height, Screen.width * 0.02f, Screen.width * 0.02f), image, style);
    }

    // Update is called once per frame
    void Update () {
        if (pressed)
        {
            Debug.Log("About");
            //Open Window
        }
	}
}
