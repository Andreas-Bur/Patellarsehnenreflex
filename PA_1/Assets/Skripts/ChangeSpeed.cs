using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour {

    float animSpeedMult;
    string speedInputField;
    string speedInputFieldOld;
    
    public GUIStyle style;

	// Use this for initialization
	void Start () {

        animSpeedMult = 1f;
        speedInputField = animSpeedMult+"x";
        speedInputFieldOld = speedInputField;
        

        //save speed in public variable animSpeedMult
        //is changed: if !resting: set speed as animator.speed

        //TODO: at waiting/pause at resume set animator.speed as animSpeedMult
    }

    private void OnGUI()
    {
        GUI.skin.settings.cursorColor = Color.black;
        GUI.skin.settings.cursorFlashSpeed = 1;
        GUI.SetNextControlName("SpeedField");
        
        speedInputField = GUI.TextField(new Rect(Screen.width - 2 * 0.067f * Screen.height, 0.923f * Screen.height, Screen.width * 0.03f, Screen.width * 0.03f), speedInputField, style);

        if(speedInputField != speedInputFieldOld && GUI.GetNameOfFocusedControl() != "SpeedField")
        {
            try
            {
                if (speedInputField.EndsWith("x"))
                {
                    speedInputField = speedInputField.Substring(0, speedInputField.Length - 1);
                }
                animSpeedMult = float.Parse(speedInputField, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            }
            catch (System.Exception)
            {
                animSpeedMult = 1f;
                throw;
            }
            finally
            {
                speedInputField = animSpeedMult+"x";
                speedInputFieldOld = speedInputField;
                Debug.Log(speedInputField);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter");
            GUI.FocusControl("");
        }
	}
}
