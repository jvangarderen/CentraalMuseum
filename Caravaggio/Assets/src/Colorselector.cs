using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorselector : MonoBehaviour {

    public float r, g, b;
	Renderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void redChanged(float value)
    {
        r = value;
        SetColor();
    }

    public void greenChanged(float value)
    {
        g = value;
        SetColor();
    }

    public void bluehanged(float value)
    {
        b= value;
        SetColor();
    }


    void SetColor()
    {
		renderer.material.color = new Color(r, g, b);
    }
}
