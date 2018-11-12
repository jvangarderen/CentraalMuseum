using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
	}

    void Spawn()
    {
        GameObject instance = Instantiate(Resources.Load("art", typeof(GameObject))) as GameObject;
    }
}
