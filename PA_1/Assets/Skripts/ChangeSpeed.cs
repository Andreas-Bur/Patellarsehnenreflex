using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour {

    public static float animSpeedMult;
    string speedInputField;
    string speedInputFieldOld;
    
    public GUIStyle style;

    bool hasSetZero = false;

	void Start () {

        animSpeedMult = 1f;
        speedInputField = animSpeedMult+"x";
        speedInputFieldOld = speedInputField;
    }

    private void OnGUI()
    {
        GUI.skin.settings.cursorColor = Color.black;
        GUI.skin.settings.cursorFlashSpeed = 1;
        GUI.SetNextControlName("SpeedField");
        
        speedInputField = GUI.TextField(new Rect(Screen.width - 2 * 0.067f * Screen.height, 0.923f * Screen.height, Screen.width * 0.03f, Screen.width * 0.03f), speedInputField, style);
        GUI.Label(new Rect(Screen.width - 2 * 0.067f * Screen.height, 0.923f * Screen.height, Screen.width * 0.03f, Screen.width * 0.03f), new GUIContent("", "Geschwindigkeit: "));

        if (GUI.tooltip == "Geschwindigkeit: ")
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(Screen.width - 2 * 0.067f * Screen.height - 100, 0.938f * Screen.height, Screen.width * 0.1f, Screen.width * 0.03f), "Geschwindigkeit: ");
        }

        if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return)
        {
            GUI.FocusControl(null);
        }

        if (speedInputField != speedInputFieldOld && GUI.GetNameOfFocusedControl() != "SpeedField")
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
            if (Kontrollskript.main_animator.speed != 0 || hasSetZero)
            {
                Kontrollskript.main_animator.speed = animSpeedMult;
            }
            if (Kontrollskript.rueckenmark_animator.speed != 0 || hasSetZero)
            {
                Kontrollskript.rueckenmark_animator.speed = animSpeedMult;
            }
            if (animSpeedMult == 0)
            {
                hasSetZero = true;
            }
            else
            {
                hasSetZero = false;
            }
        }
        
    }

    void Update () {

	}
}
