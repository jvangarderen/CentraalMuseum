using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightWithSound : MonoBehaviour
{
    public float minInterval;
    public float maxInterval;

    public Material objectMatDefault;
    public Material selectedMat;
    private float interval;
    private float timePassed = 0;
    public GameObject AudioObj;
    private GameObject child;
    AudioSource audio;
    public List<Transform> tlCylinders;
    private GameObject randomSelected;
    // Use this for initialization
    void Start()
    {
        if (AudioObj != null)
        {
            audio = AudioObj.GetComponent<AudioSource>();
        }

        foreach (Transform child in transform)
        {
            if (child.name.Contains("Cylind"))
            {
                tlCylinders.Add(child);
            }
        }
        chooseInterval();
    }

    void chooseInterval()
    {
        interval = Random.Range(minInterval, maxInterval);
    }

    void ChangeMaterial()
    {
        MeshRenderer mr;
        if (randomSelected != null)
        {
            mr = randomSelected.GetComponent<MeshRenderer>();
            mr.material = objectMatDefault;
        }

        randomSelected = tlCylinders[Random.Range(0, tlCylinders.Count)].gameObject;
        mr = randomSelected.GetComponent<MeshRenderer>();
        mr.material = selectedMat;
        AudioObj.transform.position = randomSelected.transform.position;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= interval)
        {
            ChangeMaterial();
            chooseInterval();
            timePassed = 0;
        }
    }
}
