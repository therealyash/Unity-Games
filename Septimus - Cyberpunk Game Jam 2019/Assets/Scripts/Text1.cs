using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text1 : MonoBehaviour {



	public TextMeshProUGUI displayText;

	void Start(){
		displayText.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			displayText.gameObject.SetActive (true);
		}
	

	}

}
