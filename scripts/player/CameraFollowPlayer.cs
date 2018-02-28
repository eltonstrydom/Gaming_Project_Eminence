using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3 (0,6,-8);
	public float xTilt = 10;

	Vector3 destination = Vector3.zero;
	CharacterMovement charController;
	float rotateVel = 0;

	void Start()
	{
		SetCameraTarget (target);

	}
	//sets camera transform
	void SetCameraTarget(Transform t)
	{
		target = t;

		if (target != null)
		{
			if (target.GetComponent<CharacterMovement> ())
			{
				charController = target.GetComponent<CharacterMovement> ();
			}
		}

	}

	void LateUpdate()
	{

		MoveToTarget ();
		LookAtTarget ();

	}
	//moves camera to player
	void MoveToTarget()

	{
		destination = charController.TargetRotation * offsetFromTarget;
		destination += target.position;
		transform.position = destination;
	}
	//rotates to player
	void LookAtTarget()

	{
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y,target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x,eulerYAngle,0);

	}

}
