using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour {

    public float animSpeedMult = 1f;
    string speedInputField = "1";
    
    public GUIStyle style;

	// Use this for initialization
	void Start () {
        //save speed in public variable animSpeedMult
        //is changed: if !resting: set speed as animator.speed

        //TODO: at waiting/pause at resume set animator.speed as animSpeedMult
    }

    private void OnGUI()
    {
        speedInputField = GUI.TextField(new Rect(Screen.width - 2 * 0.067f * Screen.height, 0.933f * Screen.height, Screen.width * 0.02f, Screen.width * 0.02f), "1", style);
    }

    // Update is called once per frame
    void Update () {
        try
        {
            animSpeedMult = float.Parse(speedInputField, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
        }
        catch (System.Exception)
        {
            animSpeedMult = 1f;
            throw;
        }
	}
}
