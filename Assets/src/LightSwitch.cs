using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {
	[SerializeField]
	private List<Light> lightsEffected;
	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void ToggleLight()
	{
		foreach(Light l in lightsEffected) {
			l.enabled = !l.enabled;
		}
	}
}
