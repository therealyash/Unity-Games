using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player1 : MonoBehaviour {

	public Camera cam;
	public NavMeshAgent agent;
	public Animator playerAnim;      

    public BoxCollider winCollider;


    void Update(){
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = cam.ScreenPointToRay (Input.mousePosition); 
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {

                if(hit.rigidbody.tag == "Wall")
                {
                    Debug.Log("WallTouched");
                }
                else if (hit.rigidbody.tag == "Ground")
                {
                    agent.SetDestination(hit.point);
                }

                winCollider.enabled = false;
							
			}
            winCollider.enabled = false;
            
		}

        winCollider.enabled = true;

    }
     
    
}
