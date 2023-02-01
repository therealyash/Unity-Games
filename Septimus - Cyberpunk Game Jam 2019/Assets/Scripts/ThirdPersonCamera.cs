using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	public float mouseSensitivity = 10;
	public Transform target;
	public float distFromTarget = 2;

	public Vector2 pitchMinMax = new Vector2 (-40, 85);

	public float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw;
	float pitch;

	void LateUpdate ()
	{
		yaw += Input.GetAxis ("Mouse X");
		pitch -= Input.GetAxis ("Mouse Y");
		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);


		Vector3 targetRotation = new Vector3 (pitch, yaw);
		transform.eulerAngles = currentRotation;

		transform.position = target.position - transform.forward * distFromTarget;
	}
}
