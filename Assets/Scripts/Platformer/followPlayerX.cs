using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayerX : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+3.5f, transform.position.z);
    }
}
