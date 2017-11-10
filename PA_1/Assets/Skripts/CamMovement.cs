using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

    public GUISkin myGUIskin;
    bool state_old = true;
    bool state = true;
    float x_pos = 0.11f;
    float y_pos = 0.933f;
    int lastAnim = 0;

    Vector3 vector1 = new Vector3(0.8939163f, 2.618089f, 1.522013f);
    Vector3 vector2 = new Vector3(0.5024955f, 1.935519f, 0.6281146f);
    Vector3 vector3 = new Vector3(-0.07651434f, 1.660445f, 0.1801534f);
    Vector3 vector6 = new Vector3(-0.1938317f, 1.422495f, -0.1220979f);

    // Use this for initialization
    void Start () {
        
    }

    private void OnGUI()
    {
        if (state)
        {
            moveCam.disableMovement = true;
            state = GUI.Toggle(new Rect(x_pos * Screen.width, y_pos * Screen.height, Screen.width * 0.02f, Screen.width * 0.02f), state, new GUIContent("", "Automatische Kameraführung: An"), myGUIskin.customStyles[0]);
        }else
        {
            moveCam.disableMovement = false;
            state = GUI.Toggle(new Rect(x_pos * Screen.width, y_pos * Screen.height, Screen.width * 0.02f, Screen.width * 0.02f), state, new GUIContent("", "Automatische Kameraführung: Aus"), myGUIskin.customStyles[0]);
        }
        

        GUI.color = Color.black;
        GUI.Label(new Rect(x_pos * Screen.width, y_pos * Screen.height-40, 150, Screen.width * 0.04f), GUI.tooltip);

        if (!state && state_old)
        {
            state_old = false;
            //moveCam.disableMovement = false;
            Debug.Log("Cam off");


        }
        else if (state && !state_old)
        {
            Application.LoadLevel(1);
            state_old = true;
            //moveCam.disableMovement = true;
            Debug.Log("Cam on");
            
        }

    }


    void Update () {

        if (state)
        {
            if (Kontrollskript.currentAnim == 0)
            {
                moveCam.mainCam.transform.position = Vector3.MoveTowards(moveCam.mainCam.transform.position, new Vector3(0f, 3.1f, 3.28f), 0.1f * ChangeSpeed.animSpeedMult);
                moveCam.boneCam.transform.position = moveCam.mainCam.transform.position;
                moveCam.nerveCam.transform.position = moveCam.mainCam.transform.position;

                moveCam.mainCam.transform.rotation = Quaternion.RotateTowards(moveCam.mainCam.transform.rotation, Quaternion.Euler(20.59f, -180f, 0f), Time.deltaTime * 50f * ChangeSpeed.animSpeedMult);
                moveCam.boneCam.transform.rotation = moveCam.mainCam.transform.rotation;
                moveCam.nerveCam.transform.rotation = moveCam.mainCam.transform.rotation;
            }

            if (Kontrollskript.currentAnim == 1)
            {
                if (moveCam.mainCam.transform.position != vector1)
                {
                    moveCam.mainCam.transform.position = Vector3.MoveTowards(moveCam.mainCam.transform.position, vector1, 0.1f * ChangeSpeed.animSpeedMult);
                    moveCam.boneCam.transform.position = moveCam.mainCam.transform.position;
                    moveCam.nerveCam.transform.position = moveCam.mainCam.transform.position;

                    moveCam.mainCam.transform.rotation = Quaternion.RotateTowards(moveCam.mainCam.transform.rotation, Quaternion.Euler(33.894f, -158.48f, 0f), Time.deltaTime * 50f * ChangeSpeed.animSpeedMult);
                    moveCam.boneCam.transform.rotation = moveCam.mainCam.transform.rotation;
                    moveCam.nerveCam.transform.rotation = moveCam.mainCam.transform.rotation;

                }

            }

            if (Kontrollskript.currentAnim == 2)
            {
                moveCam.mainCam.transform.position = Vector3.MoveTowards(moveCam.mainCam.transform.position, vector2, 0.05f * ChangeSpeed.animSpeedMult);
                moveCam.boneCam.transform.position = moveCam.mainCam.transform.position;
                moveCam.nerveCam.transform.position = moveCam.mainCam.transform.position;
            }
            if (Kontrollskript.currentAnim == 3)
            {
                moveCam.mainCam.transform.position = Vector3.MoveTowards(moveCam.mainCam.transform.position, vector3, 0.05f * ChangeSpeed.animSpeedMult);
                moveCam.boneCam.transform.position = moveCam.mainCam.transform.position;
                moveCam.nerveCam.transform.position = moveCam.mainCam.transform.position;
            }
            if (Kontrollskript.currentAnim == 6)
            {
                moveCam.mainCam.transform.position = Vector3.MoveTowards(moveCam.mainCam.transform.position, vector6, 0.005f * ChangeSpeed.animSpeedMult);
                moveCam.boneCam.transform.position = moveCam.mainCam.transform.position;
                moveCam.nerveCam.transform.position = moveCam.mainCam.transform.position;

                moveCam.mainCam.transform.rotation = Quaternion.RotateTowards(moveCam.mainCam.transform.rotation, Quaternion.Euler(19.512f, -186.672f, -0.636f), Time.deltaTime * 40f * ChangeSpeed.animSpeedMult);
                moveCam.boneCam.transform.rotation = moveCam.mainCam.transform.rotation;
                moveCam.nerveCam.transform.rotation = moveCam.mainCam.transform.rotation;
            }
            if (Kontrollskript.currentAnim == 7)
            {
                moveCam.mainCam.transform.position = Vector3.MoveTowards(moveCam.mainCam.transform.position, vector1, 0.03f * ChangeSpeed.animSpeedMult);
                moveCam.boneCam.transform.position = moveCam.mainCam.transform.position;
                moveCam.nerveCam.transform.position = moveCam.mainCam.transform.position;

                moveCam.mainCam.transform.rotation = Quaternion.RotateTowards(moveCam.mainCam.transform.rotation, Quaternion.Euler(33.894f, -158.48f, 0f), Time.deltaTime * 100f * ChangeSpeed.animSpeedMult);
                moveCam.boneCam.transform.rotation = moveCam.mainCam.transform.rotation;
                moveCam.nerveCam.transform.rotation = moveCam.mainCam.transform.rotation;
            }
        }

    }
}
