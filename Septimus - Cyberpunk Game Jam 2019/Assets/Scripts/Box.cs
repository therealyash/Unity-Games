using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	public GameObject Player;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"){
			Player.transform.parent = transform;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			Player.transform.parent = null;
		}
	}
}
