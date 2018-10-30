using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class travelDimension : MonoBehaviour {

    public Material[] materials;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.name != "Main Camera") return;
        if (transform.position.z > other.transform.position.z)
        {
            foreach(var mat in materials)
            {
                mat.SetInt("_StencilTest",(int)CompareFunction.Equal);
            }
        }
        else
        {
            foreach (var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
