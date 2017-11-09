using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Play_Button : MonoBehaviour {

    public static bool state = true;
    bool state_old = true;
    public GUISkin myGUIskin;
    float x_pos = 0.14f;
    float y_pos = 0.933f;

    Animator main_animator, rueckenmark_animator;
    float main_old, rueckenmark_old;

    // Use this for initialization
    void Start () {
        //animator = GetComponent<Animator>();
        main_animator = GameObject.Find("Modell_v3.1_FBX").GetComponent<Animator>();
        rueckenmark_animator = GameObject.Find("Rueckenmark_v1").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()

    {
        state = GUI.Toggle(new Rect(x_pos * Screen.width, y_pos * Screen.height, Screen.width * 0.02f, Screen.width * 0.02f), state, "", myGUIskin.customStyles[0]);
        if (!state && state_old)
        {
            state_old = false;
            Debug.Log("off");
            main_old = main_animator.speed;
            main_animator.speed = 0;
            rueckenmark_old = rueckenmark_animator.speed;
            rueckenmark_animator.speed = 0;
        }
        else if(state && !state_old)
        {
            state_old = true;
            Debug.Log("on");
            main_animator.speed = main_old;
            rueckenmark_animator.speed = rueckenmark_old;
        }
    }
}