using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScenes : MonoBehaviour {

    SceneManager sceneManager;
    public static Text text1;
    public static Text text2;
    public static Text text3;

    private IEnumerator Start()
    {

        text1 = GameObject.Find("Canvas/Text1").GetComponent<Text>();
        text2 = GameObject.Find("Canvas/Text2").GetComponent<Text>();
        text3 = GameObject.Find("Canvas/Text3").GetComponent<Text>();
        text1.CrossFadeAlpha(0, 0, false);
        text2.CrossFadeAlpha(0, 0, false);
        text3.CrossFadeAlpha(0, 0, false);

        FadeIn1();
        yield return new WaitForSeconds(0.5f);
        FadeIn2();
        yield return new WaitForSeconds(1f);
        FadeIn3();
        yield return new WaitForSeconds(5f);
        FadeOut();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("PA_1");
    }

    void FadeIn1()
    {
        text1.CrossFadeAlpha(1.0f, 2f, false);
    }
    void FadeIn2()
    {
        text2.CrossFadeAlpha(1.0f, 2f, false);
    }
    void FadeIn3()
    {
        text3.CrossFadeAlpha(1.0f, 2f, false);
    }

    void FadeOut()
    {
        text1.CrossFadeAlpha(0f, 1f, false);
        text2.CrossFadeAlpha(0f, 1f, false);
        text3.CrossFadeAlpha(0f, 1f, false);
    }
    
}
