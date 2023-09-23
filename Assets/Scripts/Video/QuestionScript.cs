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
    public bool questionsAreHappening, fadedIn, finishedShowing;
    public string nextSceneName;
    int correctBtnNum;
    Color alphaText;
    Color alphaBtn;
    Color alphaBackdrop;
    [SerializeField] GameObject btn1, btn2, btn3, btn4;
    int userSelectedBtn;

    // Start is called before the first frame update
    void Start()
    {
        questionsAreHappening = false;
        fadedIn = false;
        finishedShowing = false;
        nextSceneName = "";
        userSelectedBtn = 0;
        
        alphaText = GameObject.Find("Opt1txt").GetComponent<Text>().color;
        alphaBtn = GameObject.Find("Opt1btn").GetComponent<Image>().color;
        alphaBackdrop = GameObject.Find("Question Backdrop").GetComponent<Image>().color;
        

        //Disables buttons
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        btn4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Check if it's time to show the questions
        //TODO: change so that it happens when the player makes it to the end
        if (GameObject.Find("TimeObject").GetComponent<TimerScript>().timerEnded)
        {
            questionsAreHappening = true;
        }

        //Fade in the questions
        if (questionsAreHappening && !finishedShowing)
        {
            ShowQuestions();
        }

        //Check what button was pressed
        if (finishedShowing && userSelectedBtn != 0)
        {
            nextSceneName = GameObject.Find("TimeObject").GetComponent<TimerScript>().nextSceneName;
            correctBtnNum = GameObject.Find("TimeObject").GetComponent<TimerScript>().correctBtn;

            //Reset level or go to next level
            if (userSelectedBtn == correctBtnNum)
            {
                //TODO: say you're right
                print("correct!");
                //ChangeScenes(nextSceneName);
            }
            else
            {
                //TODO: say you're wrong
                print("No!");
                //ChangeScenes(SceneManager.GetActiveScene().name);
            }
        }
    }

    void ShowQuestions()
    {
        //Fade in question screen
        if ((alphaText.a < FULL_ALPHA) && !fadedIn)
        {
            alphaBackdrop.a += .06f;
            alphaText.a += .06f;
            GameObject.Find("Question Backdrop").GetComponent<Image>().color = alphaBackdrop;
            GameObject.Find("QuestionText").GetComponent<Text>().color = alphaText;

            print("hi");

            if(alphaText.a >= FULL_ALPHA)
            {
                fadedIn = true;
                alphaText.a = EMPTY_ALPHA;

                //Enables buttons
                btn1.SetActive(true);
                btn2.SetActive(true);
                btn3.SetActive(true);
                btn4.SetActive(true);
            }
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

            GameObject.Find("Opt1btn").GetComponent<Image>().color = alphaBtn;
            GameObject.Find("Opt2btn").GetComponent<Image>().color = alphaBtn;
            GameObject.Find("Opt3btn").GetComponent<Image>().color = alphaBtn;
            GameObject.Find("Opt4btn").GetComponent<Image>().color = alphaBtn;

            if (alphaText.a >= FULL_ALPHA)
            {
                finishedShowing = true;
            }
        }
    }

    void ChangeScenes(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void BtnClick1()
    {
        userSelectedBtn = 1;
    }

    public void BtnClick2()
    {
        userSelectedBtn = 2;
    }

    public void BtnClick3()
    {
        userSelectedBtn = 3;
    }

    public void BtnClick4()
    {
        userSelectedBtn = 4;
    }
}
