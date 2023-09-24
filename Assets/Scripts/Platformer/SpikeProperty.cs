using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProperty : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.popAndReset();
        }
    }
}
