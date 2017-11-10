using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrollbalken : MonoBehaviour {
    float x_pos = 0.18f;
    float y_pos = 0.933f;
    float sizeX = 0.64f;
    float sizeY = 0.01f;

    float value = 0f;
    //string[] animNamesL = new string[] { "Game_engine|Idle", "01_Hinsetzen", "02_Hammer_L", "03_Muskelspindel_L", "04_SignalZumR_ckenmark_L", "05_R_ckenmark_R", "06_SignalZumMuskel_L", "Endplatte_L", "07_Endplatte_Kick_L" };
    float[] animLengths;
    string[] animNames;
    float totalTime = 0f;
    float curTime, curTimeOld;
    bool reachedEnd = false;

    Animator main_animator;
    RuntimeAnimatorController rac;

    // Use this for initialization

    private void OnGUI()
    {

        value = GUI.HorizontalSlider(new Rect(x_pos * Screen.width, y_pos * Screen.height + Screen.height * 0.01f, Screen.width * sizeX, Screen.width * sizeY), value, 0f, 1f);
        //value = 0.5f;

    }


    void Start () {
        main_animator = GameObject.Find("Modell_v3.1_FBX").GetComponent<Animator>();
        curTimeOld = 0;
        setupLengths();
	}
	
	// Update is called once per frame
	void Update () {

        if (main_animator.speed > 0 || Kontrollskript.rueckenmark_animator.speed > 0) //Change to animSpeedMult
        {
            curTime = 0;

            for (int i = 0; i < Kontrollskript.currentAnim; i++)
            {
                curTime += animLengths[i];
                
            }
            Debug.Log("i: " + Kontrollskript.currentAnim);
            float playback_time = (main_animator.GetCurrentAnimatorStateInfo(0).normalizedTime) * animLengths[Kontrollskript.currentAnim];


            //Debug.Log(Kontrollskript.currentAnim+" length: "+ main_animator.GetCurrentAnimatorStateInfo(0).length);
            Debug.Log("normTime: " + main_animator.GetCurrentAnimatorStateInfo(0).normalizedTime + " stateLength: " + animLengths[Kontrollskript.currentAnim]);
            Debug.Log("playbacktime: " + playback_time + " currtime: " + curTime);
            curTime += playback_time;
            Debug.Log("totalCurrentTime: " + curTime);
            if(Kontrollskript.currentAnim == 1)
            {
                reachedEnd = false;
            }
            if(Kontrollskript.currentAnim == 8)
            {
                reachedEnd = true;
            }

            if(curTime < curTimeOld && !reachedEnd)
            {

                //Pause_Play_Button.state = false;
                curTime = curTimeOld;
            }
            curTimeOld = curTime;
            
            value = curTime / totalTime;
        }
        
    }

    private void FixedUpdate()
    {
        
        

        //Debug.Log("String: "+ main_animator.GetCurrentAnimatorStateInfo(0).IsName);
    }

    void setupLengths()
    {
        if (main_animator != null)
        {
            
            rac = main_animator.runtimeAnimatorController;
            animNames = new string[rac.animationClips.Length];
            animLengths = new float[rac.animationClips.Length];
            for (int i = 0; i < rac.animationClips.Length; i++)
            {
                animNames[i] = rac.animationClips[i].name;
                animLengths[i] = rac.animationClips[i].length;
                totalTime += animLengths[i];
                //Debug.Log("speed: "+ rac.animationClips[Kontrollskript.currentAnim].apparentSpeed);
                Debug.Log(rac.animationClips[i].name+": "+ animLengths[i]);
            }
            Debug.Log("total_time: "+totalTime);
        }
    }
}
