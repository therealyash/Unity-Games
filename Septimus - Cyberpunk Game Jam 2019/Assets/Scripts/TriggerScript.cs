using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {



	public SpawnPlayer spawn;




	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			if (transform.name == "StartingPointTrigger") {
				spawn.counter = 1;
			} else if (transform.name == "SecondTrigger") {
				spawn.counter = 2;
			} else if (transform.name == "ThirdTrigger") {
				spawn.counter = 3;
			}
			else if (transform.name == "FourthTrigger") {
				spawn.counter = 4;
			}

		}
	}

}
