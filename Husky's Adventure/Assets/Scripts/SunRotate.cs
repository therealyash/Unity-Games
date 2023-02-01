using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotate : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0f,1f,0f);
        transform.rotation = Quaternion.Euler(0f,0f,0f);
    }
}
