using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	Animator anim;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		//CheckKey();
		//gameObject.transform.eulerAngles = rot;

		//Get ARCamera Angle
		//Quaternion targetAngle = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);

		////Set object to ARCamera Angle, lerp the angle
		//this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetAngle, Time.deltaTime * 5f);

		//this.transform.LookAt(Camera.main.transform);

		//      var flatVectorToTarget = this.transform.position - Camera.current.transform.forward;
		//      flatVectorToTarget.y = 0.0f;
		//var newRotation = Quaternion.LookRotation(flatVectorToTarget);
		//      transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.fixedDeltaTime * 8);

		//Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
		//transform.LookAt(targetPosition);

		//transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position, Camera.main.transform.up);

		//var cameraForward = Camera.current.transform.forward;
		//var cameraBearing = new Vector3(cameraForward.x, 0, -cameraForward.z).normalized;
		//transform.rotation = Quaternion.LookRotation(cameraBearing);

		//var originalRotation = transform.rotation;
		//transform.LookAt(Camera.current.transform);
		//var newRotation = transform.rotation;

		//var finalRotation = new Quaternion(originalRotation.x, newRotation.y, originalRotation.z, originalRotation.w);

		//transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, Time.fixedDeltaTime * 8);

		Vector3 upAxis = Vector3.zero;
		Vector3 lookAt = Camera.current.transform.position;

		upAxis.y = 1;
		lookAt.y = transform.position.y;

		transform.LookAt(lookAt, upAxis);

	}

	void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
		}

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

}
