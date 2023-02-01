using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 2;
	public float runSpeed = 6;
	public float gravity = -12;
	public float jumpHeight = 1;
	[Range(0,1)]
	public float airControlPercent;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	bool jumping;

	Animator animator;
	Transform cameraT;

	CharacterController controller;

	public TextMeshProUGUI scoreText;
	public int score = 0;

	public GameObject box1;
	public GameObject box2;

	void Start(){
		animator = GetComponent <Animator> ();
		controller = GetComponent <CharacterController> ();
		cameraT = Camera.main.transform;
		box1.SetActive (false);
		box2.SetActive (false);
	}

	void FixedUpdate () {
		Vector2 input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		Vector2 inputDir = input.normalized;
		bool running = Input.GetKey (KeyCode.LeftShift);


		Move (inputDir, running);

		if(Input.GetKey (KeyCode.Space)){
			animator.SetTrigger ("isJumping");
			Jump ();
		}





		if(Input.GetKeyDown (KeyCode.Escape)){
			SceneManager.LoadScene ("MainMenu");
		}


		//Animator
		float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed/walkSpeed * .5f);
		animator.SetFloat ("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

	

	}

	void Move(Vector2 inputDir, bool running){
		if (inputDir != Vector2.zero) {
			float targetRotaion = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle (transform.eulerAngles.y, targetRotaion, ref turnSmoothVelocity, GetModifiedSmoothTime (turnSmoothTime));
		}


		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity,GetModifiedSmoothTime (speedSmoothTime));

		velocityY += Time.deltaTime * gravity;

		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move (velocity * Time.deltaTime);
		currentSpeed = new Vector2 (controller.velocity.x, controller.velocity.z).magnitude;

		if(controller.isGrounded){
			velocityY = 0;
		}


	}

	void Jump(){
		if (controller.isGrounded) {			
			
			float jumpVelocity = Mathf.Sqrt (-1 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		} else if (!controller.isGrounded) {
			animator.SetBool ("isFalling", true);

		}
		/*if(jumpHeight > 0.1f){
			animator.SetTrigger ("JumpUp");

		}
		else if(jumpHeight < 3){
			animator.SetTrigger ("JumpDown");
			animator.SetTrigger ("Idle");
		}
		*/
	}

	float GetModifiedSmoothTime(float smoothTime){
		if(controller.isGrounded){
			return smoothTime;
		}
		if(airControlPercent == 0){
			return float.MaxValue;
		}
		return smoothTime / airControlPercent;
	}



	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Orb"){
			Destroy (other.gameObject);
			score += 1;
			scoreText.text = score.ToString ();

			if(score == 1){
				box1.SetActive (true);
			}

			else if (score == 2){
				box2.SetActive (true);
			}

		}
	}


}
