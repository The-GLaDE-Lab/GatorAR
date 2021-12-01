using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRotation : MonoBehaviour {

	Vector3 rot = Vector3.zero;

	// Use this for initialization
	void Awake()
	{
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 upAxis = Vector3.zero;
		Vector3 lookAt = Camera.current.transform.position;

		upAxis.y = 1;
		lookAt.y = transform.position.y;

		transform.LookAt(lookAt, upAxis);
	}

}
