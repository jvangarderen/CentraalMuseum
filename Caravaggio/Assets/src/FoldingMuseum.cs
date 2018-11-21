using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldingMuseum : MonoBehaviour {

	private List<GameObject> buildingParts;

	// Use this for initialization
	void Start () {
		buildingParts = new List<GameObject>();
		foreach (Transform child in transform) {
			if(child.GetComponent<RotatingPart>()) {
				buildingParts.Add(child.gameObject);
				Debug.Log(buildingParts.Count);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space)) {
			startFolding();
		}
	}

	void startFolding()
	{
		for(int i =0; i <buildingParts.Count;i++) {
			RotatingPart rp = buildingParts[i].GetComponent<RotatingPart>();
			rp.startFolding();
		}
	}
}
