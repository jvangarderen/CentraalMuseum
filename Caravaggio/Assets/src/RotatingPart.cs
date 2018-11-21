using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPart : MonoBehaviour {
	private Transform startTransform;
	public enum Axis // your custom enumeration
	{
		x, y, z
	};
	public Axis axis;
	public float rotationValue;
	public float timeToFinishRotation;
	private bool fold = false;
	private float rotateSpeed;
	void Start() {
		startTransform = transform;
		rotateSpeed = rotationValue / timeToFinishRotation;
	}

	// Update is called once per frame
	void Update() {
		Rotate();
	}

	private void Rotate()
	{
		Vector3 rot = new Vector3();
		switch (axis) {
			case Axis.x: rot = new Vector3(transform.rotation.x + rotationValue, transform.rotation.y, transform.rotation.z); break;
			case Axis.y: rot = new Vector3(transform.rotation.x, transform.rotation.y + rotationValue, transform.rotation.z); break;
			case Axis.z: rot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationValue); break;
		}
		Quaternion rotation = Quaternion.Euler(rot);
		//example
		// calculate rotation speed
		float rotationSpeed = rotationValue / timeToFinishRotation;
		transform.rotation = Quaternion.Lerp(transform.rotation,rotation, Time.deltaTime);




	}

	public void startFolding()
	{
		fold = true;
	}
}
