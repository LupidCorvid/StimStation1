using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victoryCheck : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] public bool levelCleared = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && FindObjectOfType<PlayerMovement>().hasPhone)
        {
            //Check that the player correfctly beat the level
            timerText.color = Color.green;
            
            levelCleared = true;
        }
    }
}
