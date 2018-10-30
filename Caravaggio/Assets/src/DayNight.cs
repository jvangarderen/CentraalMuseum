using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {
    [SerializeField]
    [Range(0, 1)]
    private float alpha;
    private Color nightColor;
    Texture2D texture; 
	// Use this for initialization
	void Start () {
        texture = new Texture2D(2, 2);
    }
	
	// Update is called once per frame
	void Update () {
        nightColor = new Color(0, 0, 0, alpha);
        texture.SetPixel(0,0,nightColor);
        texture.SetPixel(0, 1, nightColor);
        texture.SetPixel(1, 0, nightColor);
        texture.SetPixel(1, 1, nightColor);
        texture.Apply();
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),texture);
    }
}
