using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	private static Music instance;
	public AudioSource music;

	void Awake(){
		if(instance == null){
			instance = this;
		}
		else{
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);
	}

	void Start(){
		music = GetComponent <AudioSource> ();
		music.Play ();
	}

}
