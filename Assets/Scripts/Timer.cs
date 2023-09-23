using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Constants
    //Amount of time per video
    float VID1 = 1f;
    float VID2 = 2f;
    float VID3 = 3f;
    float VID4 = 4f;
    float VID5 = 5f;

    //Variables
    float vidLength;
    public bool timerIsPlaying;

    // Start is called before the first frame update
    void Start()
    {
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
                vidLength = VID1;
                break;
            case "Level 2":
                vidLength = VID2;
                break;
            case "Level 3":
                vidLength = VID3;
                break;
            case "Level 4":
                vidLength = VID4;
                break;
            case "Level 5":
                vidLength = VID5;
                break;
            default:
                print("Error in scene name. Going to default settings...");
                vidLength = VID1;
                break;
        }

        print("Debug: Vid length is " + vidLength);
    }

    void PlayTimer()
    {

    }
}
