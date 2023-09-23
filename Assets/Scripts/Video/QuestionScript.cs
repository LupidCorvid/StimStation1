using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionScript : MonoBehaviour
{
    public bool questionsAreHappening;
    public string nextSceneName;

    // Start is called before the first frame update
    void Start()
    {
        questionsAreHappening = false;
        nextSceneName = "";
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

    }

    void ChangeScenes()
    {

    }
}
