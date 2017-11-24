using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButton : MonoBehaviour {

	public Texture image;
    public GUIStyle styleButton;
    Rect windowRect = new Rect(20, 20, 300, 500);
    Rect labelRect = new Rect(30, 30, 300, 50);
    public GUIStyle aboutStyle;

    bool windowOpen = false;
    bool pressed = false;

	void Start () {
		
	}

    private void OnGUI()
    {
        pressed = GUI.Button(new Rect(Screen.width - 0.067f * Screen.height, 0.933f * Screen.height, Screen.width * 0.02f, Screen.width * 0.02f), image, styleButton);

        if (pressed)
        {
            windowOpen = true;
        }

        if (windowOpen)
        {
            
            windowRect = GUILayout.Window(0, windowRect, aboutContent, "Über", GUILayout.Width(200), GUILayout.Height(100));

        }
    }

    void aboutContent(int id)
    {
        if (GUI.Button(new Rect(2, 2, 15, 15), new GUIContent("X", "Schliessen")))
        {
            windowOpen = false;
        }
        aboutStyle.fontSize = 18;
        aboutStyle.richText = true;
        

        GUILayout.Label("<b>Patellarsehnenreflex - eine 3D-Simulation</b>", aboutStyle);
        GUILayout.Label("Von <i>Andreas Bur</i>, 2017\n\n\n");
        GUILayout.Label("     <b>Steuerung:</b>\n", aboutStyle);
        GUILayout.Label("     Ansicht, Rotation\t\t- Rechte Maus");
        GUILayout.Label("     Ansicht, Translation\t- Rechte Maus + Shift");
        GUILayout.Label("     Pause\t\t\t- Leerstaste");

        GUI.DragWindow(new Rect(0, 0, 10000, 10000));

        
        
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
