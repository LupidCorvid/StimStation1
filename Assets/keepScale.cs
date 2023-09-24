using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepScale : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3 (Mathf.Abs(transform.localScale.x),transform.localScale.y, transform.localScale.z);
    }
}
