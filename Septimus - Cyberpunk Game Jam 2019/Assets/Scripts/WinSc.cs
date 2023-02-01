using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinSc : MonoBehaviour {

	public GameObject blurBox;
	public TextMeshProUGUI winText;
	public GameObject UIPanel;

	void Start(){
		blurBox.SetActive (false);
		winText.gameObject.SetActive (false);
		UIPanel.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			blurBox.SetActive (true);
			winText.gameObject.SetActive (true);
			UIPanel.gameObject.SetActive (true);

		}
	}
}
