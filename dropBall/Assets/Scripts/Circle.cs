using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Circle : MonoBehaviour {

    private Shake shake;

    private Rigidbody2D rb;

    public string soundName;    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            FindObjectOfType<AudioManager>().Play(soundName);
            shake.CamShake();
        }
    }

}
