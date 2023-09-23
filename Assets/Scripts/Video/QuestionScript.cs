using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour
{
    //Constants 
    float FULL_ALPHA = 1;
    float EMPTY_ALPHA = .1f;

    //variables
    public bool questionsAreHappening, fadedIn;
    public string nextSceneName;
    Color alphaText;
    Color alphaBtn;
    Color alphaBackdrop;

    // Start is called before the first frame update
    void Start()
    {
        questionsAreHappening = false;
        fadedIn = false;
        nextSceneName = "";

        alphaText = GameObject.Find("Opt1txt").GetComponent<Text>().color;
        alphaBtn = GameObject.Find("Opt1btn").GetComponent<SpriteRenderer>().color;
        alphaBackdrop = GameObject.Find("QuestionBackdrop").GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("TimeObject").GetComponent<TimerScript>().timerEnded)
        {

        }
    }

    void ShowQuestions()
    {
        //Fade in question screen
        if ((alphaText.a < FULL_ALPHA) && !fadedIn)
        {
            alphaBackdrop.a += .06f;
            alphaText.a += .06f;
            GameObject.Find("QuestionBackdrop").GetComponent<Image>().color = alphaBackdrop;
            print("hi");
        }
        else
        {
            fadedIn = true;
            alphaText.a = EMPTY_ALPHA;
        }

        //Fade in Options
        if ((alphaText.a < FULL_ALPHA) && fadedIn)
        {
            alphaText.a += .06f;
            alphaBtn.a += .06f;
            GameObject.Find("Opt1txt").GetComponent<Text>().color = alphaText;
            GameObject.Find("Opt2txt").GetComponent<Text>().color = alphaText;
            GameObject.Find("Opt3txt").GetComponent<Text>().color = alphaText;
            GameObject.Find("Opt4txt").GetComponent<Text>().color = alphaText;
        }
    }

    void ChangeScenes()
    {

    }
}
