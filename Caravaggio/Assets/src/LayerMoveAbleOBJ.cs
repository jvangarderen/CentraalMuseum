using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMoveAbleOBJ : MonoBehaviour {

	private Vector3 startpos;
	private Vector3 targetpos;
	private bool startMoving = false;

	// Use this for initialization
	void Start () {
		startpos = transform.position;
		Debug.Log(targetpos);
	}
	
	// Update is called once per frame
	void Update () {
		if (startMoving) {
			transform.position = Vector3.MoveTowards(transform.position, targetpos, 2 * Time.deltaTime);
		}
		
	}


	public void SetTargetLocation(string axis, float value)
	{
		Debug.Log("Did set  targetlocation");
		if(axis == "x") { targetpos = new Vector3(value, transform.position.y, transform.position.z);}
		if(axis == "y") { targetpos = new Vector3(transform.position.x, value, transform.position.z);}
		if(axis == "z") { targetpos = new Vector3(transform.position.x, transform.position.y, value);}
		startMoving = true;
	}
}
