using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMoveAbleOBJ : MonoBehaviour {

	private Vector3 startpos;
	private Vector3 targetpos;
	private bool startMoving = false;
    private bool moveToOriginalPos = false;
	// Use this for initialization
	void Start () {
		startpos = transform.position;
		Debug.Log(targetpos);
	}
	
	// Update is called once per frame
	void Update () {
		if (startMoving) {
			transform.position = Vector3.MoveTowards(transform.position, targetpos, 2 * Time.deltaTime);
            if (transform.position == targetpos) startMoving = false;
		}
        if(moveToOriginalPos)
        {
            Debug.Log("move to original pos");
            transform.position = Vector3.MoveTowards(transform.position, targetpos, 2 * Time.deltaTime);
            if (transform.position == startpos) moveToOriginalPos = false;
        }
	}

    public void MoveToOriginalPosition(string axis)
    {
        if(axis == "x") SetTargetLocation(axis, startpos.x);
        if(axis == "y") SetTargetLocation(axis, startpos.y);
        if(axis == "z") SetTargetLocation(axis, startpos.z);
        moveToOriginalPos = true;
    }



    public void SetTargetLocation(string axis, float value)
	{
		Debug.Log("Did set  targetlocation");
		if(axis == "x") { targetpos = new Vector3(value, transform.position.y, transform.position.z);}
		if(axis == "y") { targetpos = new Vector3(transform.position.x, value, transform.position.z);}
		if(axis == "z") { targetpos = new Vector3(transform.position.x, transform.position.y, value);}
        if(moveToOriginalPos)
        {
            startMoving = false;
        }
        else
        {
            startMoving = true;
        }
	}
}
