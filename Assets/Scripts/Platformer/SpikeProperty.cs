using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeProperty : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            Text tempText = GameObject.Find("TimeObeject").GetComponent<Text>();
            tempText.text = "Ouchie! :(";
            tempText.color = Color.red;
            FindObjectOfType<TimerScript>().timerIsPlaying = false;
            player.popAndReset();
        }
    }
}
