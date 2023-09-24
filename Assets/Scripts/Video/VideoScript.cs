using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public VideoPlayer currentClip;
    SpriteRenderer sr;
    public Color alpha;
    public bool isPaused;
    public bool droppedPhone;
    public bool pickedUpPhone;

    float FULL_ALPHA = 1;
    float EMPTY_ALPHA = .1f;

    // Start is called before the first frame update
    void Start()
    {
        currentClip = gameObject.GetComponent<VideoPlayer>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        alpha = sr.color;

        isPaused = false;
        droppedPhone = false; //Flags true iff PhoneDropped() routine plays
        pickedUpPhone = false;//Flags true iff PhonePickedUp() routine plays
    }

    // Update is called once per frame
    void Update()
    {
        //Pause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused) isPaused = true;
            else
            {
                isPaused = false;
                PlayVideo();
            }
            print(isPaused);
        }

        //Video only runs when unpaused
        if (!isPaused)
        {
            if (droppedPhone)
            {
                PhoneDropped();
            }

            if (pickedUpPhone)
            {
                PhonePickedUp();
            }
        }

        if (isPaused)
        {
            PauseVideo();
        }
    }

    void PauseVideo()
    {
        currentClip.Pause();
        bool isPaused = true;
    }
    void PlayVideo()
    {
        currentClip.Play();
        bool isPaused = false;
    }

    public void PhoneDropped()
    {
        //Fades screen to black when phone is dropped
        if(alpha.a > EMPTY_ALPHA)
        {
            alpha.a -= .06f;
            alpha.r -= .06f;
            alpha.g -= .06f;
            alpha.b -= .06f;
            sr.color = alpha;
        }
        else
            droppedPhone = false; //Ends function
    }

    public void PhonePickedUp()
    {
        //Makes screen regular when you pick the phone back up
        if (alpha.a < FULL_ALPHA)
        {
            alpha.a += .06f;
            alpha.r += .06f;
            alpha.g += .06f;
            alpha.b += .06f;
            sr.color = alpha;
        }
        else
            pickedUpPhone = false; //Ends function
    }

    //void CheckLevel()
    //{
    //    string CurrentScene = SceneManager.GetActiveScene().name;

    //    switch (CurrentScene)
    //    {
    //        case "Level 1":
    //            break;
    //        case "Level 2":
    //            break;
    //        case "Level 3":
    //            break;
    //        case "Level 4":
    //            break;
    //        case "Level 5":
    //            break;
    //        default:
    //            print("Error in scene name. Going to default settings...");
    //            break;
    //    }
    //}
}
