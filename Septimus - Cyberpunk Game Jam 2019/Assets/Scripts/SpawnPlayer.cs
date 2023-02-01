using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {


	public Transform playerTransform;
	public Transform trigger1;
	public Transform trigger2;
	public Transform trigger3;
	public Transform trigger4;

	[HideInInspector]
	public int counter = 0;

	public GameObject ps;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			if (counter == 1) {
				
				Instantiate (ps, trigger1.transform.position,Quaternion.identity);
				playerTransform.transform.position = trigger1.transform.position;


			} else if (counter == 2) {
				
				Instantiate (ps, trigger2.transform.position,Quaternion.identity);
				playerTransform.transform.position = trigger2.transform.position;

			} else if (counter == 3) {
				
				Instantiate (ps, trigger3.transform.position,Quaternion.identity);
				playerTransform.transform.position = trigger4.transform.position;
			}
			else if (counter == 4) {

				Instantiate (ps, trigger3.transform.position,Quaternion.identity);
				playerTransform.transform.position = trigger3.transform.position;
			}
			else{
				
				Instantiate (ps, trigger1.transform.position,Quaternion.identity);
				playerTransform.transform.position = trigger1.transform.position;
			}
		}
	}

}
