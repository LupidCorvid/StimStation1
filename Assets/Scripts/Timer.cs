using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Constants
    //Amount of time per video
    float VID1 = 115f;
    float VID2 = 2f;
    float VID3 = 3f;
    float VID4 = 4f;
    float VID5 = 5f;

    //Variables
    float vidLength;
    public bool timerIsPlaying;
    Text timerTxt;
    int minutes, seconds;


    // Start is called before the first frame update
    void Start()
    {
        timerTxt = gameObject.GetComponent<Text>();
        CheckLevel();
        timerIsPlaying = true;
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

        //Executes when game is not paused
        if (timerIsPlaying)
        {
            PlayTimer();
        }
    }

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

    void setVariables(float length)
    {
        vidLength = length; //vidLength is given in seconds

        //Convert vid length into minutes and seconds
        minutes = (int) (vidLength / 60);
        seconds = (int) ((vidLength / 60) - minutes) * 60; //Gets the ratio of seconds then converts it into actual seconds

        //Update text object to initials
    }

    void PlayTimer()
    {
        
    }
}
