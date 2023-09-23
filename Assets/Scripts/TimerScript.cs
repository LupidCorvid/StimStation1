using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    //Constants
    //Amount of time per video
    float VID1 = 15f;
    float VID2 = 2f;
    float VID3 = 3f;
    float VID4 = 4f;
    float VID5 = 5f;

    //Variables
    float vidLength;
    public bool timerIsPlaying, timerEnded;
    Text timerTxt;
    int minutes;
    float seconds;
    float timerVar; //Tracks time.deltatime in seconds


    // Start is called before the first frame update
    void Start()
    {
        timerTxt = gameObject.GetComponent<Text>();
        CheckLevel();
        timerIsPlaying = true;
        timerEnded = false;
        timerVar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Pause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!timerIsPlaying) timerIsPlaying = true;
            else
                timerIsPlaying = false;
        }

        //Executes Timer when game is not paused
        if (timerIsPlaying)
        {
            timerVar += Time.deltaTime;
            if(timerVar >= 1)
            {
                PlayTimer();
                timerVar = 0;
            } 
        }

        //Player ran out of time
        if (timerEnded)
        {
            timerTxt.text = "" + "TIME OVER";
        }
    }

    //Checks what level is currently up so that setVariables() can be called
    void CheckLevel()
    {
        string CurrentScene = SceneManager.GetActiveScene().name;

        switch (CurrentScene)
        {
            case "Level 1":
                setVariables(VID1);
                break;
            case "Level 2":
                setVariables(VID2);
                break;
            case "Level 3":
                setVariables(VID3);
                break;
            case "Level 4":
                setVariables(VID4);
                break;
            case "Level 5":
                setVariables(VID5);
                break;
            default:
                print("Error in scene name. Going to default settings...");
                setVariables(VID1);
                break;
        }

        print("Debug: Vid length is " + vidLength);
    }

    //Called at the start, sets all variables that would be unique per level
    void setVariables(float length)
    {
        vidLength = length; //vidLength is given in seconds

        //Convert vid length into minutes and seconds
        minutes = (int) (vidLength / 60);
        seconds =  ((vidLength / 60) - minutes) * 60; //Gets the ratio of seconds then converts it into actual seconds

        //Update text object to initials
        //Update visual
        timerTxt.text = "" + minutes + ":" + seconds;

        print(vidLength + " " + minutes + ":" + seconds);
    }

    //Timer counts down
    void PlayTimer()
    {
        if (minutes == 0 && seconds == 0)
        {
            timerEnded = true;
            timerIsPlaying = false;
        }   
        else
        {
            //Decriment timer
            if(seconds == 0)
            {
                minutes--;
                seconds = 59;

                //Update visual
                timerTxt.text = "" + minutes + ":" + seconds;
            }
            else
            {
                seconds--;
                //Update visual
                if(seconds < 10)
                    timerTxt.text = "" + minutes + ":0" + seconds;
                else
                    timerTxt.text = "" + minutes + ":" + seconds;
            }
        }
    }
}