using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrollskript : MonoBehaviour {

    public static Animator main_animator, rueckenmark_animator;
    //AnimatorStateInfo stateInfo1, stateInfo2;

    string[] animNamesR = new string[] { "Idle", "01_Hinsetzen", "02_Hammer_R", "03_Muskelspindel_R", "04_SignalZumR_ckenmark_R", "05_R_ckenmark_R", "06_SignalZumMuskel_R", "07_Endplatte_Kick_R" };
    string[] animNamesL = new string[] { "Idle", "01_Hinsetzen", "02_Hammer_L", "03_Muskelspindel_L", "04_SignalZumR_ckenmark_L", "05_R_ckenmark_R", "06_SignalZumMuskel_L", "Endplatte_L", "07_Endplatte_Kick_L" };

    string[] animNamesRueckenmark = new string[] { "Teil1", "Teil2", "Teil3" };
    string lastAnimName = "";
    string lastRueckenmarkAnimName = "";
    public static int currentAnim;
    AnimatorStateInfo currInfo;
    //int[] animHashes = new int[] { animHash1, animHash2L, animHash2R, animHash3L, animHash3R, animHash4L, animHash4R, animHash5, animHash6L, animHash6R, animHash7L, animHash7R };

    public static bool right = false;
    bool rueckenmarkState = false;

    GameObject hammer_L, hammer_R, signal_L, signal_R, muskelspindel_L, muskelspindel_R, endplatte_L, endplatte_R, signal2, kreuz, rueckenmark;

    void Start () {

        //Erstellt Instanzen der zu  Körperteile
        rueckenmark = GameObject.Find("Rueckenmark_v1");
        main_animator = GameObject.Find("Modell_v3.1_FBX").GetComponent<Animator>();
        rueckenmark_animator = rueckenmark.GetComponent<Animator>();
        currInfo = main_animator.GetCurrentAnimatorStateInfo(0);

        hammer_L = GameObject.Find("Modell_v3.1_FBX/Hammer.L");
        hammer_R = GameObject.Find("Modell_v3.1_FBX/Hammer.R");
        signal_L = GameObject.Find("Modell_v3.1_FBX/Signal.L");
        signal_R = GameObject.Find("Modell_v3.1_FBX/Signal.R");
        muskelspindel_L = GameObject.Find("Modell_v3.1_FBX/Muskelspindel.L");
        muskelspindel_R = GameObject.Find("Modell_v3.1_FBX/Muskelspindel.R");
        endplatte_L = GameObject.Find("Modell_v3.1_FBX/Endplatte.L");
        endplatte_R = GameObject.Find("Modell_v3.1_FBX/Endplatte.R");

        signal2 = GameObject.Find("Rueckenmark_v1/Signal_2");
        kreuz = GameObject.Find("Rueckenmark_v1/Kreuz");

        Pause_Play_Button.state = false;
    }

	void FixedUpdate () {

        foreach (string animName in animNamesL)
        {

            if (main_animator.GetCurrentAnimatorStateInfo(0).IsName(animName) && animName != lastAnimName )
            {
                currInfo = main_animator.GetCurrentAnimatorStateInfo(0);
                Debug.Log("Animation Name: "+animName+ ": "+ main_animator.GetCurrentAnimatorStateInfo(0).length);
                lastAnimName = animName;

                //Checkt ab, welche Animation am laufen ist
                switch (animName)
                {
                    case "Idle":
                        currentAnim = 0;
                        SettingsIdle(1);
                        break;
                    case "01_Hinsetzen":
                        currentAnim = 1;
                        break;
                    case "02_Hammer_R":
                        currentAnim = 2;
                        SettingsHammer(2);
                        break;
                    case "02_Hammer_L":
                        currentAnim = 2;
                        SettingsHammer(2);
                        break;
                    case "03_Muskelspindel_R":
                        currentAnim = 3;
                        SettingMuskelspindel(0);
                        break;
                    case "03_Muskelspindel_L":
                        currentAnim = 3;
                        SettingMuskelspindel(0);
                        break;
                    case "04_SignalZumR_ckenmark_R":
                        currentAnim = 4;
                        SettingSignalZumRueckenmark(1);
                        break;
                    case "04_SignalZumR_ckenmark_L":
                        currentAnim = 4;
                        SettingSignalZumRueckenmark(1);
                        break;
                    case "05_R_ckenmark_R":
                        currentAnim = 5;
                        SettingsRueckenmark(1);
                        break;
                    case "06_SignalZumMuskel_R":
                        currentAnim = 6;
                        SettingsSignalZumMuskel(0);
                        break;
                    case "06_SignalZumMuskel_L":
                        currentAnim = 6;
                        SettingsSignalZumMuskel(0);
                        break;
                    case "Endplatte_R":
                        currentAnim = 7;
                        SettingEndplatte(1);
                        break;
                    case "Endplatte_L":
                        currentAnim = 7;
                        SettingEndplatte(1);
                        break;
                    case "07_Endplatte_Kick_R":
                        currentAnim = 8;
                        break;
                    case "07_Endplatte_Kick_L":
                        currentAnim = 8;
                        break;
                    default:
                        currentAnim = 0;
                        break;
                }

                

            }
        }
        
        foreach (string animName in animNamesRueckenmark)
        {
            if (rueckenmarkState && rueckenmark_animator.GetCurrentAnimatorStateInfo(0).IsName(animName) && animName != lastRueckenmarkAnimName)
            {
                Debug.Log(lastRueckenmarkAnimName+" | "+animName);
                lastRueckenmarkAnimName = animName;
                switch (animName)
                {
                    case "Teil1":
                        Debug.Log("Teil1");
                        SettingsTeil1();
                        break;
                    case "Teil2":
                        Debug.Log("Teil2");
                        SettingsTeil2();
                        break;
                    case "Teil3":
                        Debug.Log("Teil3");
                        SettingsTeil3();
                        break;
                    default:
                        Debug.Log("default");
                        break;
                }
            }
        }
        

	}
    //Setzt Sichtbarkeit der benötigten Objekte für den Start der Animation
    void SettingsIdle(int delay)
    {
        //currentAnim = 0;
        if (delay == 1)
        {
            Pause_Play_Button.state = false;
        }
        

        moveCam.boneCam.enabled = false;
        moveCam.nerveCam.enabled = false;
        moveCam.rueckenmarkCam.enabled = false;
        rueckenmark_animator.speed = 0;
        hammer_L.SetActive(false);
        hammer_R.SetActive(false);
        signal_L.SetActive(false);
        signal_R.SetActive(false);
        muskelspindel_L.SetActive(false);
        muskelspindel_R.SetActive(false);
        endplatte_L.SetActive(false);
        endplatte_R.SetActive(false);

        signal2.SetActive(false);
        kreuz.SetActive(false);
        rueckenmarkState = false;

    }
    //Setzt Sichtbarkeit der benötigten Objekte für Animation "02_Hammer"
    void SettingsHammer(int delay)
    {
        if (delay > 0)
        {
            StartCoroutine(Waiter(delay));
        }
        SettingsIdle(0);

        //currentAnim = 2;
        moveCam.boneCam.enabled = true;
        if (right)
        {
            hammer_R.SetActive(true);
        }else
        {
            hammer_L.SetActive(true);
        }
        
    }
    //Setzt Sichtbarkeit der benötigten Objekte für Animation "03_Muskelspindel"
    void SettingMuskelspindel(int delay)
    {

        SettingsHammer(0);
        //currentAnim = 3;
        moveCam.nerveCam.enabled = true;
        

        if (right)
        {
            muskelspindel_R.SetActive(true);
        }
        else
        {
            muskelspindel_L.SetActive(true);
        }

    }
    //Setzt Sichtbarkeit der benötigten Objekte für Animation "04_SignalZumRückenmark"
    void SettingSignalZumRueckenmark(int delay)
    {
        if (delay > 0)
        {
            StartCoroutine(Waiter(delay));
        }
        SettingMuskelspindel(0);
       // currentAnim = 4;
        hammer_R.SetActive(false);
        hammer_L.SetActive(false);

        if (right)
        {
            signal_R.SetActive(true);
        }else
        {
            signal_L.SetActive(true);
        }
    }
    //Setzt Sichtbarkeit der benötigten Objekte für Animation in der extra Ansicht "05_Rückenmark"
    void SettingsRueckenmark(int delay)
    {
        SettingSignalZumRueckenmark(0);
        //currentAnim = 5;
        if (delay == 1)
        {
            rueckenmarkState = true;
            rueckenmark.SetActive(false);
            rueckenmark.SetActive(true);
            moveCam.rueckenmarkCam.enabled = true;
            rueckenmark_animator.speed = ChangeSpeed.animSpeedMult;
        }

        signal_L.SetActive(false);
        signal_R.SetActive(false);

    }
    //Setzt Sichtbarkeit der benötigten Objekte für Animation "06_SignalZumMuskel"
    void SettingsSignalZumMuskel(int delay)
    {
        SettingsRueckenmark(0);
        //currentAnim = 6;
        rueckenmarkState = false;
        moveCam.rueckenmarkCam.enabled = false;
        rueckenmark_animator.speed = 0;

        if (right)
        {
            signal_R.SetActive(true);
            endplatte_R.SetActive(true);
        }
        else
        {
            signal_L.SetActive(true);
            endplatte_L.SetActive(true);
        }
    }
    //Setzt Sichtbarkeit der benötigten Objekte für Animation "07_Endplatte"
    void SettingEndplatte(int delay)
    {
        
        SettingsSignalZumMuskel(0);

        if (delay > 0)
        {
            StartCoroutine(Waiter(delay));
        }
        //currentAnim = 7;

        signal_L.SetActive(false);
        signal_R.SetActive(false);

        
        //Endplatte blau
    }
    
    void SettingsTeil1()
    {
        Debug.Log("SettingsTeil1");
        signal2.SetActive(false);
        kreuz.SetActive(false);
    }

    void SettingsTeil2()
    {
        Debug.Log("SettingsTeil2");
        signal2.SetActive(true);
        kreuz.SetActive(false);
    }

    void SettingsTeil3()
    {
        Debug.Log("SettingsTeil3");
        signal2.SetActive(false);
        kreuz.SetActive(true);
    }

    //Stoppt die Animation für die mitgegebene Zeit
    IEnumerator Waiter(int waitingTime)
    {
        float main_speed_old = main_animator.speed;
        float rueckenmark_speed_old = rueckenmark_animator.speed;
        main_animator.speed = 0;
        rueckenmark_animator.speed = 0;
        float calcTime = waitingTime;
        if (ChangeSpeed.animSpeedMult>=1)
        {
            calcTime = waitingTime / ChangeSpeed.animSpeedMult;
        }
        
        yield return new WaitForSecondsRealtime(calcTime);
        Debug.Log(main_speed_old+" &&& "+rueckenmark_speed_old);
        main_animator.speed = main_speed_old == 0 ? 0 : ChangeSpeed.animSpeedMult;
        rueckenmark_animator.speed = rueckenmark_speed_old == 0 ? 0 : ChangeSpeed.animSpeedMult;
    }

}
