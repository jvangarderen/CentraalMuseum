using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gps_digitalfootprint : MonoBehaviour {
    private static gps_digitalfootprint Instance { set; get; }
    private float latitude, longitude;
	// Use this for initialization
	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
	}

    private IEnumerator StartLocationService()
    {
        if(!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }
        Input.location.Start();
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing &&maxWait>0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if(maxWait<=0)
        {
            Debug.Log("Timed out");
            yield break;
        }
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to get device location");
            yield break;
        }

        //else it works
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        yield break; 
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height * 0.5f), "lat:"+latitude);
        GUI.Label(new Rect(0, Screen.height*0.5f, Screen.width, Screen.height * 0.5f), "long:" + longitude);
    }
}
