using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnMusic : MonoBehaviour {
    private AudioSource audio;
    private float loudness;
    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    
    private float currentUpdateTime = 0f;

    private float clipLoudness;
    private float[] clipSampleData;
    [SerializeField]
    private float minIntensity;
    [SerializeField]
    private List<Light> effectedLights;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        clipSampleData = new float[sampleDataLength];
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength;//clipLoudness is what you are looking for
            
            foreach (Light l in effectedLights)
            {
                l.intensity = minIntensity+(clipLoudness * 10);
            }
        }
       
	}
}
