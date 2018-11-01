using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D3D : MonoBehaviour {

	public enum MergeLayerDirection { front,center,back}
	public MergeLayerDirection mergeLayerDirection;
	public enum Axis {x,y,z};
	public Axis axis;
	public bool Active3DView = true;
	private bool moveObj = false;
    private bool fadeFrame = true;
	private float targetPos;
	public float switchtime = 5;
	private List<GameObject> ObjToMoveList;
	public GameObject SceneFrame; 
	[SerializeField]
	List<ListWrapper> LayerAmount = new List<ListWrapper>();


	// Use this for initialization
	void Start () {
        MakeFrameInvisable();
		
	}

    void MakeFrameInvisable()
    {
        foreach (Transform child in SceneFrame.transform)
        {
            MeshRenderer mr = child.GetComponent<MeshRenderer>();
            Color c = mr.material.color;
            c.a = 0;
            mr.material.color = c;
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space)) 
		{
			switch2D3D();
		}
        if(!fadeFrame)
        {
            foreach (Transform child in SceneFrame.transform)
            {
                MeshRenderer mr = child.GetComponent<MeshRenderer>();
                Color c = mr.material.color;
                c.a += (1 / switchtime) * Time.deltaTime;
                mr.material.color = c;
            }
        }
	}

	void switch2D3D()
	{
		if (Active3DView)
		{
			Active3DView = false;
			GetTargetPos();
		} 
		else 
		{
            GetObjectToMove();
            foreach (GameObject obj in ObjToMoveList)
            {
                LayerMoveAbleOBJ LMAO = obj.GetComponent<LayerMoveAbleOBJ>();
                LMAO.MoveToOriginalPosition(axis.ToString());
            }
            Active3DView = true;
        }
	}

	void GetTargetPos()
	{
		//AtillaTest(Axis.x);
		//AtillaTest(Axis.y);
		//AtillaTest(Axis.z);
        
		if (axis == Axis.x && mergeLayerDirection == MergeLayerDirection.back) { targetPos = LayerAmount[LayerAmount.Count - 1].objLayer[0].transform.position.x; }
		if (axis == Axis.y && mergeLayerDirection == MergeLayerDirection.back) { targetPos = LayerAmount[LayerAmount.Count - 1].objLayer[0].transform.position.y; }
		if (axis == Axis.z && mergeLayerDirection == MergeLayerDirection.back) { targetPos = LayerAmount[LayerAmount.Count - 1].objLayer[0].transform.position.z; }

		if (axis == Axis.x && mergeLayerDirection == MergeLayerDirection.center) { targetPos = LayerAmount[(int)Mathf.Ceil(LayerAmount.Count / 2)].objLayer[0].transform.position.x; }
		if (axis == Axis.y && mergeLayerDirection == MergeLayerDirection.center) { targetPos = LayerAmount[(int)Mathf.Ceil(LayerAmount.Count / 2)].objLayer[0].transform.position.y; }
		if (axis == Axis.z && mergeLayerDirection == MergeLayerDirection.center) { targetPos = LayerAmount[(int)Mathf.Ceil(LayerAmount.Count / 2)].objLayer[0].transform.position.z; }

		if (axis == Axis.x && mergeLayerDirection == MergeLayerDirection.front) { targetPos = LayerAmount[0].objLayer[0].transform.position.x; }
		if (axis == Axis.y && mergeLayerDirection == MergeLayerDirection.front) { targetPos = LayerAmount[0].objLayer[0].transform.position.y; }
		if (axis == Axis.z && mergeLayerDirection == MergeLayerDirection.front) { targetPos = LayerAmount[0].objLayer[0].transform.position.z; }
		Debug.Log("end gettargetpos");
		GetObjectToMove();
	}

	//void AtillaTest(Move2D3D.Axis Axis)
	//{
	//	if (axis == Axis && mergeLayerDirection == MergeLayerDirection.back) { targetPos = LayerAmount[LayerAmount.Count - 1].objLayer[0].transform.position.x; }
	//	if (axis == Axis && mergeLayerDirection == MergeLayerDirection.center) { targetPos = LayerAmount[(int)Mathf.Ceil(LayerAmount.Count / 2)].objLayer[0].transform.position.x; }
	//	if (axis == Axis && mergeLayerDirection == MergeLayerDirection.front) { targetPos = LayerAmount[0].objLayer[0].transform.position.x; }
	//}

	void GetObjectToMove()
	{
		ObjToMoveList = new List<GameObject>();
		switch (mergeLayerDirection) {
			case MergeLayerDirection.front:
				for(int i =0; i < LayerAmount.Count;i++) 
					{
					for(int j=0;j<LayerAmount[i].objLayer.Count;j++) 
					{
						ObjToMoveList.Add(LayerAmount[i].objLayer[j]);
					}
				}
				SetObjTargetPos();
				break;
			case MergeLayerDirection.center:
				for (int i = 0; i < LayerAmount.Count; i++) {
					for (int j = 0; j < LayerAmount[i].objLayer.Count; j++) {
						if(i != Mathf.Ceil(LayerAmount.Count/2)) {
							ObjToMoveList.Add(LayerAmount[i].objLayer[j]);
						}
					}
				}
				SetObjTargetPos();
				break;
			case MergeLayerDirection.back:
				for (int i = 1; i < LayerAmount.Count; i++) {
					for (int j = 0; j < LayerAmount[i].objLayer.Count; j++) {
						ObjToMoveList.Add(LayerAmount[LayerAmount.Count-(i+1)].objLayer[j]);
					}
				}
				SetObjTargetPos();
				break;
		};
	}

	private void SetObjTargetPos()
	{
		foreach (GameObject obj in ObjToMoveList) {
			LayerMoveAbleOBJ LMAO = obj.GetComponent<LayerMoveAbleOBJ>();
			LMAO.SetTargetLocation(axis.ToString(), targetPos);
		}
        fadeFrame = false;
	}
}

[System.Serializable]
public class ListWrapper
{
	public List<GameObject> objLayer;
}
