using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phonePickup : MonoBehaviour
{
    PlayerMovement player;
    private bool playerNear;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();   
    }

    private void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E)){

            Destroy(this.gameObject);
        }
    }

}
